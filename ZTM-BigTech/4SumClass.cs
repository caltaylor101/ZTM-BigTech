using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class _4SumClass
    {
        //Initialize list to return
        private List<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            //Accounts for nums.length constraint
            if (nums.Length < 4) return result;

            int index = 0;
            while (index < nums.Length) 
            {
                long offset = nums[index];
                int offsetIndex = index;

                ThreeSum(nums, target, offset, offsetIndex + 1);

                while (index < nums.Length && offset == nums[index])
                {
                    index++;
                }
            }

            return result;
        }

        private void ThreeSum(int[] nums, int target, long offset, int offsetIndex)
        {
            int index = offsetIndex;
            while (index < nums.Length)
            {
                int startI = nums[index];
                int left = index + 1;
                int right = nums.Length - 1;
                //calculate 2 sum
                while (left < right)
                {
                    long sum = offset + nums[left] + nums[right] + nums[index];
                    if (sum < target) left++;
                    else if (sum > target) right--;
                    else if (sum == target)
                    {
                        result.Add(new List<int>() { (int)offset, nums[left], nums[right], nums[index] });
                        int leftVal = nums[left];
                        int rightVal = nums[right];
                        while(left < nums.Length && leftVal == nums[left])
                        {
                            left++;
                        }
                        while(right > 0 && rightVal == nums[right])
                        {
                            right--;
                        }
                    }
                }
                while (index < nums.Length && startI == nums[index])
                {
                    index++;
                }
            }
        }

        private int CalculateTotal(int left, int leftMid, int rightMid, int right)
        {
            return (left + leftMid + rightMid + right);
        }
    }
}
