using System;
using System.Collections.Generic;

public class Dictionary
{
    public static void PrintSorted(Dictionary<string, string> myDict)
    {
        // Sort the keys directly
        List<string> sortedKeys = new List<string>(myDict.Keys);
        sortedKeys.Sort();


        foreach (string key in sortedKeys)
        {
            Console.WriteLine("{0}: {1}", key, myDict[key]);
        }
    }
}
