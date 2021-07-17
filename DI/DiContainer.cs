using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher.DI
{
    internal class DiContainer : IDiContainer
    {
        private readonly static ConcurrentDictionary<Type, Type> container = new ConcurrentDictionary<Type, Type>();

        static DiContainer()
        {
            container.AddOrUpdate(typeof(IDiContainer), typeof(DiContainer), (typeInterface, typeImplementation) => typeof(DiContainer));
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            container.AddOrUpdate(typeof(TInterface), typeof(TImplementation), (typeInterface, typeImplementation) => null);
        }

        private object Resolve(Type typeInterface)
        {
            var typeImplementation = container.GetOrAdd(typeInterface,
                type => throw new ApplicationException($"В DI-контейнере не зарегистрированно имплементации типа {typeInterface.Name}"));

            var ctors = typeImplementation.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            var diCtor = ctors.FirstOrDefault(ctor => ctor.GetParameters().Any() && ctor.GetParameters().All(param => container.ContainsKey(param.ParameterType)));
            if (!object.ReferenceEquals(diCtor, null))
            {
                var @params = diCtor.GetParameters().Select(param => Resolve(param.ParameterType));
                var instance = diCtor.Invoke(@params.ToArray());
                return instance;
            }

            var defaultCtor = ctors.FirstOrDefault(x => x.GetParameters().Length == 0);
            if (!object.ReferenceEquals(defaultCtor, null))
            {
                var instance = defaultCtor.Invoke(new object[] { });
                return instance;
            }

            throw new ApplicationException($"Не удалось создать объект класса {typeImplementation.Name}");
        }

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)Resolve(typeof(TInterface));
        }
    }
}
