using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class BalancedBinaryTree
    {
        public class TreeNode
        {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                     }
            }
        public bool IsBalanced(TreeNode root)
        {
            int DFS(TreeNode node)
            {
                if (node == null) return 0;
                
                int left = DFS(node.left);
                if (left == -1) return -1;

                int right = DFS(node.right);
                if (right == -1) return -1;

                int difference = Math.Abs(left - right);
                if (difference > 1) return -1;

                return 1 + Math.Max(left, right);
            }
            if (DFS(root) == -1) return false;
            return true;
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            int minTree = int.MaxValue;
            void DFS(TreeNode node, int count)
            {
                if (node.left == null && node.right == null)
                {
                    minTree = Math.Min(count, minTree);
                    return;
                }

                if (node.left != null) DFS(node.left, count + 1);

                if (node.right != null) DFS(node.right, count + 1);
            }
            DFS(root, 1);
            return minTree;
        }


    }
}
