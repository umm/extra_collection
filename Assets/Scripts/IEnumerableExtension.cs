using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraCollection
{
    public static class IEnumerableExtension
    {
        public static TValue FindMaxOrDefault<TValue, TKey>(
            this IEnumerable<TValue> enumerable,
            Func<TValue, TKey> keySelector
        ) where TKey : IComparable
        {
            bool found = false;
            TKey maxKey = default(TKey);
            TValue maxValue = default(TValue);

            foreach (var value in enumerable)
            {
                TKey key = keySelector(value);

                if (!found || key.CompareTo(maxKey) > 0)
                {
                    maxKey = key;
                    maxValue = value;
                    found = true;
                }
            }

            return maxValue;
        }

        public static IEnumerable<TValue> Scan<TValue>(
            this IEnumerable<TValue> enumerable,
            Func<TValue, TValue, TValue> accumulator
        )
        {
            TValue sum = default(TValue);

            foreach (var value in enumerable)
            {
                sum = accumulator(sum, value);
                yield return sum;
            }
        }

        public static string StringJoin(this IEnumerable<string> enumerable, string joint)
        {
            return string.Join(joint, enumerable.ToArray());
        }
    }
}