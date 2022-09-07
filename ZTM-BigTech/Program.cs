// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.SwapNodes;

Permutations eng = new Permutations();

int[] nums = new int[] {3,2,1};

eng.NextPermutation(nums);

foreach (var k in nums) Console.WriteLine(k);

