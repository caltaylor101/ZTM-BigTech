using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class WhereWillTheBallFall
    {

        
        public int[] FindBall()
        {
            int[][] grid = new int[][] {
             new int[] {1,1,1,-1,-1},
            new int[] {1,1,1,-1,-1},
             new int[] {-1,-1,-1,1,1},
            new int[] {1,1,1,1,-1},
            new int[] {-1,-1,-1,-1,-1},
            };
            //This can be done as an array to make things a bit faster.
            // int[] matrixArray = new int[matrix[0].Length];
            List<int> matrixList = new List<int>();

            // This simulates dropping the ball on every column
            for (int ballDrop = 0; ballDrop < grid[0].Length; ballDrop++)
            {   
                // We always start from the top.
                int ballVertical = 0;
                int ballHorizontal = ballDrop;

                // Insignificant while loop condition to equal true.
                while (ballDrop < grid[0].Length)
                {
                    // Bounces Left
                    if (grid[ballVertical][ballHorizontal] == - 1 )
                    {
                        // Check for wall 
                        if (ballHorizontal -1 < 0)
                        {
                            matrixList.Add(-1);
                            break;
                        }
                        // Check if left side bounces right
                        if (grid[ballVertical][ballHorizontal - 1] == 1)
                        {
                            matrixList.Add(-1);
                            break;
                        }
                        // If both bounce left, then we move the ball left 1 and down 1. 
                        else
                        {
                            // Move ball to new location
                            ballVertical++;
                            ballHorizontal--;

                            // If ball falls out add the column and break.
                            if (ballVertical >= grid.Length)
                            {
                                matrixList.Add(ballHorizontal);
                                break;
                            }
                        }
                    }

                    // Bounces right
                    if (grid[ballVertical][ballHorizontal] == 1)
                    {
                        //Check for wall 
                        if (ballHorizontal + 1 >= grid[0].Length)
                        {
                            matrixList.Add(-1);
                            break;
                        }
                        //check if right side bounces left
                        if (grid[ballVertical][ballHorizontal + 1] == -1)
                        {
                            matrixList.Add(-1);
                            break;
                        }
                        //if it bounces right too, then we move the ball right 1 and down 1. 
                        else
                        {
                            //Move ball to new location
                            ballVertical++;
                            ballHorizontal++;

                            //If ball falls out add the column and break.
                            if (ballVertical >= grid.Length)
                            {
                                matrixList.Add(ballHorizontal);
                                break;
                            }
                        }
                    }

                }
            }
            return matrixList.ToArray();
        }

        public int[] FindBall2()
        {
            int[][] grid = new int[][] {
             new int[] {1,1,1,-1,-1},
            new int[] {1,1,1,-1,-1},
             new int[] {-1,-1,-1,1,1},
            new int[] {1,1,1,1,-1},
            new int[] {-1,-1,-1,-1,-1},
            };

            //List<int> matrixList = new List<int>();
            int[] matrixArray = new int[grid[0].Length];

            var ballDropSpot = 0;
            for (int ballDrop = 0; ballDrop < grid[0].Length; ballDrop++)
            {
                matrixArray[ballDrop] = RecurseBall(grid, 0, ballDrop);
                
            }
            return matrixArray;
        }

        private int RecurseBall(int[][] grid, int ballVertical, int ballHorizontal)
        {
            if (ballVertical >= grid.Length)
            {
                return ballHorizontal;
            }
            
            if (grid[ballVertical][ballHorizontal] == -1)
            {
                if (ballHorizontal - 1 < 0) return -1;
                if (grid[ballVertical][ballHorizontal - 1] == 1) return -1;
                return RecurseBall(grid, ballVertical + 1, ballHorizontal - 1);
            }

            if (grid[ballVertical][ballHorizontal] == 1)
            {
                if (ballHorizontal + 1 >= grid[0].Length) return -1;
                if (grid[ballVertical][ballHorizontal + 1] == -1) return -1;
                return RecurseBall(grid, ballVertical + 1, ballHorizontal + 1);
            }

            return -1;
        }
    }
}
