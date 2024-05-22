using System;
using System.Collections.Generic;

namespace Text
{
    public static class Str
    {
        /// <summary>
        /// Determines how many words are in a string.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Index of first non-repeating char; otherwise, return -1</returns>
        public static int CamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int wordCount = 1; // The first word

            foreach (char c in s)
            {
                if (char.IsUpper(c))
                {
                    wordCount++;
                }
            }

            return wordCount;
        }
    }
}
