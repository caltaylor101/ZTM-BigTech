// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.BinarySearch;
using static ZTM_BigTech.SwapNodes;

BinarySearch search = new BinarySearch();

int[] test = search.Intersect(new int[] { 1,1 }, new int[] { 1,2 });

foreach (var num in test) Console.WriteLine(num);

BinaryNode node1 = new BinaryNode(7, null, null);
BinaryNode node2 = new BinaryNode(8, null, null);
BinaryNode node3 = new BinaryNode(4, node1, node2);
BinaryNode node4 = new BinaryNode(5, null, null);
BinaryNode node5 = new BinaryNode(2, node3, node4);

BinaryNode node6 = new BinaryNode(9, null, null);
BinaryNode node7 = new BinaryNode(10, null, null);
BinaryNode node8 = new BinaryNode(6, node6, node7);
BinaryNode node9 = new BinaryNode(3, null, node8);

BinaryNode head = new BinaryNode(1, node5, node9);




BinaryNode node = search.MyBinaryTreeFunction(head);

void DfsLog(BinaryNode node)
{
    if (node == null) return;
    DfsLog(node.left);
    DfsLog(node.right);

    Console.WriteLine(node.value);
}

DfsLog(node);

