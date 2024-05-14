using System;

class Obj 
{
    /// <summary>
    /// Check if the object is an instance
    /// </summary>
    /// <param name="obj">Value to check</param>
    /// <returns>Returns True if the object is an instance; Otherwise, False.</returns>
    public static bool IsInstanceOfArray(object obj)
    {
        if (obj is Array || obj.GetType() == typeof(Array))
            return true;

        return false;
    }
}
