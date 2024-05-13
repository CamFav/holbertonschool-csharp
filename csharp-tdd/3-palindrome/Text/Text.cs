using System;

namespace Text
{
    public static class Str
    {
        /// <summary>
        /// Determines whether a string is a palindrome.
        /// </summary>
        /// <param name="s">The string to check for palindrome.</param>
        /// <returns>True if the string is a palindrome. Otherwise, false.</returns>
        public static bool IsPalindrome(string s)
        {
            /// <summary>
            s = s.ToLower();

            int start = 0; // First letter
            int end = s.Length - 1; // Last letter

            while (start < end)
            {
                // Ignore punctuation
                while (start < end && !char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }
                while (start < end && !char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }

                // Verify if remaining char are equals, if not, return False
                if (s[start] != s[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            // Or True
            return true;
        }
    }
}

// Another Way : 
// string cleanedString = new string(s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray());
// return cleanedString == new string(cleanedString.Reverse().ToArray());