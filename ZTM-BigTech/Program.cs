// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.SwapNodes;

MatrixUpdate mUpdate = new MatrixUpdate();

int[][] matrix = new int[][]
{
     new int[] {0},
     new int[] {0},
     new int[] {0},
     new int[] {0},

};

var returnmatrix = (mUpdate.UpdateMatrix(matrix));

for (int i = 0; i < returnmatrix.Length; i++)
{
    for (int j = 0; j < returnmatrix[i].Length; j++)
    {
        Console.Write(returnmatrix[i][j]);
    }
    Console.WriteLine();
}



/*private int UpdateMatrixBFS(int[,] matrix, int startX, int startY)
{
    var row = matrix.GetLength(0);
    var col = matrix.GetLength(1);

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

                if (matrix[nextX, nextY] == 0) return distance;

                queue.Enqueue(Tuple.Create(nextX, nextY));
            }
        }

        distance++;
    }

    return distance;
}*/


