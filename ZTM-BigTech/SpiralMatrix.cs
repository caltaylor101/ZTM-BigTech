using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            //Initialize a list to push to. 
            List<int> spiralList = new List<int>();

            //Initialize the directions of the matrix.
            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right = matrix[0].Length - 1;

            //Keep going as long as top and left are less than bottom and right. 
            while (top <= bottom && left <= right)
            {
                //Get all from the top row.
                for (int i = left; i <= right; i++)
                {
                    spiralList.Add(matrix[top][i]);
                }
                //Move down from the top.
                top++;
                //Break the loop if top and bottom overlap for the bottom loop below.
                if (top > bottom) break;

                //Get the right side.
                for (int i = top; i <= bottom; i++)
                {
                    spiralList.Add(matrix[i][right]);
                }
                //Move the right side over.
                right--;
                //Break the loop if left and right overlap for the right loop below.
                if (left > right) break;

                //Get the bottom row.
                for (int i = right; i >= left; i--)
                {
                    spiralList.Add(matrix[bottom][i]);
                }
                //Move the bottom up.
                bottom--;

                for (int i = bottom; i >= top; i--)
                {
                    spiralList.Add(matrix[i][left]);
                }
                //Move the left side over.
                left++;

            }

            //Return the list.
            return spiralList;

        }
    }
}
