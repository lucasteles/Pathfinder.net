﻿using System.Collections.Generic;
using System.Linq;
namespace Pathfinder
{
    internal static class Extensions
    {
        public static T Pop<T>(this IList<T> list)
        {
            var ret = list.Last();
            list.Remove(ret);
            return ret;
        }
        public static void Push<T>(this IList<T> list, T item)
        {
            list.Insert(0, item);
        }
    }
}