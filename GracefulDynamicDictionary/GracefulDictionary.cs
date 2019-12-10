// See License.txt in the project root for license information.
using System;
using System.Collections.Generic;


namespace GracefulDynamicDictionary
{
	// Based on ASP.Net MVC ViewDataDictionary
	// https://github.com/ASP-NET-MVC/aspnetwebstack/blob/master/src/System.Web.Mvc/ViewDataDictionary.cs
	public class GracefulDictionary<TKey, TValue> : IDictionary<TKey, TValue>
	{
		protected IDictionary<TKey, TValue> internalDictionary;

		public GracefulDictionary()
		{
			internalDictionary = new Dictionary<TKey, TValue>();
		}

		/// <summary>
		/// Creates a GracefulDictionary with a passed-in string/object Dictionary as its internal dictionary.
		/// The internal dictionary will be modified as the GracefulDictionary changes.
		/// </summary>
		public GracefulDictionary(IDictionary<TKey, TValue> basis)
		{
			internalDictionary = basis;
		}



		public TValue this[TKey key]
		{
			get
			{
				// Always return something without throwing. Return null if no value.
				TValue val = default;
				internalDictionary.TryGetValue(key, out val);
				return val;
			}
			set
			{
				internalDictionary[key] = value;
			}
		}

		public bool IsReadOnly
		{
			get { return false; }
		}



		#region internalDictionary pass-through
		public void Add(TKey key, TValue value)
		{
			internalDictionary.Add(key, value);
		}

		public bool ContainsKey(TKey key)
		{
			return internalDictionary.ContainsKey(key);
		}

		public ICollection<TKey> Keys
		{
			get { return internalDictionary.Keys; }
		}

		public bool Remove(TKey key)
		{
			return internalDictionary.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return internalDictionary.TryGetValue(key, out value);
		}

		public ICollection<TValue> Values
		{
			get { return internalDictionary.Values; }
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			((IDictionary<TKey, TValue>)internalDictionary).Add(item);
		}

		public void Clear()
		{
			internalDictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((IDictionary<TKey, TValue>)internalDictionary).Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((IDictionary<TKey, TValue>)internalDictionary).CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return internalDictionary.Count; }
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return ((IDictionary<TKey, TValue>)internalDictionary).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return internalDictionary.GetEnumerator();
		}
		#endregion
	}



	public class GracefulDictionary : GracefulDictionary<string, object>
	{
		public GracefulDictionary()
			: base()
		{ }

		public GracefulDictionary(IDictionary<string, object> basis)
			: base(basis)
		{ }
	}
}
