// See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace GracefulDynamicDictionary
{
	public class DDict : DynamicObject
	{
		protected GracefulDictionary dictionary;

		public DDict()
		{
			dictionary = new GracefulDictionary();
		}

		/// <summary>
		/// Creates a DDict with a passed-in string/object Dictionary as its internal dictionary.
		/// The internal dictionary will be modified as the DDict changes.
		/// </summary>
		public DDict(IDictionary<string, object> basis)
		{
			dictionary = new GracefulDictionary(basis);
		}



		public GracefulDictionary GetDictionary()
		{
			return dictionary;
		}

		// Implementing this function improves the debugging experience as it provides the debugger with the list of all
		// the properties currently defined on the object
		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return dictionary.Keys;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = dictionary[binder.Name];   // Never throws; null if not present
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			dictionary[binder.Name] = value;
			return true;
		}
	}
}
