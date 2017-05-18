using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfWhales.Json
{
    using JsonObject = IDictionary<string, object>;

    public interface ICodingReadOnly
    {
    }

    public interface ICoding
    {
        void Encode(JsonObject hash);
    }

    public interface IDecoding : ICoding
    {
        void Decode(JsonObject hash);
    }

    public static class JsonObjectExtention
    {
        private static readonly Dictionary<string, object> EmptyDictionary = new Dictionary<string, object>();
        private static readonly List<object> EmptyList = new List<object>();

        private static object Write(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj is string
                || obj is int
                || obj is float
                || obj is double
                || obj is long
                || obj is byte
                || obj is bool)
            {
                return obj;
            }
            if (obj is byte[])
            {
                return Convert.ToBase64String((byte[]) obj);
            }
            if (obj is DateTime)
            {
                return ((DateTime) obj).ToBinary();
            }
            if (obj.GetType().IsEnum)
            {
                return obj.ToString();
            }
            if (obj is ICoding)
            {
                var hash = new Dictionary<string, object>();
                ((ICoding) obj).Encode(hash);
                return hash;
            }
            if (obj is IDictionary)
            {
                var dict = (IDictionary) obj;
                var hash = new Dictionary<string, object>();
                foreach (var k in dict.Keys)
                {
                    hash.Set(Write(k).ToString(), Write(dict[k]));
                }
                return hash;
            }
            if (obj is IEnumerable)
            {
                return ((IEnumerable) obj).Cast<object>().Select(item => Write(item)).ToArray();
            }

            return obj;
        }

        private static object Read<T>(object obj)
        {
            var type = typeof(T);
            if (obj == null)
            {
                return null;
            }
            if (type == typeof(string))
            {
                return Convert.ToString(obj);
            }
            if (type == typeof(bool))
            {
                return Convert.ToBoolean(obj);
            }
            if (type == typeof(int))
            {
                return Convert.ToInt32(obj);
            }
            if (type == typeof(long))
            {
                return Convert.ToInt64(obj);
            }
            if (type == typeof(float))
            {
                return Convert.ToSingle(obj);
            }
            if (type == typeof(double))
            {
                return Convert.ToDouble(obj);
            }
            if (type.IsEnum)
            {
                return Enum.Parse(type, Convert.ToString(obj));
            }
            if (type == typeof(byte[]))
            {
                return Convert.FromBase64String(Convert.ToString(obj));
            }
            if (type == typeof(DateTime))
            {
                return DateTime.FromBinary(Convert.ToInt64(obj));
            }
            if (typeof(IDecoding).IsAssignableFrom(type))
            {
                var res = (IDecoding) Activator.CreateInstance(type);
                res.Decode((JsonObject) obj);
                return res;
            }
            if (typeof(ICoding).IsAssignableFrom(type))
            {
                return Activator.CreateInstance(type, (JsonObject) obj);
            }
            if (typeof(ICodingReadOnly).IsAssignableFrom(type))
            {
                return Activator.CreateInstance(type, (JsonObject) obj);
            }
            if (typeof(IEnumerable<KeyValuePair<string, object>>).IsAssignableFrom(type))
            {
                var pairs = (IDictionary) obj;
                return pairs.ToRegularDictionary<string, object>();
            }
            return obj;
        }

        public static void Set<T>(this JsonObject self, string key, T val)
        {
            self[key] = Write(val);
        }

        public static T Get<T>(this JsonObject self, string key, T defaultValue = default(T))
        {
            T res;
            if (self.TryGet(key, out res))
            {
                return res;
            }
            return defaultValue;
        }

        public static IEnumerable<T> GetEnumerable<T>(this JsonObject self, string key)
        {
            if (!self.ContainsKey(key))
            {
                return null;
            }

            var objects = self.Get<Object[]>(key);
            var list = new List<T>();
            objects.ForEach(o => list.Add((T) o));

            return list.Where(o => o != null).ToArray();
        }

        public static JsonObject GetChild(this JsonObject self, string key, JsonObject defaultValue = null)
        {
            return self.Get(key, defaultValue);
        }

        public static bool TryGet<T>(this JsonObject self, string key, out T res, T defaultValue = default(T))
        {
            res = defaultValue;
            if (!self.ContainsKey(key))
            {
                return false;
            }

            var val = self[key];
            if (val == null)
            {
                return false;
            }
            res = (T) Read<T>(val);
            return true;
        }


        public static T Ensure<T>(this JsonObject self, string key, T value = default(T))
        {
            T res;
            if (!self.TryGet(key, out res))
            {
                self.Set(key, value);
                res = value;
            }
            return res;
        }

        public static IEnumerable GetSequence(this JsonObject self, string key)
        {
            return self.Get<IList>(key, EmptyList);
        }

        public static IEnumerable<T> GetSequence<T>(this JsonObject self, string key)
        {
            return self.Get<IList>(key, EmptyList).Cast<object>().Select(item => (T) Read<T>(item));
        }

        public static IEnumerable<KeyValuePair<K, V>> GetSequence<K, V>(this JsonObject self, string key)
        {
            return
                self.Get<Dictionary<string, object>>(key, EmptyDictionary)
                    .Select(p => new KeyValuePair<K, V>((K) Read<K>(p.Key), (V) Read<V>(p.Value)));
        }

        public static IEnumerable<DictionaryEntry> CastDict(IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                yield return entry;
            }
        }

        public static Dictionary<K, V> ToRegularDictionary<K, V>(this IDictionary self)
        {
            var dic = new Dictionary<K, V>();
            foreach (var key in self.Keys)
            {
                dic[(K) Read<K>(key)] = (V) Read<V>(self[key]);
            }
            return dic;
        }
    }
}