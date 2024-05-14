using System;

class Obj 
{
    /// <summary>
    /// Check if the object is a subclass
    /// </summary>
    /// <param name="derivedType">Derived Class</param>
    /// <param name="baseType">Base Class</param>
    /// <returns>Returns True if the object is an subclass; Otherwise, False.</returns>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return baseType.IsAssignableFrom(derivedType) && derivedType != baseType;
    }   
}
