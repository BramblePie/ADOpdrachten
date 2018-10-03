using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Les 4
            //// Op2 les 4

            //FCNSNode<int> root = new FCNSNode<int>(7);
            //root.Child = new FCNSNode<int>(2, new FCNSNode<int>(1, null, new FCNSNode<int>(5, new FCNSNode<int>(3))), new FCNSNode<int>(9));
            //FCNSTree<int> tree = new FCNSTree<int>(root); 
            //tree.PrintPreOrder();

            //// Op3
            //BinaryTree<int> bTree = new BinaryTree<int>(
            //    new BinaryNode<int>()
            //    {
            //        Data = 4,
            //        Left = new BinaryNode<int>()
            //        {
            //            Data = 2,
            //            Left = new BinaryNode<int>() { Data = 1 },
            //            Right = new BinaryNode<int>() { Data = 3 }
            //        },
            //        Right = new BinaryNode<int>() { Data = 6 }
            //    });

            //// op4
            //Console.WriteLine(bTree.ToString());

            //Console.WriteLine(bTree.Height()); 
            #endregion

            #region Les 5

            IBinarySearchTree searchTree = new BinarySearchTree(6);
            searchTree.Insert(4);
            searchTree.Insert(5);
            searchTree.Insert(7);
            searchTree.Insert(2);
            Console.WriteLine(searchTree);
            Console.WriteLine(searchTree.InOrder());
            #endregion

            Console.WriteLine("\n\n\nEND");
            Console.ReadLine();
        }
    }
}
