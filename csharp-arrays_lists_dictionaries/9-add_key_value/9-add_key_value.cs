using System;
using System.Collections.Generic;

class Dictionary
{
    public static Dictionary<string, string> AddKeyValue(Dictionary<string, string> myDict, string key, string value)
    {
        // If the key already exists, update its value
        if (myDict.ContainsKey(key))
        {
            myDict[key] = value;
        }
        // If the key doesn't exist, add it with the given value
        else
        {
            myDict.Add(key, value);
        }

        return myDict;
    }
}
