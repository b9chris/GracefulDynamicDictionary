#Graceful Dynamic Dictionary
A Dynamic object that lets you check for unassigned/non-existent properties by simply checking for null, without throwing or having to use Reflection.

##Usage

	dynamic myObj = new DDict();
	
	if (myObj.SomeProp != null)
	{
		// This code will work even though SomeProp has
		// never been assigned. Doesn't throw.

More:

http://stackoverflow.com/q/2839598/176877

Available on NuGet:

https://www.nuget.org/packages/GracefulDynamicDictionary/

	PM> Install-Package GracefulDynamicDictionary

##Migrating from older versions

An earlier version (1.0) of this library used the much longer class name, `DynamicGracefulDictionary`, as its main class. This has been replaced with `DDict`. To migrate older code that uses this library, just find and replace `DynamicGracefulDictionary` with `DDict`. All calls to it and usage of it will work as-is.

Adapted from Microsoft's ASP.Net MVC DynamicViewDataDictionary. Adapted by Chris Moschini, Brass Nine Design. http://brass9.com/