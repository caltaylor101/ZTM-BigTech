using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class MatrixUpdate
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            int rowLength = mat.Length;
            int colLength = mat[0].Length;

            if (rowLength == 0) return new int[0][];

            int[][] result = new int[rowLength][];

            for (int i = 0; i < rowLength; i++)
            {
                result[i] = new int[colLength];
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (mat[i][j] == 0) continue;

                    result[i][j] = FindNearestZeroBFS(mat, i, j, rowLength, colLength);
                }
            }

            return result;
        }

        private int FindNearestZeroBFS(int[][] matrix, int row, int col, int rowLength, int colLength)
        {

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(Tuple.Create(row, col));
            int distance = 1;
            int[,] directions = new int[,]
                {
                    {1, 0},
                    {-1, 0},
                    {0, 1 },
                    {0, -1 }
                };

            while (queue.Any())
            {
                int size = queue.Count;

                for (int k = 0; k < size; k++)
                {
                    Tuple<int, int> current = queue.Dequeue();

                    for (int i = 0; i < 4; i++)
                    {
                        int rowDirection = directions[i, 0];
                        int colDirection = directions[i, 1];

                        int rowStart = current.Item1 + rowDirection;
                        int colStart = current.Item2 + colDirection;


                        if (rowStart < 0 || rowStart >= rowLength || colStart < 0 || colStart >= colLength) continue;
                        if (matrix[rowStart][colStart] == 0) return distance;
                        queue.Enqueue(Tuple.Create(rowStart, colStart));
                    }
                }
                distance++;
            }
            return distance; 

        }










        public int[][] UpdateMatrix(int[][] matrix)
        {
            var row = matrix.Length;
            var col = matrix[0].length;

            if (row == 0) return new int[0][];

            var result = new int[row][];
            for (int i = 0; i < row; i++)
            {
                result[i] = new int[col];
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i][j] == 0) continue;

                    var distance = UpdateMatrixBFS(matrix, i, j);
                    result[i][j] = distance;
                }
            }

            return result;
        }

        private int UpdateMatrixBFS(int[][] matrix, int startX, int startY)
        {
            var row = matrix.Length;
            var col = matrix[0].Length;

            var directions = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

            var queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(Tuple.Create(startX, startY));
            var distance = 1;
            while (queue.Any())
            {
                var size = queue.Count;

                for (int z = 0; z < size; z++)
                {
                    var cur = queue.Dequeue();

                    for (int i = 0; i < directions.GetLength(0); i++)
                    {
                        var directionX = directions[i, 0];
                        var directionY = directions[i, 1];

                        var nextX = cur.Item1 + directionX;
                        var nextY = cur.Item2 + directionY;

                        if (nextX < 0 || nextX >= row || nextY < 0 || nextY >= col) continue;

                        if (matrix[nextX][nextY] == 0) return distance;

                        queue.Enqueue(Tuple.Create(nextX, nextY));
                    }
                }

                distance++;
            }

            return distance;
        }






























        public int[,] UpdateMatrix2(int[,] matrix)
        {
            // Get the length of the row and columns
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            // Check for an empty matrix
            if (rowLength == 0) return new int[0, 0];

            // Initialize a matrix to return
            int[,] result = new int[rowLength, colLength];

            // Check every matrix possibility
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    // 0s don't change
                    if (matrix[i, j] == 0) continue;

                    // Change with the distance if it doesn't equal 1.
                    int distance = FindDistanceBFS(matrix, i, j);
                    result[i, j] = distance;
                }
            }
            return result;

        }

        private int FindDistanceBFS(int[,] matrix, int row, int col)
        {
            // Get the matrix lengths
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            // Set directions to navigate
            int[,] directions = new int[,] 
            { 
                { 0, 1 }, 
                { 0, -1 }, 
                { 1, 0 }, 
                { -1, 0 } 
            };

            // Create a Queue for BFS
            // Use a Tuple for an easily instantiated object
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            // Queue our start point
            queue.Enqueue(Tuple.Create(row, col));

            // Initialize distance variable
            int distance = 1;

            // Start BFS loop
            while (queue.Any())
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Tuple<int, int> current = queue.Dequeue();

                    // Loop through our directions
                    for (int j = 0; j < 4; j++)
                    {
                        // Get the direction to use depending on the loop so we hit all 4 directions. 
                        // Gets our column direction or x axis, so 0
                        int colDirection = directions[j, 0];
                        int rowDirection = directions[j, 1];

                        // Gets our first tuple value and adds the direction to it. 
                        int nextCol = current.Item1 + colDirection;
                        int nextRow = current.Item2 + rowDirection;

                        // Check if any columns or rows break index and reset the loop if it does. 
                        if (nextCol < 0 || nextCol >= colLength || nextRow >= rowLength || nextRow < 0) continue;

                        // If a 0 was found return the distance. 
                        if (matrix[nextCol, nextRow] == 0) return distance;

                        queue.Enqueue(Tuple.Create(nextCol, nextRow));
                    }
                }
                // Increase the distance.
                // From the created queues in the above list, we know at this point we have checked all 4 directions. 
                // The queues added a tuple for each direction. 
                // Now each spot that didn't have a 0, will be checked on all their 4 points. 
                distance++;
            }
            return distance;

        }

        



    }
}
