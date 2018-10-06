using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string brackets = "((()()))";
            Console.WriteLine($"{brackets,-20} is valid? {myStack.CheckBrackets(brackets)}");
            brackets = "())";
            Console.WriteLine($"{brackets,-20} is valid? {myStack.CheckBrackets(brackets)}");
            brackets = "((())";
            Console.WriteLine($"{brackets,-20} is valid? {myStack.CheckBrackets(brackets)}");
            brackets = "[ ( ( [ ] ) ) ( ) ]";
            Console.WriteLine($"{brackets,-20} is valid? {myStack.CheckBrackets2(brackets)}");
            brackets = "( [ ) ]";
            Console.WriteLine($"{brackets,-20} is valid? {myStack.CheckBrackets2(brackets)}");
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

            #region Les 3

            // Faculteit
            Console.WriteLine("Factorial (recursion)");
            uint nFac = 12;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong ansFac1 = RecurBox.Factorial(nFac, recursive: false);
            sw.Stop();
            long ticksFac1 = sw.ElapsedTicks;
            sw.Restart();
            ulong ansFac2 = RecurBox.Factorial(nFac, recursive: true);
            sw.Stop();
            long ticksFac2 = sw.ElapsedTicks;
            sw.Reset();
            Console.WriteLine($"(Loop)      {nFac}! = {ansFac1} \t [ticks: {ticksFac1}]");
            Console.WriteLine($"(Recusive)  {nFac}! = {ansFac2} \t [ticks: {ticksFac2}]");

            // Fibonacci
            Console.WriteLine("\nFibonacci (recursion)");
            int nFib = 30;
            sw.Start();
            int[] ansFib1 = RecurBox.Fibonacci(nFib, recursive: false);
            sw.Stop();
            long ticksFib1 = sw.ElapsedTicks;
            sw.Restart();
            int[] ansFib2 = RecurBox.Fibonacci(nFib, recursive: true);
            sw.Stop();
            long ticksFib2 = sw.ElapsedTicks;
            sw.Reset();
            Console.WriteLine($"{nFib} numbers of Fibonacci: [ticks: {ticksFib1,-8}] (Loop)");
            ansFib1.ToList().ForEach(a => Console.Write(a.ToString() + " "));
            Console.WriteLine($"\n{nFib} numbers of Fibonacci: [ticks: {ticksFib2,-8}] (Recursive)");
            ansFib2.ToList().ForEach(a => Console.Write(a.ToString() + " "));
            Console.WriteLine();

            // OmEnOm som
            Console.WriteLine("\nOm en om (recursion)");
            int nOm = 7;
            Console.WriteLine($"f({nOm}) = {RecurBox.OmEnOm(nOm)}");

            Console.WriteLine(RecurBox.OnesInBinary(127));

            List<int> printList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            RecurBox.PrintForward(printList, 3);
            Console.WriteLine();
            RecurBox.PrintBackward(printList, 3);
            Console.WriteLine();

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
