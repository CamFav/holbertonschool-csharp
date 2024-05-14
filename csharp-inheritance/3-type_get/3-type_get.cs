using System;
using System.Reflection;

class Obj 
{
    /// <summary>
    /// Prints the name of available properties and methods of an object
    /// </summary>
    /// <param name="myObj">Object to print</param>
    public static void Print(object myObj)
    {
        Type objType = myObj.GetType();

        Console.WriteLine($"{objType.Name} Properties and Methods:");

        // Iterate throught both properties and methods
        foreach (MemberInfo member in objType.GetMembers())
        {
            Console.WriteLine(member.Name);
        } 
    }
}
