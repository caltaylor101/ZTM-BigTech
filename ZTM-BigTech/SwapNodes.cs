using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class SwapNodes
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode SwapPairs(ListNode head)
        {
            //Initial null checks before continuing. 
            if (head == null || head.next == null) return head;

            //This head will be what we return at the end. 
            ListNode returnHead = head.next;

            //Follower runs behind
            ListNode follower = head;
            ListNode runner = head.next;

            //tmpNode to keep track of the original follower. 
            ListNode tmpNode = null; 

            while (runner != null)
            {
                //using the example 1,2,3,4
                //tmp node becomes 1.
                tmpNode = follower;
                // 1.next becomes 2.next. Now 1 points to 3
                // 1 => 3
                follower.next = runner.next;
                // 2.next = 1. 
                runner.next = follower;
                //We have 2, 1, 3, 4
                //follower = 1 
                //runner = 2

                //If there is an error trying to access the next runner then we break the loop. 
                try
                {
                    //Traverse the runner and follower down to the next pair
                    runner = runner.next.next.next;
                    follower = follower.next;

                    //If runner is not null, then we need the last follower to point to the runner. 
                    // 2, 1, 3, 4
                    // follower = 3
                    // runner = 4
                    // tmpNode = 1
                    // We set the tmpnode.next to the new runner. 
                    if (runner != null) tmpNode.next = runner;
                    //In the case that runner is null, if we started the function with [1,2,3], then at this step we would have:
                    // 2, 1, 3
                    // follower = 3
                    // runner = null
                    // tmpNode = 1
                    // So we don't want to point our follower to nothing in this case, because we want 3 to be in the list. 
                }
                catch
                {
                    //If we error out above, then end the loop. 
                    break;
                }
            }

            //Return the head of our new list. 
            return returnHead;
        }
    }
}
