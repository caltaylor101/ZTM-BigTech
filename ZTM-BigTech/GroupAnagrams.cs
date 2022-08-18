using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    internal class GroupAnagramsClass
    {
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            List<string> emptyStrings = new List<string>();

            // loop through each string
            foreach (string s in strs)
            {
                if (string.IsNullOrEmpty(s)) emptyStrings.Add(s);
                Dictionary<char, int> dict = new Dictionary<char, int>();

                //Add each character to the dictionary
                foreach (var c in s)
                {
                    if (!dict.TryAdd(c, 1))
                    {
                        dict[c] += 1;
                    }
                }

                if (result.Count == 0) result.Add(new List<string>() { s });
                else
                {

                    //Go through each list in the result
                    foreach (var list in result)
                    {
                        //In each list get the character of the first word in the list
                        for (int c = 0; c < list[0].Length; c++)
                        {
                            //if the list contains the key, make sure it has the appropriate amount or break. 
                            if (dict.ContainsKey(list[0][c]))
                            {
                                dict[list[0][c]] -= 1;
                                if (dict[list[0][c]] < 0) break;
                            }
                            else
                            {
                                break;
                            }

                            if (c == list[0].Length - 1)
                            {
                                list.Add(s);
                                goto End;
                            }
                        }



                    }
                    //if it makes it through the list, then we need to add a list to the result. 
                    result.Add(new List<string>() { s });
                }


            End:
                continue;
            }
            if (emptyStrings.Count > 0) result.Add(emptyStrings);
            return result;
        }

        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            List<string> emptyStrings = new List<string>();

            for (int i = 0; i < strs.Length; i++)
            {

                if (string.IsNullOrEmpty(strs[i]))
                {
                    emptyStrings.Add(strs[i]);
                    continue;
                }
                //for each list in the result list
                if (result.Count == 0)
                {
                    result.Add(new List<string>() { strs[i] });
                    continue;
                }

                for (int k = 0; k < result.Count; k++)
                {
                    //Create this here so the list is reset on each iteration. 
                    var compareList = strs[i].ToList();
                    //for each character of the first word in the list
                    for (int c = 0; c < result[k][0].Length; c++)
                    {
                        //If false go to the next list.
                        if(!compareList.Remove(result[k][0][c])) break;

                        //if we got to the end of the word and compareList is empty then add the string to the list in the result list.
                        if (c == result[k][0].Length - 1 && compareList.Count == 0)
                        {
                            result[k].Add(strs[i]);
                            goto End;
                        }
                    }
                }
                result.Add(new List<string>() { strs[i] });
            End:
                continue;
            }

            if (emptyStrings.Count > 0) result.Add(emptyStrings);

            return result;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                string newString = new string(charArray.ToArray());
                if (!dict.TryAdd(newString, new List<string>() { strs[i] }))
                {
                    dict[newString].Add( strs[i] );
                }
            }
            foreach (var pair in dict)
            {
                result.Add(pair.Value);
            }
            return result;
        }

        
    }
}
