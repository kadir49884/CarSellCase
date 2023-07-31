using System;
using System.Collections.ObjectModel;

namespace KadirExtension
{
    public static class ArrayHelper
    {
        public static T Find<T>(this T[] array, Predicate<T> match)
        {
            return Array.Find(array, match);
        }
    }
}
