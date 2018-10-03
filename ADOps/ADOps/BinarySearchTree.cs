using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    interface IBinarySearchTree
    {
        void Insert(int x);
        void Remove(int x);
        void RemoveMin();
        int FindMin();
        string InOrder();
        string ToString();
    }

    class BinarySearchTree : IBinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(int rootElement)
        {
            root = new Node(rootElement);
        }

        public void Insert(int x)
        {
            Node p = FindParentOfNode(x);

            if (x < p.element)
                p.left = new Node(x);
            else
                p.right = new Node(x);
        }

        public void Remove(int x)
        {
            throw new NotImplementedException();
        }

        private Node FindParentOfNode(int x)
        {
            if (x == root.element)
                return root;
            Node p = root;
            Node i = root;
            while (i != null)
            {
                if (x == i.element)
                    break;
                p = i;
                i = (x < i.element) ? i.left : i.right;
            }
            return p;
        }

        public void RemoveMin()
        {
            Node p = root;
            Node min = root;
            while (min.left != null)
            {
                p = min;
                min = min.left;
            }
            p.left = min.right;
        }

        public int FindMin()
        {
            Node itr = root;
            while (itr.left != null)
                itr = itr.left;
            return itr.element;
        }

        public string InOrder()
        {
            return IsOrder(root, "").TrimEnd(' ');
        }

        private string IsOrder(Node node, string str)
        {
            return $"{((node.left != null) ? IsOrder(node.left, str) : "")}{node.element} {((node.right != null) ? IsOrder(node.right, str) : "")}";
        }

        public override string ToString()
        {
            if (root == null)
                return "[ ]";
            return ToString(root, "");
        }

        private string ToString(Node itr, string str)
        {
            return $"[ {((itr.left != null) ? ToString(itr.left, str) : "NULL")} ] {itr.element} [ {((itr.right != null) ? ToString(itr.right, str) : "NULL")} ]";
        }

        private class Node
        {
            public int element;
            public Node left;
            public Node right;

            public Node(int x)
            {
                element = x;
                left = null;
                right = null;
            }
        }
    }



}
