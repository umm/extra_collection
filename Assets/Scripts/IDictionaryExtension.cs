using System.Collections.Generic;

namespace ExtraCollection
{
    public static class IDictionaryExtension
    {
        public static TValue GetOrSet<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            System.Func<TValue> caller
        )
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary[key] = caller();
            }

            return dictionary[key];
        }

        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key
        )
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(TValue);
        }

        public static void AddOrSet<TKey>(this IDictionary<TKey, int> dictionary, TKey key, int value)
        {
            dictionary[key] = dictionary.ContainsKey(key) ? dictionary[key] + value : value;
        }
        
        public static void AddOrSet<TKey>(this IDictionary<TKey, float> dictionary, TKey key, float value)
        {
            dictionary[key] = dictionary.ContainsKey(key) ? dictionary[key] + value : value;
        }
        
        public static void AddOrSet<TKey>(this IDictionary<TKey, double> dictionary, TKey key, double value)
        {
            dictionary[key] = dictionary.ContainsKey(key) ? dictionary[key] + value : value;
        }
    }
}