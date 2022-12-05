using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int guess = ((right - left) / 2) + left;
                if (nums[guess] == target) return guess;
                else if (nums[guess] < target) left = guess + 1;
                else if (nums[guess] > target) right = guess - 1;
            }

            return -1;
        }

        public int SearchInsert(int[] nums, int target)
        {

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int guess = left + (right - left) / 2;
                if (nums[guess] == target) return guess;
                if (target < nums[guess]) right = guess - 1;
                if (target > nums[guess]) left = guess + 1;
            }

            return left;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> numsHash = new HashSet<int>();

            foreach (var num in nums)
            {
                if (!numsHash.Add(num)) return true;
            }

            return false;
        }

        public int MaxSubArray(int[] nums)
        {
            long maxSum = int.MinValue;
            long sum = 0;
            long minSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                long localMax = (sum - minSum);
                maxSum = Math.Max(localMax, maxSum);

                minSum = Math.Min(sum, minSum);
            }

            return (int)maxSum;
        }

        public long FindNb(long m)
        {
            // your code
            long result = 0;
            long cubeCount = 0;
            long CountCubes(long n)
            {
                if (result == m) return cubeCount;
                if (result > m) return -1;
                result += (long)Math.Pow(n, 3);
                cubeCount++;
                return CountCubes(n + 1);
            }
            return CountCubes(1);

        }

        public int[] SortedSquares(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int index = nums.Length - 1;

            int[] returnArray = new int[nums.Length];

            while (left <= right)
            {
                if (Math.Abs(nums[left]) > nums[right])
                {
                    returnArray[index] = nums[left] * nums[left];
                    index--;
                    left++;
                }
                else
                {
                    returnArray[index] = nums[right] * nums[right];
                    index--;
                    right--;
                }
            }

            return returnArray;

        }

        public void Rotate(int[] nums, int k)
        {
            if (k > nums.Length) k %= nums.Length;

            int[] holderArray = new int[k];
            int holdIndex = 0;
            int storedValue = 0;

            int[] copyArray = nums.ToArray();

            for (int i = nums.Length - k; i < nums.Length; i++)
            {
                holderArray[holdIndex] = nums[i];
                holdIndex++;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + k < nums.Length)
                {
                    nums[i + k] = copyArray[i];
                }
            }

            for (int i = 0; i < holderArray.Length; i++)
            {
                nums[i] = holderArray[i];
            }

        }

        public void Rotate2(int[] nums, int k)
        {
            if (k > nums.Length) k %= nums.Length;

            int leftIndex = 0;
            int rightIndex = k;

            int temp = 0;
            int temp2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                temp = nums[leftIndex];
                temp2 = nums[rightIndex];

                nums[rightIndex] = temp;
                leftIndex++;


            }

        }

        public int[] TwoSum(int[] nums, int target)
        {
            int[] copyArray = nums.ToArray();
            Array.Sort(copyArray);
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int result = copyArray[left] + copyArray[right];

                if (result > target)
                {
                    int current = copyArray[right];
                    while (copyArray[right] == current)
                    {
                        right--;
                    }
                    continue;
                }
                else if (result < target)
                {
                    int current = copyArray[left];
                    while (copyArray[left] == current)
                    {
                        left++;
                    }
                    continue;
                }
                else
                {
                    if (copyArray[left] == copyArray[right])
                    {
                        left = Array.FindIndex(nums, x => x == copyArray[left]);
                        right = Array.FindLastIndex(nums, x => x == copyArray[right]);
                    }
                    else
                    {
                        left = Array.FindIndex(nums, x => x == copyArray[left]);
                        right = Array.FindIndex(nums, x => x == copyArray[right]);
                    }

                    return new int[] { left, right };
                }
            }
            return new int[0];
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int test = target - nums[i];
                if (dict.ContainsKey(test)) return new int[] { dict[test], i };
                dict.TryAdd(nums[i], i);
            }

            return new int[0];
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            int[] smallArray = (nums1.Length < nums2.Length) ? nums1 : nums2;
            int[] largeArray = (nums2.Length > nums1.Length) ? nums2 : nums1;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> returnList = new List<int>();

            foreach (var num in smallArray)
            {
                if (!dict.TryAdd(num, 1)) dict[num] += 1; 
            }

            foreach (var num in largeArray)
            {
                if (dict.ContainsKey(num) && dict[num] > 0)
                {
                    dict[num] -= 1;
                    returnList.Add(num);
                }
            }

            return returnList.ToArray();
        }

        public class BinaryNode
        {
            public BinaryNode left;
            public BinaryNode right;
            public int value;

            public BinaryNode(int value, BinaryNode left, BinaryNode right)
            {
                this.left = left;
                this.right = right;
                this.value = value;
            }
        }
        public BinaryNode MyBinaryTreeFunction(BinaryNode head)
        {
            if (head.left == null && head.right == null) return null;

            DFS(head);

            return head;
        }
        private int DFS(BinaryNode node)
        {
            if (node == null) return 0;
            if (node.left == null && node.right == null)
            {
                return -1;
            }

            if (DFS(node.left) == -1) node.left = null;
            if (DFS(node.right) == -1) node.right = null;

            return 0;
        }

        public void MoveZeroes(int[] nums)
        {
            int rightIndex = nums.Length - 1;

            while (rightIndex >= 0 && nums[rightIndex] == 0 )
            {
                rightIndex--;
            }

            for (int i = 0; i < rightIndex; i++)
            {
                if (nums[i] == 0)
                {
                    for (int k = i; k < rightIndex; k++)
                    {
                        if (k + 1 < nums.Length)
                        {
                            (nums[k], nums[k + 1]) = (nums[k + 1], nums[k]);
                        }
                    }
                    rightIndex--;
                    i--;
                }
            }
        }

        public void MoveZeroes2(int[] nums)
        {
            int rightIndex = nums.Length;
            int countZeroes = 0;
            int rightCount = 0;

            while (rightIndex - 1 >= 0 && nums[rightIndex - 1] == 0)
            {
                rightCount++;
                rightIndex--;
            }

            for (int i = 0; i < rightIndex; i++)
            {
                if (nums[i] == 0) countZeroes++;
                else if (countZeroes > 0) nums[i - countZeroes] = nums[i];
            }

            for (int i = nums.Length - countZeroes - rightCount; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }

        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                (s[left], s[right]) = (s[right], s[left]);
                left++; 
                right--;
            }

        }

        public string ReverseWords(string s)
        {
            int left = 0;
            int right = 0;

            char[] returnString = s.ToCharArray();

            for (int i = 0; i < returnString.Length; i++)
            {
                if (returnString[i] == ' ')
                {
                    right = i - 1;
                    ReverseWord(ref left, ref right, returnString);
                    if (i + 1 < returnString.Length) left = i + 1;
                }
                else if (i == s.Length - 1)
                {
                    right = i;
                    ReverseWord(ref left, ref right, returnString);
                }
            }
            return new string(returnString);
        }

        private static void ReverseWord(ref int left, ref int right, char[] returnString)
        {
            while (left < right)
            {
                (returnString[left], returnString[right]) = (returnString[right], returnString[left]);
                left++;
                right--;
            }
        }
    }
}
