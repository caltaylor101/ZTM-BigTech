using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
    public class RemoveLInkedListElements
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;

            ListNode headPlaceHolder = new ListNode() { next = head };
            ListNode current = headPlaceHolder; 

            while (current != null)
            {
                if (current.next != null && current.next.val == val)
                {
                    if (current.next.next != null)
                    {
                        current.next = current.next.next;
                    }
                    else current.next = null;
                }
                else current = current.next; 
            }

            return headPlaceHolder;

        }


    }
}
