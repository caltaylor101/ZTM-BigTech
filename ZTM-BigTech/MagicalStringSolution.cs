using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class MagicalStringSolution
    {
        public string[] FindWords(string[] words)
        {
            HashSet<char> topRow = new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            HashSet<char> midRow = new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            HashSet<char> bottomRow = new HashSet<char> { 'z','x','c', 'v', 'b', 'n', 'm' };

            List<string> listToReturn = new List<string>();

            foreach (string word in words)
            {
                bool top = false;
                bool mid = false;
                bool isOnRow = false;
                int wordLength = word.Length - 1;

                if (topRow.Contains(char.ToLower(word[0]))) top = true;
                else if (midRow.Contains(char.ToLower(word[0]))) mid = true;
                
                for (int i = 1; i <= wordLength; i++)
                {
                    if (top)
                    {
                        if (!topRow.Contains(char.ToLower(word[i]))) break; 
                        if (i == wordLength) isOnRow = true;
                    }
                    else if (mid)
                    {
                        if (!midRow.Contains(char.ToLower(word[i]))) break;
                        if (i == wordLength) isOnRow = true;
                    }
                    else 
                    {
                        if (!bottomRow.Contains(char.ToLower(word[i]))) break;
                        if (i == wordLength) isOnRow = true;
                    }
                }
                if (word.Length == 1) listToReturn.Add(word);
                if (isOnRow) listToReturn.Add(word);

            }
            return listToReturn.ToArray();
        }
    }
}
