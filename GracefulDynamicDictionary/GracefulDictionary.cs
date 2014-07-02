// See License.txt in the project root for license information.
using System;
using System.Collections.Generic;


namespace GracefulDynamicDictionary
{
	// Based on ASP.Net MVC ViewDataDictionary
	// https://github.com/ASP-NET-MVC/aspnetwebstack/blob/master/src/System.Web.Mvc/ViewDataDictionary.cs
	public class GracefulDictionary : IDictionary<string, object>
	{
		protected Dictionary<string, object> internalDictionary = new Dictionary<string, object>();



		public object this[string key]
		{
			get
			{
				// Always return something without throwing. Return null if no value.
				object val = null;
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
		public void Add(string key, object value)
		{
			internalDictionary.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return internalDictionary.ContainsKey(key);
		}

		public ICollection<string> Keys
		{
			get { return internalDictionary.Keys; }
		}

		public bool Remove(string key)
		{
			return internalDictionary.Remove(key);
		}

		public bool TryGetValue(string key, out object value)
		{
			return internalDictionary.TryGetValue(key, out value);
		}

		public ICollection<object> Values
		{
			get { return internalDictionary.Values; }
		}

		public void Add(KeyValuePair<string, object> item)
		{
			internalDictionary.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			internalDictionary.Clear();
		}

		public bool Contains(KeyValuePair<string, object> item)
		{
			return internalDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			internalDictionary.ToArray().CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return internalDictionary.Count; }
		}

		public bool Remove(KeyValuePair<string, object> item)
		{
			return Remove(item);
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return internalDictionary.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return internalDictionary.GetEnumerator();
		}
		#endregion
	}
}
