#Graceful Dynamic Dictionary
A simple repo for a Dynamic object that lets you check for unassigned/non-existent properties by simply checking for null, without throwing or having to use Reflection.

##Usage

	dynamic myObj = new DynamicGracefulDictionary();
	
	if (myObj.SomeProp != null)
	{
		// This code will work even though SomeProp has
		// never been assigned. Doesn't throw.

More:

http://stackoverflow.com/q/2839598/176877

Available on NuGet:

https://www.nuget.org/packages/GracefulDynamicDictionary/

	PM> Install-Package GracefulDynamicDictionary

Adapted from Microsoft's ASP.Net MVC DynamicViewDataDictionary, adapted by Chris Moschini, Brass Nine Design. http://brass9.com/