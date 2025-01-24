using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCSharpSolutions._2_226_Invert_Binary_Tree
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            DoInvert(root);
            return root;
        }

        public void DoInvert(TreeNode node)
        {
            if (node == null)
                return;

            // if left child exists and isn't a leaf - invert
            if (node.left != null && (node.left.left != null || node.left.right != null))
                DoInvert(node.left);

            // if right child exists and isn't a leaf - invert
            if (node.right != null && (node.right.left != null || node.right.right != null))
                DoInvert(node.right);

            // if current node has:
            // two childs - invert between them
            // one child - child's side becomes null, and child moves to the other side
            if (node.left != null)
            {
                if (node.right != null)
                {
                    TreeNode temp = node.left;
                    node.left = node.right;
                    node.right = temp;
                }
                else
                {
                    node.right = node.left;
                    node.left = null;
                }
            }
            else if (node.right != null)
            {
                node.left = node.right;
                node.right = null;
            }
        }
    }
}
