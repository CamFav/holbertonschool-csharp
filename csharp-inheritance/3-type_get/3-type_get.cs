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

        Console.WriteLine($"{objType.Name} Properties:");

        // Iterate throught both properties and methods
        foreach (PropertyInfo properties in objType.GetProperties())
        {
            Console.WriteLine(properties.Name);
        }

        Console.WriteLine($"{objType.Name} Methods:");
        foreach (MethodInfo methods in objType.GetMethods())
        {
            Console.WriteLine(methods.Name);
        }
    }
}
