// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;

Console.WriteLine("HELLO");


GroupAnagramsClass GA = new GroupAnagramsClass();

IList<IList<string>> list = GA.GroupAnagrams(new string[] { "eat", "tesa" });



foreach (var i in list)
{
    Console.WriteLine("LIST");
    foreach (var k in i) Console.WriteLine(k);
}