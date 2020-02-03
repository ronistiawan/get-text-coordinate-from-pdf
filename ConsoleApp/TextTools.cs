using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp
{
    public class TextTools
    {
        public static int SearchForChar(char[] substring, char[] fulltext)
        {
            var indices = fulltext.Select((b, i) => b == substring.FirstOrDefault() ? i : -1)
                                  .Where(i => i != -1).ToArray();

            foreach (var index in indices)
            {
                var found = false;
                int count = 0;
                for (int i = index; i < index + substring.Length; i++)
                {
                    if (substring[count++] == fulltext[i])
                    {
                        found = true;
                        break;
                    }
                }
                if (found) return index;
            }
            return -1;
        }

        public static (int , int) SearchForStringInStringArray(string stringToFind, string[] fulltext)
        {
            var indices = fulltext.Select((b, i) => b.Contains(stringToFind.ToCharArray().FirstOrDefault()) ? i : -1)
                                  .Where(i => i != -1).ToArray();

            foreach (var firstIndex in indices)
            {
                var found = false;
                var combinedString = "";
                int lastIndex = -1;
                int i = 0;
                while (combinedString.Length < stringToFind.Length + 5)
                {
                    lastIndex = firstIndex + i;

                    if (lastIndex > fulltext.Length - 1) break;

                    combinedString += fulltext[lastIndex];
                    if (combinedString.Contains(stringToFind))
                    {
                        found = true;
                        break;
                    }
                    i++;
                }
                if (found) return (firstIndex, lastIndex);
            }
            return (-1,-1);
        }
    }
}
