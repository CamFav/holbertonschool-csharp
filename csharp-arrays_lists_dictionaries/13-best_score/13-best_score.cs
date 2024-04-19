using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        if (myList.Count == 0)
            return "None";

        // Initialise les variables pour stocker la valeur maximale et la clé associée
        int maxScore = int.MinValue;
        string maxValue = "";

        foreach (var kvp in myList)
        {
            if (kvp.Value > maxScore)
            {
                maxScore = kvp.Value;
                maxValue = kvp.Key;
            }
        }

        return maxValue;
    }
}
