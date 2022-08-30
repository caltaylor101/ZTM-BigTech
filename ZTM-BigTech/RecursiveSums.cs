using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class RecursiveSums
    {
        //Initialize list to return that multiple methods can use.
        private List<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> RecursiveSum(int[] nums, int target, int variableCount)
        {
            //Sort the array
            Array.Sort(nums);
            //Accounts for nums.length constraint
            if (nums.Length < 4) return result;
            //Initialize an index.
            int index = 0;
            while (index < nums.Length)
            {
                RecurseSumMethod(nums, target, variableCount - 1, index + 1, new List<long>() { nums[index] });
                int tmpVar = nums[index];
                while (index < nums.Length && tmpVar == nums[index])
                {
                    index++;
                }
            }

            return result;
        }

        private void RecurseSumMethod(int[] nums, int target, int variableCount, int index, List<long> offsetList)
        {
            long offset = 0;
            try
            {
                offset = nums[index];
            }
            catch
            {
                return;
            }

            if (variableCount > 3)
            {
                while (index < nums.Length)
                {
                    offsetList.Add(nums[index]);
                    RecurseSumMethod(nums, target, variableCount - 1, index + 1, offsetList);
                    int tmpVar = nums[index];
                    while (index < nums.Length && tmpVar == nums[index])
                    {
                        index++;
                    }
                }
            }
            else
            {
                ThreeSumEnd(nums, target, offsetList, index + 1);
            }
            //Find the next unique value. 
            while (index < nums.Length && offset == nums[index])
            {
                index++;
            }

        }

        //A ThreeSum method to calculate the 4sum. 
        private void ThreeSumEnd(int[] nums, int target, List<long> offsetList, int offsetIndex)
        {
            int index = offsetIndex;
            while (index < nums.Length)
            {
                int left = index + 1;
                int right = nums.Length - 1;

                while (left <= right)
                {
                    Console.WriteLine("stuck");
                    long offsetSum = offsetList.Sum();
                    long sum = offsetSum + nums[left] + nums[right] + nums[index];
                    Console.WriteLine(sum);
                    if (sum < target) left++;
                    else if (sum > target) right--;
                    else
                    {
                        //Add each of our values as a list to the result list.
                        List<int> addList = new List<int>() { nums[left], nums[right], nums[index] };
                        foreach (long value in offsetList)
                        {
                            addList.Add((int)value);
                        }
                        result.Add(addList);
                        
                        //Save left and right values as a temporary value. 
                        int leftVal = nums[left];
                        int rightVal = nums[right];
                        //Find the next unique value
                        while (left < nums.Length && leftVal == nums[left])
                        {
                            left++;
                        }
                        //Find the next unique value
                        while (right > 0 && rightVal == nums[right])
                        {
                            right--;
                        }
                    }
                }

                //A tmp value used as a placeholder to find a new unique value.
                int tmpValue = nums[index];
                //Find a new unique value to check against.
                while (index < nums.Length && tmpValue == nums[index])
                {
                    index++;
                }
            }
        }
    }
}
