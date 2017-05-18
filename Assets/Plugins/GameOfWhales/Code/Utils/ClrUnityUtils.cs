using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#if !UNITY_IOS && !UNITY_ANDROID
using System.Linq;
#endif

namespace GameOfWhales
{
    /// <summary>
    /// IEnumerable unity utils. It based on features of iOS 
    /// </summary>
    /// <exception cref='InvalidOperationException'>
    /// Is thrown when an operation cannot be performed.
    /// </exception>
    /// <exception cref='ArgumentException'>
    /// Is thrown when an argument passed to a method is invalid.
    /// </exception>
    public static class ClrUnityUtils
    {
        #region LinqExt

        public static bool Contains<T>(this IEnumerable<T> list, T source)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				if (Equals(e, source)) {
					return true;
				}
			}
			return false;
			#else
            return Enumerable.Contains(list, source);
#endif
        }

        public static T First<T>(this IEnumerable<T> enumerable)
        {
#if UNITY_IOS || UNITY_ANDROID
			if (enumerable != null) {
				foreach (var item in enumerable) {
					return item;
				}
			}
			throw new System.ArgumentException("The source sequence is empty.");
			#else
            return Enumerable.First(enumerable);
#endif
        }

        public static T First<T>(this IEnumerable<T> enumerable, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			if (enumerable != null) {
				foreach (var item in enumerable) {
					if (selector(item)){
						return item;
					}
				}
			}
			throw new System.ArgumentException("The source sequence is empty.");
			#else
            return Enumerable.First(enumerable, selector);
#endif
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var first = default(T);
			foreach (var e in list) {
				first = e;
				break;
			}
			return first;
			#else
            return Enumerable.FirstOrDefault(list);
#endif
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				if (selector(e)) {
					return e;
				}
			}
			return default(T);
			#else
            return Enumerable.FirstOrDefault(list, selector);
#endif
        }

        public static T Last<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var i = 0;
			var elem = default(T);
			foreach (var e in list) {
				++i;
				elem = e;
			}
			if (i <= 0) {
				throw new InvalidOperationException("The source sequence is empty.");
			}
			return elem;
			#else
            return Enumerable.Last(list);
#endif
        }

        public static T Last<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
#if UNITY_IOS || UNITY_ANDROID
			var find = false;
			var elem = default(T);
			foreach (var e in list) {
				if (predicate(e)) {
					find = true;
					elem = e;
				}
			}
			if (!find) {
				throw new InvalidOperationException("The source sequence is empty.");
			}
			return elem;
			#else
            return Enumerable.Last(list);
#endif
        }

        public static T LastOrDefault<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var elem = default(T);
			foreach (var e in list) {
				elem = e;
			}
			return elem;
			#else
            return Enumerable.LastOrDefault(list);
#endif
        }

        public static T LastOrDefault<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var elem = default(T);
			foreach (var e in list) {
				if (selector(e)) {
					elem = e;
				}
			}
			return elem;
			#else
            return Enumerable.LastOrDefault(list, selector);
#endif
        }

        public static int Count<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			int i = 0;
			foreach (var e in list) {
				++i;
			}
			return i;
			#else
            return Enumerable.Count(list);
#endif
        }

        public static int Count<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			int i = 0;
			foreach (var e in list) {
				if (selector(e)){
					++i;
				}
			}
			return i;
			#else
            return Enumerable.Count(list, selector);
#endif
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				if (selector(e)) {
					yield return e;
				}
			}
			#else
            return Enumerable.Where(list, selector);
#endif
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> list, Func<T, TResult> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				yield return selector(e);
			}
			#else
            return Enumerable.Select(list, selector);
#endif
        }


        public static IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> list,
            Func<T, IEnumerable<TResult>> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				foreach (var childE in selector(e)) {
					yield return childE;
				} 
			}
			#else
            return Enumerable.SelectMany(list, selector);
#endif
        }

        public static bool Any<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				return true;
			}
			return false;
			#else
            return Enumerable.Any(list);
#endif
        }

        public static bool Any<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				if (selector(e)) {
					return true;
				}
			}
			return false;
			#else
            return Enumerable.Any(list, selector);
#endif
        }


        public static bool All<T>(this IEnumerable<T> list, Func<T, bool> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				if (!selector(e)) {
					return false;
				}
			}
			return true;
			#else
            return Enumerable.All(list, selector);
#endif
        }


        public static bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
#if UNITY_IOS || UNITY_ANDROID
			var comparer = EqualityComparer<T>.Default;
			bool result;
			using (IEnumerator<T> enumerator = first.GetEnumerator ())
			using (IEnumerator<T> enumerator2 = second.GetEnumerator ()){
				while (enumerator.MoveNext ()){
					if (!enumerator2.MoveNext ()){
						result = false;
						return result;
					}
					if (!comparer.Equals (enumerator.Current, enumerator2.Current)){
						result = false;
						return result;
					}
				}
				result = !enumerator2.MoveNext ();

			}
			return result;
			#else
            return Enumerable.SequenceEqual(first, second);
#endif
        }

        public static List<T> ToList<T>(this IEnumerable<T> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			return new List<T>(list);
			#else
            return Enumerable.ToList(list);
#endif
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
#if UNITY_IOS || UNITY_ANDROID
			ICollection<TSource> collection = source as ICollection<TSource>;
			TSource[] array;
			if (collection != null){
				if (collection.Count == 0){
					return new TSource[0];
				}
				array = new TSource[collection.Count];
				collection.CopyTo(array, 0);
				return array;
			}

			var num = 0;
			array = new TSource[0];
			foreach (TSource current in source){
				if (num == array.Length){
					if (num == 0){
						array = new TSource[4];
					}
					else{
						Array.Resize<TSource>(ref array, num * 2);
					}
				}
				array[num++] = current;
			}
			if (num != array.Length){
				Array.Resize<TSource>(ref array, num);
			}
			return array;

			#else
            return Enumerable.ToArray(source);
#endif
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(this IEnumerable<T> list,
            Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var dict = new Dictionary<TKey, TValue>();
			foreach (var e in list) {
				dict.Add(keySelector(e),valueSelector(e));
			}
			return dict;
			#else
            return Enumerable.ToDictionary(list, keySelector, valueSelector);
#endif
        }

        public static Dictionary<TKey, T> ToDictionary<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var dict = new Dictionary<TKey, T>();
			foreach (var e in list) {
				dict.Add(keySelector(e),(e));
			}
			return dict;
			#else
            return Enumerable.ToDictionary(list, keySelector);
#endif
        }

        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable list)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				TResult c = (TResult)e;
				yield return c;
			}
			#else
            return Enumerable.Cast<TResult>(list);
#endif
        }

        public static IEnumerable<TResult> WhereIs<TResult>(this IEnumerable list)
        {
            foreach (var e in list)
            {
                if (e is TResult)
                {
                    yield return (TResult) e;
                }
            }
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> list, IEnumerable<T> second)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				yield return e;
			}
			foreach (var e in second) {
				yield return e;
			}
			#else
            return Enumerable.Union(list, second);
#endif
        }


        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable)
        {
#if UNITY_IOS || UNITY_ANDROID
			var list = new List<T>();
			foreach (var e in enumerable) {
				if (!list.Contains(e)) {
					list.Add(e);
					yield return e;
				}
			}
			#else
            return Enumerable.Distinct(enumerable);
#endif
        }

        public static TResult Aggregate<T, TResult>(this IEnumerable<T> list, TResult start,
            Func<TResult, T, TResult> func)
        {
#if UNITY_IOS || UNITY_ANDROID
			foreach (var e in list) {
				start = func(start, e);
			}
			return start;
			#else
            return Enumerable.Aggregate(list, start, func);
#endif
        }

        public static float Sum<T>(this IEnumerable<T> list, Func<T, float> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var sum = 0f;
			foreach (var e in list) {
				sum += selector(e);
			}
			return sum;
			#else
            return Enumerable.Sum(list, selector);
#endif
        }

        public static float Sum(this IEnumerable<float> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var sum = 0f;
			foreach (var e in list) {
				sum += e;
			}
			return sum;
			#else
            return Enumerable.Sum(list);
#endif
        }

        public static int Sum<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var sum = 0;
			foreach (var e in list) {
				sum += selector(e);
			}
			return sum;
			#else
            return Enumerable.Sum(list, selector);
#endif
        }

        public static int Sum(this IEnumerable<int> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var sum = 0;
			foreach (var e in list) {
				sum += e;
			}
			return sum;
			#else
            return Enumerable.Sum(list);
#endif
        }

        public static float Min<T>(this IEnumerable<T> list, Func<T, float> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var min = 0f;
			foreach (var e in list) {
				var se = selector(e);
				if (!set) {
					set = true;
					min = se;
				}
				else if (se < min) {
					min = se;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return min;
			#else
            return Enumerable.Min(list, selector);
#endif
        }

        public static int Min<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var min = 0;
			foreach (var e in list) {
				var se = selector(e);
				if (!set) {
					set = true;
					min = se;
				}
				else if (se < min) {
					min = se;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return min;
			#else
            return Enumerable.Min(list, selector);
#endif
        }

        public static float Max(this IEnumerable<float> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var max = 0f;
			foreach (var e in list) {
				if (!set) {
					set = true;
					max = e;
				}
				else if (e > max) {
					max = e;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return max;
			#else
            return Enumerable.Max(list);
#endif
        }

        public static float Max<T>(this IEnumerable<T> list, Func<T, float> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var max = 0f;
			foreach (var e in list) {
				var se = selector(e);
				if (!set) {
					set = true;
					max = se;
				}
				else if (se > max) {
					max = se;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return max;
			#else
            return Enumerable.Max(list, selector);
#endif
        }

        public static int Max<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var max = 0;
			foreach (var e in list) {
				var se = selector(e);
				if (!set) {
					set = true;
					max = se;
				}
				else if (se > max) {
					max = se;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return max;
			#else
            return Enumerable.Max(list, selector);
#endif
        }

        public static int Max(this IEnumerable<int> list)
        {
#if UNITY_IOS || UNITY_ANDROID
			var set = false;
			var max = 0;
			foreach (var e in list) {
				if (!set) {
					set = true;
					max = e;
				}
				else if (e > max) {
					max = e;
				}
			}
			if (!set) {
				throw new InvalidOperationException("The source sequence is empty; " + "Operation is not valid due to the current state of the object");
			}
			return max;
			#else
            return Enumerable.Max(list);
#endif
        }

        public static T ElementAt<T>(this IEnumerable<T> enumerable, int index)
        {
#if UNITY_IOS || UNITY_ANDROID

			var i = 0;
			foreach (var e in enumerable) {
				if (i == index) {
					return e;
				}
				++i;
			}
			throw new ArgumentException("no elemenet at " + index);
			#else
            return Enumerable.ElementAt(enumerable, index);
#endif
        }

        public static T ElementAtOrDefault<T>(this IEnumerable<T> enumerable, int index)
        {
#if UNITY_IOS || UNITY_ANDROID

			var i = 0;
			foreach (var e in enumerable) {
				if (i == index) {
					return e;
				}
				++i;
			}
			return default(T);
			#else
            return Enumerable.ElementAtOrDefault(enumerable, index);
#endif
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var e in enumerable)
            {
                if (!predicate(e))
                {
                    yield break;
                }
                yield return e;
            }
        }

        #endregion

        #region Index

        public static int FirstIndexOf<T>(this IEnumerable<T> list, T obj)
        {
            var comparer = EqualityComparer<T>.Default;
            var i = 0;
            foreach (var element in list)
            {
                if (comparer.Equals(element, obj))
                {
                    return i;
                }
                ++i;
            }
            return -1;
        }

        public static int FirstIndexOf<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            var i = 0;
            foreach (var element in list)
            {
                if (func(element))
                {
                    return i;
                }
                ++i;
            }
            return -1;
        }

        public static int LastIndexOf<T>(this IEnumerable<T> list, T obj)
        {
            var comparer = EqualityComparer<T>.Default;
            var i = 0;
            var index = -1;
            foreach (var element in list)
            {
                if (comparer.Equals(element, obj))
                {
                    index = i;
                }
                i++;
            }
            return index;
        }

        public static int LastIndexOf<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            var i = 0;
            var index = -1;
            foreach (var element in list)
            {
                if (func(element))
                {
                    index = i;
                }
                i++;
            }
            return index;
        }

        public static IEnumerable<int> IndexesOf<T>(this IEnumerable<T> list, T obj)
        {
            var comparer = EqualityComparer<T>.Default;
            var i = 0;
            foreach (var element in list)
            {
                if (comparer.Equals(element, obj))
                {
                    yield return i;
                }
                ++i;
            }
        }

        public static IEnumerable<int> IndexesOf<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            var i = 0;
            foreach (var element in list)
            {
                if (func(element))
                {
                    yield return i;
                }
                ++i;
            }
        }

        #endregion

        #region Min / Max Element

        public static T MinElement<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            var min = default(T);
            var smin = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    min = e;
                    smin = se;
                }
                else if (se.CompareTo(smin) < 0)
                {
                    min = e;
                    smin = se;
                }
            }
            if (!set)
            {
                throw new InvalidOperationException("The source sequence is empty; " +
                                                    "Operation is not valid due to the current state of the object");
            }
            return min;
        }

        public static T MinElementOrDefault<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            var min = default(T);
            var smin = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    min = e;
                    smin = se;
                }
                else if (se.CompareTo(smin) < 0)
                {
                    min = e;
                    smin = se;
                }
            }
            return min;
        }

        public static T MaxElement<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            var max = default(T);
            var smax = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    max = e;
                    smax = se;
                }
                else if (se.CompareTo(smax) > 0)
                {
                    max = e;
                    smax = se;
                }
            }
            if (!set)
            {
                throw new InvalidOperationException("The source sequence is empty; " +
                                                    "Operation is not valid due to the current state of the object");
            }
            return max;
        }

        public static T MaxElementOrDefault<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            var max = default(T);
            var smax = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    max = e;
                    smax = se;
                }
                else if (se.CompareTo(smax) > 0)
                {
                    max = e;
                    smax = se;
                }
            }
            return max;
        }

        #endregion

        #region Except

        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, T execpt)
        {
            var comparer = EqualityComparer<T>.Default;
            foreach (var element in enumerable)
            {
                if (!comparer.Equals(element, execpt))
                {
                    yield return element;
                }
            }
        }

        #endregion

        #region Distinct

        public static IEnumerable<T> Distinct<T, TCompair>(this IEnumerable<T> enumerable, Func<T, TCompair> predicate)
        {
            var list = new List<TCompair>();
            foreach (var e in enumerable)
            {
                var se = predicate(e);
                if (!list.Contains(se))
                {
                    list.Add(se);
                    yield return e;
                }
            }
        }

        public static IEnumerable<TSelect> SelectDistinct<T, TSelect>(this IEnumerable<T> enumerable,
            Func<T, TSelect> predicate)
        {
            var list = new List<TSelect>();
            foreach (var e in enumerable)
            {
                var se = predicate(e);
                if (!list.Contains(se))
                {
                    list.Add(se);
                    yield return se;
                }
            }
        }

        #endregion

        #region Insert to enumerables

        public static IEnumerable<T> InsertToEnd<T>(this IEnumerable<T> enumerable, T element)
        {
            foreach (var e in enumerable)
            {
                yield return e;
            }
            yield return element;
        }

        public static IEnumerable<T> InsertToStart<T>(this IEnumerable<T> enumerable, T element)
        {
            yield return element;
            foreach (var e in enumerable)
            {
                yield return e;
            }
        }

        public static IEnumerable<T> InsertAt<T>(this IEnumerable<T> enumerable, T element, int index)
        {
            var i = 0;
            foreach (var e in enumerable)
            {
                if (i == index)
                {
                    yield return element;
                }
                yield return e;
                i++;
            }
            if (i == index)
            {
                yield return element;
            }
            if (index > i)
            {
                throw new ArgumentException("index " + index + " more than enumerable");
            }
        }

        public static IEnumerable<T> InsertAtWithDefault<T>(this IEnumerable<T> enumerable, T element, int index)
        {
            var i = 0;
            foreach (var e in enumerable)
            {
                if (i == index)
                {
                    yield return element;
                }
                yield return e;
                i++;
            }
            if (i > index)
            {
                yield break;
            }
            while (i < index)
            {
                yield return default(T);
                i++;
            }
            yield return element;
        }

        #endregion

        #region Try

        public static bool TryGetFirst<T>(this IEnumerable<T> enumerable, out T first)
        {
            foreach (var element in enumerable)
            {
                first = element;
                return true;
            }
            first = default(T);
            return false;
        }

        public static bool TryGetFirst<T>(this IEnumerable<T> enumerable, out T first, Func<T, bool> func)
        {
            foreach (var element in enumerable)
            {
                if (func(element))
                {
                    first = element;
                    return true;
                }
            }
            first = default(T);
            return false;
        }

        public static bool TryGetMinElement<T, TResult>(this IEnumerable<T> enumerable, out T max,
            Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            max = default(T);
            var smin = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    max = e;
                    smin = se;
                }
                else if (se.CompareTo(smin) > 0)
                {
                    max = e;
                    smin = se;
                }
            }
            return set;
        }

        public static bool TryGetMaxElement<T, TResult>(this IEnumerable<T> enumerable, out T min,
            Func<T, TResult> func)
            where TResult : IComparable<TResult>
        {
            var set = false;
            min = default(T);
            var smin = default(TResult);
            foreach (var e in enumerable)
            {
                var se = func(e);
                if (!set)
                {
                    set = true;
                    min = e;
                    smin = se;
                }
                else if (se.CompareTo(smin) < 0)
                {
                    min = e;
                    smin = se;
                }
            }
            return set;
        }

        #endregion

        #region ForEach

        private static void SafeForEachReflection<T>(this object enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                return;
            }

            Type listType = enumerable.GetType()
                .GetInterfaces()
                .FirstOrDefault(x => !(x.IsGenericType) && x == typeof(IEnumerable));
            if (listType == null)
            {
                throw new ArgumentException("Object does not implement IEnumerable interface", "enumerable");
            }

            MethodInfo method = listType.GetMethod("GetEnumerator");
            if (method == null)
            {
                throw new InvalidOperationException(
                    "Failed to get 'GetEnumberator()' method info from IEnumerable type");
            }

            IEnumerator enumerator = null;
            try
            {
                enumerator = (IEnumerator) method.Invoke(enumerable, null);
                if (enumerator is IEnumerator)
                {
                    while (enumerator.MoveNext())
                    {
                        action((T) enumerator.Current);
                    }
                }
                else
                {
                    Debug.Log(String.Format("{0}.GetEnumerator() returned '{1}' instead of IEnumerator.",
                        enumerable.ToString(), enumerator.GetType().Name));
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        public static void SafeForEach<T>(this IEnumerable enumerable, Action<T> action)
        {
#if UNITY_IOS
			SafeForEachReflection(enumerable,action);
			/*
			IEnumerator enumerator = enumerable.GetEnumerator();
			if (enumerator == null){
			throw new ArgumentException("enumerable doesn't have enumerator '" + enumerable + "'");
			}
			while (enumerator.MoveNext()){
			action((T)enumerator.Current);
			}
			*/
			#else
            foreach (var e in enumerable)
            {
                action((T) e);
            }
#endif
        }

        public static void SafeForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
#if UNITY_IOS
			SafeForEachReflection(enumerable,action);
			/*
			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			if (enumerator == null){
			throw new ArgumentException("enumerable doesn't have enumerator '" + enumerable + "'");
			}
			while (enumerator.MoveNext()){
			action(enumerator.Current);
			}
			*/
			#else
            foreach (var e in enumerable)
            {
                action(e);
            }
#endif
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var e in enumerable)
            {
                action(e);
            }
        }

        #endregion

        public static IEnumerable<TResult> SelectOfType<TResult>(this IEnumerable enumerable) where TResult : class
        {
            foreach (var element in enumerable)
            {
                var castElement = element as TResult;
                if (castElement != null)
                {
                    yield return castElement;
                }
            }
        }

        public static IEnumerable<TResult> Cast<T, TResult>(this IEnumerable<T> enumerable) where TResult : T
        {
            foreach (var element in enumerable)
            {
                yield return (TResult) element;
            }
        }

        #region Select Not Null 

        public static IEnumerable<T> SelectNotNull<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            foreach (var e in enumerable)
            {
                if (e != null)
                {
                    yield return e;
                }
            }
        }

        public static IEnumerable<TResult> SelectNotNull<T, TResult>(this IEnumerable<T> enumerable,
            Func<T, TResult> selector)
            where TResult : class
        {
            foreach (var e in enumerable)
            {
                var se = selector(e);
                if (se != null)
                {
                    yield return se;
                }
            }
        }

        #endregion
    }
}