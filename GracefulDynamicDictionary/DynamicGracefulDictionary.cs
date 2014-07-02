// See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Dynamic;


namespace GracefulDynamicDictionary
{
	// Based on DynamicViewDataDictionary
	// https://github.com/ASP-NET-MVC/aspnetwebstack/blob/master/src/System.Web.Mvc/DynamicViewDataDictionary.cs
	public class DynamicGracefulDictionary : DynamicObject
	{
		protected GracefulDictionary dictionary = new GracefulDictionary();

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
			result = dictionary[binder.Name];	// Never throws; null if not present
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			dictionary[binder.Name] = value;
			return true;
		}
	}
}
