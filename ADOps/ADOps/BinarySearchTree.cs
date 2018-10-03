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
            Node i = root;
            Node p = root;

            while (i != null)
            {
                p = i;
                if (x < i.element)
                    i = i.left;
                else if (x > i.element)
                    i = i.right;
                else
                    throw new ArgumentException("Duplicate element in binary search three");
            }
            if (x < p.element)
                p.left = new Node(x);
            else
                p.right = new Node(x);
        }

        public void Remove(int x)
        {
            root = Remove(root, x);
        }

        private Node Remove(Node i, int x)
        {
            if (i == null)
                throw new ArgumentException($"Element {x} not found");
            if (x < i.element)
                i.left = Remove(i.left, x);
            else if (x > i.element)
                i.right = Remove(i.right, x);
            else if (i.left != null && i.right != null)
            {
                i.element = FindMin(i.right).element;
                RemoveMin(i.right);
            }
            else
                i = i.left ?? i.right;
            return i;
        }

        public void RemoveMin()
        {
            RemoveMin(root);
        }

        private void RemoveMin(Node node)
        {
            Node p = node;
            while (node.left != null)
            {
                p = node;
                node = node.left;
            }
            p.left = node.right;
        }

        public int FindMin()
        {
            return FindMin(root).element;
        }

        private Node FindMin(Node node)
        {
            while (node.left != null)
                node = node.left;
            return node;
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
