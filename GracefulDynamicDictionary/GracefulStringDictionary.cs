// See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GracefulDynamicDictionary
{
	/// <summary>
	/// All the semantics of GracefulDictionary, but guarantees strings on both key and value.
	/// Essentially a FormCollection or NameValueCollection, but participates better in JSON serialization and
	/// generics operations.
	/// </summary>
	public class GracefulStringDictionary : GracefulDictionary<string, string>
	{
		public GracefulStringDictionary()
			: base()
		{ }

		public GracefulStringDictionary(IDictionary<string, string> basis)
			: base(basis)
		{ }

		#region Conversions
		/// <summary>
		/// NameValueCollection, and its subclass, FormCollection, are commonly seen
		/// in older ASP.Net framework code, and in the default Post to an MVC Controller that doesn't
		/// use AJAX or explicitly named parameters. NameValueCollection converts to JSON poorly, just listing
		/// the keys in an array with no values.
		/// </summary>
		/// <param name="coll"></param>
		public GracefulStringDictionary(System.Collections.Specialized.NameValueCollection coll)
			: base()
		{
			var keys = coll.AllKeys;
			foreach (var key in keys)
				Add(key, coll[key]);
		}

		public System.Collections.Specialized.NameValueCollection ToNameValueCollection()
		{
			var coll = new System.Collections.Specialized.NameValueCollection(this.Count);
			foreach (var kv in this)
			{
				coll[kv.Key] = kv.Value;
			}
			return coll;
		}
		#endregion
	}
}
