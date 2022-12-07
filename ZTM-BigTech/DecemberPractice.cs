using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class DecemberPractice
    {
        public int MaxProfit(int[] prices)
        {
            int low = prices[0];
            int high = prices[0];
            int max = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] <= low)
                {
                    low = prices[i];
                    high = low;
                }
                else if (prices[i] > high)
                {
                    high = prices[i];
                    max = Math.Max(max, high - low);
                }
            }
            return max;
        }

        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int[][] returnMatrix = new int[r][];
            for (int i = 0; i < returnMatrix.Length; i++) returnMatrix[i] = new int[c];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int k = 0; k < mat[0].Length; k++)
                {
                    queue.Enqueue(mat[i][k]);
                }
            }
            for (int i = 0; i < returnMatrix.Length; i++)
            {
                for (int k = 0; k < returnMatrix[0].Length; k++)
                {
                    if (!queue.TryDequeue(out returnMatrix[i][k])) return mat;
                }
            }
            return (queue.Count == 0) ? returnMatrix : mat;

        }


        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> returnList = new List<IList<int>>();
            returnList.Add(new List<int>() { 1 });
            if (numRows == 1) return returnList;

            List<int> lastList = new List<int>() { 1, 1 };
            returnList.Add(lastList);
            if (numRows == 2) return returnList;


            for (int i = 3; i <= numRows; i++)
            {
                List<int> nextList = new List<int>();
                nextList.Add(1);
                for (int k = 0; k < lastList.Count; k++)
                {
                    if (k + 1 < lastList.Count) nextList.Add(lastList[k] + lastList[k + 1]);
                }
                nextList.Add(1);
                returnList.Add(nextList);
                lastList = nextList;
            }

            return returnList;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int guess = numbers[left] + numbers[right];
                if (guess == target) return new int[] { left + 1, right + 1 };
                else if (guess > target)
                {
                    int currentRight = numbers[right];
                    while (right >= 0 && numbers[right] == currentRight) right--;

                }
                else
                {
                    int currentLeft = numbers[left];
                    while (left < numbers.Length && numbers[left] == currentLeft) left++;
                }
            }
            return new int[0];
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode MiddleNode(ListNode head)
        {
            if (head.next == null) return head;
            if (head.next.next == null) return head.next;
            ListNode chaser = head;
            ListNode runner = head.next.next;
            bool isEven = false;

            while (runner != null)
            {
                if (runner.next != null)
                {
                    runner = runner.next.next;
                    chaser = chaser.next;
                }
                else
                {
                    isEven = true;
                    runner = runner.next;
                    chaser = chaser.next;
                }
            }

            return (isEven) ? chaser : chaser.next;
        }


        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null) return null;

            ListNode chaser = head;
            ListNode runner = head;

            while (runner != null)
            {
                runner = runner.next;
                if (n < 0) chaser = chaser.next;
                else n--;
            }

            if (n == 0) return head.next;

            chaser.next = chaser.next.next;

            return head;
        }

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> subSet = new Dictionary<char, int>();
            int maxCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!subSet.TryAdd(s[i], i))
                {
                    maxCount = Math.Max(subSet.Count, maxCount);
                    i = subSet[s[i]] + 1;
                    subSet.Clear();
                    subSet.Add(s[i], i);
                }
            }
            maxCount = Math.Max(subSet.Count, maxCount);
            return maxCount;
        }

        public bool CheckInclusion2(string s1, string s2)
        {
            Dictionary<char, int> baseDictionary = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!baseDictionary.TryAdd(s1[i], 1))
                {
                    baseDictionary[s1[i]] += 1;
                }
            }
            Dictionary<char, int> testDictionary = new Dictionary<char, int>(baseDictionary);
            bool isDictTouched = false;
            int permutationIndex = 0;
            for (int i = 0; i < s2.Length; i++)
            {
                // Check to see if character exists in dictionary
                if (testDictionary.ContainsKey(s2[i]))
                {
                    // If it does, touch the dictionary and set index
                    if (!isDictTouched)
                    {
                        isDictTouched = true;
                        permutationIndex = i;
                    }
                    // remove a reference in the dictionary
                    testDictionary[s2[i]] -= 1;
                    // remove if 0
                    if (testDictionary[s2[i]] == 0) testDictionary.Remove(s2[i]);
                    // return true when dictionary is empty. 
                    if (testDictionary.Count == 0) return true;
                }
                // If dictionary isn't touched continue
                else if (!testDictionary.ContainsKey(s2[i]) && !isDictTouched)
                {
                    continue;
                }
                else
                {
                    // If the permutationIndex value equals the failed value, increase premutation index. 
                    if (s2[permutationIndex] == s2[i])
                    {
                        permutationIndex++;
                    }
                    else
                    {
                        // Otherwise, increase until we find where it broke. 
                        while (s2[permutationIndex] != s2[i])
                        {
                            permutationIndex++;
                        }
                    }
                    // Reset the test dictionary
                    testDictionary = new Dictionary<char, int>(baseDictionary);
                    // slide back to the beginning of the window and continue
                    if (permutationIndex > 0) i = permutationIndex - 1;
                    // fresh so the dictionary is not touched. 
                    isDictTouched = false; 
                }
            }
            return false;
        }


        public bool CheckInclusion3(string s1, string s2)
        {
            // Create a Dictionary to keep a reference of s1. 
            Dictionary<char, int> baseDictionary = new Dictionary<char, int>();
            // Create a hashset to verify the char exists in the string. 
            HashSet<char> referenceChar = new HashSet<char>();

            // Add s1 to both dictionary and hashset. 
            for (int i = 0; i < s1.Length; i++)
            {
                if (!baseDictionary.TryAdd(s1[i], 1)) baseDictionary[s1[i]] += 1;
                referenceChar.Add(s1[i]);
            }

            // A reference index to move back to. 
            int refIndex = 0;
            // A boolean to speed things up. 
            bool isDictTouched = false;

            for (int i = 0; i < s2.Length; i++)
            {
                if (baseDictionary.ContainsKey(s2[i]))
                {
                    // Set the reference to where we started checking the string. 
                    if (!isDictTouched)
                    {
                        isDictTouched = true;
                        refIndex = i;
                    }
                    // Remove the count of characters in the dictionary. 
                    baseDictionary[s2[i]] -= 1;
                    // Remove the character if there are no matches left. 
                    if (baseDictionary[s2[i]] == 0) baseDictionary.Remove(s2[i]);
                    // Return true if our dictionary is empty. 
                    if (baseDictionary.Count == 0) return true; 
                }
                // if the refIndex hasn't been set, skip all characters that don't match. 
                else if (!baseDictionary.ContainsKey(s2[i]) && !isDictTouched) continue;
                else
                {
                    // If the index we start on is the same as the index we are currently checking, we can increase the reference index and skip it. 
                    // Consider, [a, b, c, f] [ a, b, c, a, b, a]
                    // When we remove a, b, and c from the dictionary, and then a comes up again, the string is still a permutation. 
                    // We don't need to change anything, just increase our starting index since we know that b and c have already been seen. 
                    if (s2[refIndex] == s2[i])
                    {
                        refIndex++;
                        continue; 
                    }

                    // Check if our reference sheet contains the next element. 
                    if (referenceChar.Contains(s2[i]))
                    {
                        while (s2[refIndex] != s2[i])
                        {
                            // Add everything back as we know they already exist. 
                            if (!baseDictionary.TryAdd(s2[refIndex], 1)) baseDictionary[s2[refIndex]] += 1;
                            refIndex++;
                        }
                        // Move the reference to be synced with s2[i] as we know it exists in the reference hash. 
                        refIndex++; 
                    }
                    // Otherwise, if the reference hash doesn't contain the character. 
                    else
                    {
                        // Add everything back to the dictionary. 
                        while (s2[refIndex] != s2[i])
                        {
                            if (!baseDictionary.TryAdd(s2[refIndex], 1)) baseDictionary[s2[refIndex]] += 1;
                            refIndex++;
                        }
                        // Dictionary is reset at this point, so untouch the variable.  
                        isDictTouched = false; 
                    }
                }
            }
            return false; 
        }

        public bool CheckInclusion4(string s1, string s2)
        {
            // left and right pointers
            int left = 0;
            int right = 0;
            // Length to reduce calculations in while loop. 
            int s1Length = s1.Length - 1;
            // Dictionary to hold s1 by character and count of characters.
            Dictionary<char, int> dict = new Dictionary<char, int>();
            // Put s1 into the dictionary
            foreach (char character in s1)
            {
                if (!dict.TryAdd(character, 1)) dict[character] += 1;
            }

            while (right < s2.Length)
            {
                if (dict.ContainsKey(s2[right]))
                {
                    // Subtract the count of the key we found
                    dict[s2[right]] -= 1;

                    // If it's less than 0, we need to move left up. 
                    if (dict[s2[right]] < 0)
                    {
                        // If it's the same value as our left index, we just need to increase it once. 
                        if (s2[left] == s2[right])
                        {
                            left++;
                            // Add the value back to the dictionary to make it 0. 
                            dict[s2[right]] += 1;
                        }  
                        else
                        {
                            // Otherwise, we want to find the next time the values equal. 
                            while (s2[left] != s2[right])
                            {
                                // All the values in between have already been verified. 
                                // Add the count of these values back as we move our index left. 
                                dict[s2[left]] += 1;
                                left++;
                            }
                            // After this while loop, we are in the same spot as the condition above: s2[left] == s2[right]
                            left++;
                            dict[s2[right]] += 1;

                        }
                    }
                }
                else
                {
                    // If the character doesn't exist in the dictionary, we reset the dictionary by bringing left up to right. 
                    while (left != right)
                    {
                        dict[s2[left]] += 1;
                        left++;
                    }
                    // Skip the current right value, because it doesn't exist in the dictionary. 
                    left = right + 1;
                }
                // If our window is the same size as the string, we know it is a permutation. 
                if (right - left == s1Length) return true;

                right++;
            }

            return false; 
        }


        public bool CheckInclusion(string s1, string s2)
        {
            int l = 0;
            int r = 0;
            int sL = s1.Length - 1;
            int s2L = s2.Length - 1;
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (!d.TryAdd(c, 1)) d[c] += 1;
            }
            while (r < s2.Length)
            {
                if (d.ContainsKey(s2[r]))
                {
                    d[s2[r]] -= 1;
                    if (d[s2[r]] < 0)
                    {
                        if (s2[l] == s2[r])
                        {
                            l++;
                            d[s2[r]] += 1;
                        }
                        else
                        {
                            while (s2[l] != s2[r])
                            {
                                d[s2[l]] += 1;
                                l++;
                            }
                            d[s2[l]] += 1;
                            l++;
                        }
                    }
                }
                else
                {
                    while (l != r)
                    {
                        d[s2[l]] += 1;
                        l++;
                    }
                    l = r + 1;
                }
                if (r - l == sL) return true;
                if (s2L - l < sL) return false;
                r++;
            }

            return false;
        }

        public bool SearchMatrix2(int[][] matrix, int target)
        {
            int up = 0;
            int down = matrix.Length - 1;
            while (up < down)
            {
                int guess = up + (down - up) / 2;

                if (matrix[guess][0] == target) return true;
                if (target < matrix[guess][0]) down = guess - 1;
                else up = guess + 1; 
            }

            if (matrix[up][0] > target) up--;
            if (up < 0) return false;

            int left = 0;
            int right = matrix[up].Length - 1;

            while (left <= right)
            {
                int guess = left + (right - left) / 2;

                if (matrix[up][guess] == target) return true;
                else if (target < matrix[up][guess]) right = guess - 1;
                else left = guess + 1;
            }

            return false;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int up = 0;
            int down = matrix.Length - 1;
            while (up < down)
            {
                int guess = up + (down - up) / 2;

                if (matrix[guess][0] == target) return true;
                if (target < matrix[guess][0]) down = guess - 1;
                else up = guess + 1;
            }
            if (matrix[up][0] > target) up--;
            if (up < 0) return false;
            return (Array.BinarySearch(matrix[up], target) < 0) ? false : true;
        }

        public int FirstUniqChar(string s)
        {
            Dictionary<char,int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.TryAdd(s[i], 1)) dict[s[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1) return i;
            }
            return -1; 
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length) return false;

            Dictionary<char, int> magazineDict = new Dictionary<char, int>();

            foreach (char letter in magazine)
            {
                if (!magazineDict.TryAdd(letter, 1)) magazineDict[letter]++;
            }
            foreach (char letter in ransomNote)
            {
                if (magazineDict.ContainsKey(letter))
                {
                    if (magazineDict[letter] == 0) return false;
                    magazineDict[letter]--;
                }
                else return false; 
            }

            return true; 

        }

        public bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char letter in s) if (!dict.TryAdd(letter, 1)) dict[letter]++;
            foreach (char letter in t)
            {
                if (dict.ContainsKey(letter))
                {
                    if (dict[letter] == 0) return false;
                    dict[letter]--;
                }
                else return false; 
            }
            return true; 

        }

        public bool IsAnagram3(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.TryAdd(s[i], 1)) dict[s[i]]++; 
                if (!dict.TryAdd(t[i], -1)) dict[t[i]]--;
            }

            foreach (var key in dict)
            {
                if (key.Value != 0) return false;
            }

            return true;

        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            Dictionary<char, int> d = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!d.TryAdd(s[i], 1)) d[s[i]]++;
                if (!d.TryAdd(t[i], -1)) d[t[i]]--;
            }
            foreach (var k in d) if (k.Value != 0) return false;
            return true;
        }

        public bool HasCycle2(ListNode head)
        {
            if (head == null) return false; 
            HashSet<ListNode> hash = new HashSet<ListNode>(); 
            while (head != null)
            {
                if (!hash.Add(head)) return true; 
                head = head.next;
            }
            return false; 
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode chaser = head;
            ListNode runner = head;
            while (runner != null)
            {
                chaser = chaser.next;
                if (runner?.next != null) runner = runner.next.next;
                else return false;
                if (runner == chaser) return true;
            }
            return false;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;
            ListNode returnHead = (list1.val <= list2.val) ? list1 : list2;
            ListNode newHead = new ListNode(1, null); 

            while (list1 != null || list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    newHead.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    newHead.next = list2;
                    list2 = list2.next; 
                }
                newHead = newHead.next; 
            }
            return returnHead;
        }

        public ListNode RemoveElements2(ListNode head, int val)
        {
            if (head == null) return head;

            ListNode chaser = head;

            while (chaser != null && chaser.val == val)
            {
                chaser = chaser.next;
            }

            if (chaser == null || chaser.next == null) return chaser; 

            ListNode returnHead = chaser;
            ListNode runner = chaser.next; 

            while (runner != null)
            {
                if (runner.val == val)
                {
                    while (runner?.val == val)
                    {
                        runner = runner.next;
                    }
                    chaser.next = runner;
                    runner = runner?.next;
                    chaser = chaser.next;
                }
                else
                {
                    chaser = chaser.next;
                    runner = runner.next;
                }
            }

            return returnHead; 
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return head;

            ListNode chaser = head;
            ListNode runner = chaser.next;

            while (runner != null)
            {
                if (runner.val == val)
                {
                    while (runner?.val == val)
                    {
                        runner = runner.next;
                    }
                    chaser.next = runner;
                    runner = runner?.next;
                    chaser = chaser.next;
                }
                else
                {
                    chaser = chaser.next;
                    runner = runner.next;
                }
            }

            if (chaser.val == val) chaser = null; 

            return head;
        }

    }

}
