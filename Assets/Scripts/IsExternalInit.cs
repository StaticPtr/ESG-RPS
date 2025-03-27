namespace System.Runtime.CompilerServices
{
	//Allows the usage of the "init" keyword and records
	[AttributeUsage(AttributeTargets.All)]
	public class IsExternalInit : Attribute
	{
	}
}