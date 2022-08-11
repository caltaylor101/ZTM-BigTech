using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    //Each element of the LinkedList<T> collection is a LinkedListNode<T>.
    //The LinkedListNode<T> contains a value, a reference to the LinkedList<T> that it belongs to,
    //a reference to the next node, and a reference to the previous node.
    internal class LRUCache
    {
        //Dictionary for our key and value pairs. 
        Dictionary<int, LinkedListNode<int[]>> cacheDict = new Dictionary<int, LinkedListNode<int[]>>();
        //Double Linked List for keeping order
        LinkedList<int[]> cacheList = new LinkedList<int[]>();
        int capacity = 0;
        public LRUCache(int capacity)
        {
            //Construct the LRUCache and initiate the capacity variable. 
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            //If the key exists, then rearrange the LinkedListNode. 
            if (cacheDict.ContainsKey(key))
            {
                //This method is called a few times.
                SetRecentlyUsed(key);
                //The second value in the LinkedListNode<int[]> is the value. 
                return cacheDict[key].Value[1];
            }
            else return -1;
        }

        
        public void Put(int key, int value)
        {
            if(cacheDict.ContainsKey(key))
            {
                //Set the new value of the key
                cacheDict[key].Value = new int[] { key, value };
                //Since the key was accessed, we need to make it recently used. 
                SetRecentlyUsed(key);
            }
            else
            {
                //Otherwise, we add the new LinkedListNode to the list.
                cacheList.AddFirst(new int[] { key, value });
                //Then, we add this to the dictionary. 
                cacheDict.Add(key, cacheList.First);
                //Finally, we check to make sure the List count isn't over capacity. 
                if (cacheList.Count > capacity)
                {
                    //If it is, we remove the key/value pair from our Dictionary.
                    cacheDict.Remove(cacheList.Last.Value[0]);
                    //Then we remove the last LinkedListNode from the list. 
                    cacheList.RemoveLast();
                }
            }
        }

        private void SetRecentlyUsed(int key)
        {
            //Hold the value in a temporary variable. 
            LinkedListNode<int[]> tmp = cacheDict[key];
            //Remove the node from the list.
            cacheList.Remove(cacheDict[key]);
            //Add the node to the front of the list from our temporary value. 
            cacheList.AddFirst(tmp);
        }


    }
}
