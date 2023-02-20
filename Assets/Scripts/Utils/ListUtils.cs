using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Utils
{
    public static class ListUtils
    {
        private static readonly Random random = new Random();


        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }


        public static T RandomObject<T>(this IReadOnlyList<T> list) => RandomObject(list, UnityEngine.Random.Range);


        public static T RandomObject<T>(this IReadOnlyList<T> list, Func<int, int, int> randomFactory)
        {
            return (list.Count > 0) ? list[randomFactory(0, list.Count)] : default(T);
        }


        public static List<T> RandomObjects<T>(this IReadOnlyList<T> list, int elementsCount)
        {
            elementsCount = Mathf.Clamp(elementsCount, 1, list.Count);

            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }
    }
}