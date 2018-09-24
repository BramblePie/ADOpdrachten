using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IFCNSTree<T>
    {
        int Size();
        void PrintPreOrder();
    }

    class FCNSTree<T> : IFCNSTree<T>
    {
        private FCNSNode<T> root;

        private string str;

        public FCNSTree(T data)
        {
            root = new FCNSNode<T>(data);
        }

        public FCNSTree(FCNSNode<T> root)
        {
            this.root = root;
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void PrintPreOrder()
        {
            str = "";
            FCNSNode<T> itr = root;
            RecurPrintPreOrder(root);
            str = str.TrimEnd(' ').TrimEnd(',');
            Console.WriteLine(str);
        }

        private void RecurPrintPreOrder(FCNSNode<T> itr)
        {
            str += $"{itr.Data}, ";
            if (itr.Child != null)
                RecurPrintPreOrder(itr.Child);

            if (itr.Sibling != null)
                RecurPrintPreOrder(itr.Sibling);
        }
    }

    class FCNSNode<T>
    {
        public FCNSNode(T data, FCNSNode<T> child = null, FCNSNode<T> sibling = null)
        {
            Data = data;
            Child = child;
            Sibling = sibling;
        }

        public T Data { get; set; }
        public FCNSNode<T> Child { get; set; }
        public FCNSNode<T> Sibling { get; set; }
    }
}
