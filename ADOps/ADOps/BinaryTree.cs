using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IBinaryTree<T>
    {
        BinaryNode<T> GetRoot();
        int Size();
        int Height();

        void PrintPreOrder();
        void PrintInOrder();
        void PrintPostOrder();

        void MakeEmpty();
        bool IsEmpty();
        void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2);
    }

    public class BinaryTree<T> : IBinaryTree<T>
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
            throw new NotImplementedException();
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
                ToStringRecur(root);

            str = str.Trim('[').Trim(' ').Trim(']').Trim(' ');
            return str;
        }

        private void ToStringRecur(BinaryNode<T> itr)
        {
            str += "[ ";
            if (itr.Left != null)
                ToStringRecur(itr.Left);
            else
                str += "NULL ";
            str += $"{itr.Data} ";
            if (itr.Right != null)
                ToStringRecur(itr.Right);
            else
                str += "NULL ";
            str += "] ";
        }
    }

    public class BinaryNode<T>
    {
        public T Data { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }
    }
}
