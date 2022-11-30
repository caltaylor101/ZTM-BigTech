// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.SwapNodes;

WhereWillTheBallFall Ball = new WhereWillTheBallFall();

foreach (var stuff in Ball.FindBall2())
{
    Console.WriteLine(stuff);
}


