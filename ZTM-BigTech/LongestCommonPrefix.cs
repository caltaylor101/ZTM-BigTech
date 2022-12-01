using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class LongestCommonPrefix
    {
        public string LongestCommonsPrefix(string[] strs)
        {
            string longestPrefix = strs[0];
            foreach (var str in strs)
            {
                if (str.Length == 0) return "";
                if (str[0] != longestPrefix[0]) return "";
                StringBuilder newPrefix = new StringBuilder();
                int maxLength = Math.Min(str.Length, longestPrefix.Length);
                newPrefix.Append(str[0]);

                for (int i = 1; i < maxLength; i++)
                {
                    if (str[i] == longestPrefix[i])
                    {
                        newPrefix.Append(str[i]);
                    }

                    else
                    {
                        
                        break;
                    }
                }
                longestPrefix = newPrefix.ToString();
                newPrefix.Clear();
            }
            return longestPrefix;
        }
    }
}
