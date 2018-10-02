using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IBinaryTree<T> where T : IComparable
    {
        BinaryNode<T> GetRoot();
        int Size();
        int Height();

        BinaryNode<T> FindFirst(T nugget);
        int FindNumberLeaves();

        void PrintPreOrder();
        void PrintInOrder();
        void PrintPostOrder();

        void MakeEmpty();
        bool IsEmpty();
        void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2);
    }

    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        private BinaryNode<T> root;
        private string str;
        private int size;

        public BinaryTree(BinaryNode<T> root) => this.root = root;

        public BinaryTree(T data) => root = new BinaryNode<T>() { Data = data };

        public BinaryTree() { }

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public BinaryNode<T> FindFirst(T nugget)
        {
            return FindFirst(root, nugget);
        }

        private BinaryNode<T> FindFirst(BinaryNode<T> itr, T nugget)
        {
            if (itr == null)
                return null;

            if (itr.Data.CompareTo(nugget) == 0)
                return itr;
            else if (itr.Data.CompareTo(nugget) > 0)
                return FindFirst(itr.Left, nugget);

            return FindFirst(itr.Right, nugget);
        }

        public int FindNumberLeaves()
        {
            if (root == null)
                return -1;
            return FindNumberLeaves(root);
        }

        private int FindNumberLeaves(BinaryNode<T> itr)
        {
            if (itr.Left != null)
                return 1 + FindNumberLeaves(itr.Left);
            if (itr.Right != null)
                return 1 + FindNumberLeaves(itr.Right);
            return 1;
        }

        public int Size()
        {
            size = 0;
            if (root != null)
                SizeRecur(root);

            return size;
        }

        private void SizeRecur(BinaryNode<T> itr)
        {
            size++;
            if (itr.Left != null)
                SizeRecur(itr.Left);

            if (itr.Right != null)
                SizeRecur(itr.Right);
        }

        public int Height()
        {
            if (root == null)
                return -1;

            return HeightRecur(root);
        }

        private int HeightRecur(BinaryNode<T> itr)
        {
            if (itr.Left == null && itr.Right == null)
                return 0;
            else if (itr.Left == null)
                return 1 + HeightRecur(itr.Right);
            else if (itr.Right == null)
                return 1 + HeightRecur(itr.Left);

            return 1 + Math.Max(HeightRecur(itr.Left), HeightRecur(itr.Right));
        }

        public void PrintPreOrder()
        {
            str = "[";
            if (root != null)
                PrintPreOrderRecur(root);
            str = str.TrimEnd(' ').TrimEnd(',') + ']';
            Console.WriteLine(str);
        }

        private void PrintPreOrderRecur(BinaryNode<T> itr)
        {
            // N
            str += $"{itr.Data}, ";
            // L
            if (itr.Left != null)
                PrintPreOrderRecur(itr.Left);
            // R
            if (itr.Right != null)
                PrintPreOrderRecur(itr.Right);
        }

        public void PrintInOrder()
        {
            str = "[";
            if (root != null)
                PrintInOrderRecur(root);
            str = str.TrimEnd(' ').TrimEnd(',') + ']';
            Console.WriteLine(str);
        }

        private void PrintInOrderRecur(BinaryNode<T> itr)
        {
            // L
            if (itr.Left != null)
                PrintInOrderRecur(itr.Left);
            // N
            str += $"{itr.Data}, ";
            // R
            if (itr.Right != null)
                PrintInOrderRecur(itr.Right);
        }

        public void PrintPostOrder()
        {
            str = "[";
            if (root != null)
                PrintPostOrderRecur(root);
            str = str.TrimEnd(' ').TrimEnd(',') + ']';
            Console.WriteLine(str);
        }

        private void PrintPostOrderRecur(BinaryNode<T> itr)
        {
            // L
            if (itr.Left != null)
                PrintPostOrderRecur(itr.Left);
            // R
            if (itr.Right != null)
                PrintPostOrderRecur(itr.Right);
            // N
            str += $"{itr.Data}, ";
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            root.Data = rootItem;
            root.Left = t1.root;
            root.Right = t2.root;
        }

        public override string ToString()
        {
            str = "";
            if (root != null)
                ToString(root);

            str = str.Trim('[').Trim(' ').Trim(']').Trim(' ');
            return str;
        }

        private void ToString(BinaryNode<T> itr)
        {
            str += "[ ";
            if (itr.Left != null)
                ToString(itr.Left);
            else
                str += "NULL ";
            str += $"{itr.Data} ";
            if (itr.Right != null)
                ToString(itr.Right);
            else
                str += "NULL ";
            str += "] ";
        }
    }

    public class BinaryNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }
    }
}
