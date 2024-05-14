using System;

class Obj 
{
    /// <summary>
    /// Check if a object if an int or not.
    /// </summary>
    /// <param name="obj">Value to check</param>
    /// <returns>Returns True if the object is an in int; Otherwise, False.</returns>
    public static bool IsOfTypeInt(object obj)
    {
        if (obj is int) {
            return true;
        }

        return false;
    }
}
