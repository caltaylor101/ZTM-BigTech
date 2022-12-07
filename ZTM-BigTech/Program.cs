// See https://aka.ms/new-console-template for more information


using System.Text;
using ZTM_BigTech;

DecemberPractice pract = new DecemberPractice();

DecemberPractice.ListNode node01 = new DecemberPractice.ListNode(6, null);
DecemberPractice.ListNode node = new DecemberPractice.ListNode(5, node01);
DecemberPractice.ListNode node1 = new DecemberPractice.ListNode(4, node);
DecemberPractice.ListNode node2 = new DecemberPractice.ListNode(3, node1);
DecemberPractice.ListNode node3 = new DecemberPractice.ListNode(6, node2);
DecemberPractice.ListNode node4 = new DecemberPractice.ListNode(2, node3);
DecemberPractice.ListNode head = new DecemberPractice.ListNode(1, null);



int[][] testMatrix = new int[][]
{
    new int[] { 1, 3, 5, 7 },
    new int[] { 10,11,16,20 },
    new int[] { 23,30,34,60 },
    new int[] { 80,88,97,103 },

};

DecemberPractice.ListNode newHead = pract.RemoveElements(head, 1);

while (newHead != null)
{
    Console.WriteLine(newHead.val);
    newHead = newHead.next;
}

