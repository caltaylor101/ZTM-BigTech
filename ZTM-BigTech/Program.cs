// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;

Console.WriteLine("HELLO");

_4SumClass eng = new _4SumClass();
IList<IList<int>> list = eng.FourSum(new int[] { 1000000000, 1000000000, 1000000000, 1000000000 }, -294967296);
foreach (var i in list)
{
    Console.WriteLine("LIST");
    foreach (var k in i) Console.WriteLine(k);
}
