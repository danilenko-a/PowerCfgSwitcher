using System;
using System.Collections;
using System.Collections.Generic;

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

        public static IEnumerable ForEach<T>(this IEnumerable sourse, Action<T> action)
        {
            foreach (T item in sourse)
                action(item);

            return sourse;
        }
    }
}
