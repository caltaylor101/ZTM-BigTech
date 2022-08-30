// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;
using static ZTM_BigTech.SwapNodes;

SwapNodes eng = new SwapNodes();

//ListNode node1 = new ListNode(4);
ListNode node2 = new ListNode(3);
ListNode node3 = new ListNode(2, node2);
ListNode node4 = new ListNode(1, node3);

ListNode list = eng.SwapPairs(node4);

while (list != null)
{
    Console.WriteLine(list.val);
    list = list.next;
}

