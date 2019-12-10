using System;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GracefulDynamicDictionary.Tests
{
	[TestClass]
	public class Test
	{
		[TestMethod]
		public void TestMissingPropertyCheck()
		{
			dynamic dynamicObj = new DDict();
			bool hasUnassignedProperty = (dynamicObj.SomeProp != null);
			Assert.IsFalse(hasUnassignedProperty);
		}

		[TestMethod]
		public void TestAssignDynamicProp()
		{
			dynamic dynamicObj = new DDict();
			dynamicObj.SomeProp = "A";
			Assert.AreEqual("A", dynamicObj.SomeProp);
		}
	}
}
