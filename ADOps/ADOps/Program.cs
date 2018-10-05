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
            #region Les 1

            Sieve sieve = new Sieve(100);
            Console.WriteLine($"All primes till: {sieve.Limit}");
            foreach (var p in sieve.Primes)
                Console.Write(p + " ");
            Console.WriteLine('\n');

            #endregion

            #region Les 2
            // ArrayList
            Console.WriteLine("Simple array list");
            MyArrayList myArrayList = new MyArrayList(2);
            myArrayList.Add(6);
            myArrayList.Add(4);
            myArrayList.Add(5);
            myArrayList.Add(7);
            myArrayList.Add(8);
            myArrayList.Set(0, 8);
            myArrayList.Print();
            Console.WriteLine(myArrayList.CountOccurences(8));
            Console.WriteLine(myArrayList.Get(1));
            myArrayList.Clear();
            myArrayList.Print();
            Console.WriteLine();

            // LinkedList
            Console.WriteLine("Simple linked list");
            MyLinkedList<char> myLinkedList = new MyLinkedList<char>();
            myLinkedList.Add('r');
            myLinkedList.Add('a');
            myLinkedList.Add('f');
            myLinkedList.Add('o');
            myLinkedList.Print();
            myLinkedList.Insert(1, 'i');
            myLinkedList.Print();
            myLinkedList.RemoveFirst();
            myLinkedList.Print();
            myLinkedList.Clear();
            Console.WriteLine();

            // MyStack
            Console.WriteLine("My simple stack");
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(2);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(8);
            Console.WriteLine(myStack.Top());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine();
            Console.WriteLine(myStack.CheckBrackets("((()()))"));
            Console.WriteLine(myStack.CheckBrackets("())"));
            Console.WriteLine(myStack.CheckBrackets("((())"));

            Console.WriteLine(myStack.CheckBrackets2("[ ( ( [ ] ) ) ( ) ]"));
            Console.WriteLine(myStack.CheckBrackets2("( [ ) ]"));
            Console.WriteLine();

            // MyQueue
            Console.WriteLine("My simple queue");
            IQueue<int> q = new MyQueue<int>(2);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            Console.WriteLine(q.Front());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine();

            #endregion

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
            searchTree.Insert(3);
            Console.WriteLine(searchTree);
            searchTree.Remove(3);
            Console.WriteLine(searchTree);
            #endregion

            Console.WriteLine("\n\n\nEND");
            Console.ReadLine();
        }
    }
}
