using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher
{
    internal static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sourse, Action<T> action)
        {
            foreach (var item in sourse)
                action(item);

            return sourse;
        }
    }
}
