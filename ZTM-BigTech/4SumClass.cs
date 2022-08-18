using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class _4SumClass
    {
        //Initialize list to return that multiple methods can use.
        private List<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            //Sort the array
            Array.Sort(nums);
            //Accounts for nums.length constraint
            if (nums.Length < 4) return result;
            //Initialize an index.
            int index = 0;
            while (index < nums.Length) 
            {
                //Optional variable. It could be cast directly to the method.
                //Passing the offset value down to the ThreeSum method.
                //This needs to be a long so that an integer sum above int.MaxValue can be calculated. 
                long offset = nums[index];
                //Optional variable. 
                //Passing the index where the ThreeSum method will run. 
                int offsetIndex = index + 1;

                //Call the ThreeSum method on every index.
                ThreeSum(nums, target, offset, offsetIndex);

                //Find the next unique value. 
                while (index < nums.Length && offset == nums[index])
                {
                    index++;
                }
            }

            return result;
        }

        //A ThreeSum method to calculate the 4sum. 
        private void ThreeSum(int[] nums, int target, long offset, int offsetIndex)
        {
            //Optional Variable.
            //Renamed to make it easier to read.
            int index = offsetIndex;

            //Looping everything to the right of our initial index in FourSum
            while (index < nums.Length)
            {
                //A left and right pointer to be used to find a TwoSum
                int left = index + 1;
                int right = nums.Length - 1;

                //A Loop to calculate the 2 sums missing. 
                while (left < right)
                {
                    //Calculate the sum as a long as the int.MaxValue will be hit here. (offset was made a type long for this reason)
                    long sum = offset + nums[left] + nums[right] + nums[index];
                    //Verify which way the pointers should move. 
                    //Move left if the sum is < target
                    if (sum < target) left++;
                    //Move right down if it is lower than target. 
                    else if (sum > target) right--;
                    //Otherwise, they equal, so add everything to the result list.
                    else
                    {
                        //Add each of our values as a list to the result list.
                        result.Add(new List<int>() { (int)offset, nums[left], nums[right], nums[index] });
                        //Save left and right values as a temporary value. 
                        int leftVal = nums[left];
                        int rightVal = nums[right];
                        //Find the next unique value
                        while(left < nums.Length && leftVal == nums[left])
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
