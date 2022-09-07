using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class Permutations
    {
        public void NextPermutation(int[] nums)
        {
            //Initialize an index to find where to start the next permutation. 
            int index = 0;
            //A tmp int used to swap values.
            int tmpInt = 0;
            //A minInt with the constraints to swap out the index. 
            int[] minInt = new int[] { 101, 0 };
            //A trigger for if our index is at the max value. 
            bool isMax = false;

            //Find the index to work with, which is always when the value decreases from right to left. 
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                //As long as i - 1 is available, check to see if the next value is lower. 
                if (i - 1 >= 0 && nums[i - 1] < nums[i])
                {
                    index = i - 1;
                    break;
                }
                //If we make it to 0, then our index is 0 and we know that it is the maximum value. 
                if (i == 0) isMax = true;
            }

            //Find the min if the starting index is the max. 
            if (isMax)
            {
                Array.Sort(nums);
                return;
            }
            else
            {
                //Find the next lowest value that doesn't equal the index. 
                for (int i = index + 1; i < nums.Length; i++)
                {
                    //Assign the minimum value to the next lowest value aside from the index. 
                    if (nums[i] > nums[index] && nums[i] < minInt[0]) minInt = new int[] { nums[i], i };
                }
            }

            //Swap the values.
            tmpInt = nums[index];
            nums[index] = nums[minInt[1]];
            nums[minInt[1]] = tmpInt;

            //Sort the values.
            Array.Sort(nums, index + 1, nums.Length - index - 1);
        }
    }
}
