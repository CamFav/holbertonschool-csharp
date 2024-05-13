using System;
using System.Collections.Generic;

namespace Text
{
    public static class Str
    {
        /// <summary>
        /// Returns the first non-repeating char of a string.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Index of first non-repeating char; otherwise, return -1</returns>
        public static int UniqueChar(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                // Add the character to the dictionary with a count of 1 if the char 
                // has not been found already in the dictionary.
                else
                {
                    charCount[c] = 1;
                }
            }

            // Iterate through the string to find the first character with a count of 1
            for (int i = 0; i < s.Length; i++)
            {
                // Return the index of the first non-repeating character.
                if (charCount[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}