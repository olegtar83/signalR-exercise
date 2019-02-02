
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Collections;

namespace SignalRChat
{
    public  class CacheManager 
    {
       public static ObjectCache cache = MemoryCache.Default;
        public static void SetCache<T>(T value, string key)
        {
            cache[key] = value;
        }

        public static  List<T> GetCache<T>()
        {
            List<T> list = new List<T>();
            IDictionaryEnumerator cacheEnumerator = (IDictionaryEnumerator)((IEnumerable)cache).GetEnumerator();

            while (cacheEnumerator.MoveNext())
                list.Add((T)cacheEnumerator.Value);
            list.Reverse();
            return list;
        }

    }
}