// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.SwapNodes;

SpiralMatrix eng = new SpiralMatrix();


int[][] matrix = new int[][]
{
    new int[] {2,5,8},
    new int[] {4,0,-1}
};

IList<int> test = eng.SpiralOrder(matrix);

foreach (var i in test) Console.WriteLine(i);

