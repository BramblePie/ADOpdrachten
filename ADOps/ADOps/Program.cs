using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ADOps.MyGraph;

namespace ADOps
{
    class Program
    {
        static void Main(string[] args)
        {
#if true   // Run All?

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

            Console.WriteLine("\nCount binary ones");
            Console.WriteLine(RecurBox.OnesInBinary(127));

            Console.WriteLine("\nPrint list");
            List<int> printList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            RecurBox.PrintForward(printList, 3);
            Console.WriteLine();
            RecurBox.PrintBackward(printList, 3);

            //int[] arrRandom = new int[] { 94, 65, 12, 6, 72, 0, 55, 25, 3, 93, 34, 30, 66, 57, 24, 58, 98, 99, 83, 49, 1, 59, 73, 51, 97, 28, 17, 46, 67, 47, 95, 89, 69, 63, 76, 26, 23, 10, 74, 88, 68, 14, 81, 75, 38, 39, 54, 20, 41, 80, 84, 64, 82, 71, 33, 78, 45, 32, 18, 48, 27, 44, 87, 7, 2, 4, 96, 13, 9, 56, 90, 15, 11, 53, 5, 86, 37, 35, 36, 61, 21, 40, 85, 50, 8, 52, 29, 16, 19, 31, 42, 43, 77, 60, 79, 92, 70, 62, 22, 91 };
            Random random = new Random();
            int[] arrRandom = Enumerable.Range(0, 1000).Select(n => random.Next(10000)).ToArray();
            int[] arr = new int[arrRandom.Length];
            arrRandom.CopyTo(arr, 0);
            sw.Start();
            SortBox.InsertionSort(arr);
            sw.Stop();
            long insertT = sw.ElapsedTicks;
            arrRandom.CopyTo(arr, 0);
            sw.Restart();
            SortBox.ShellSort(arr);
            sw.Stop();
            long shellT = sw.ElapsedTicks;
            arrRandom.CopyTo(arr, 0);
            sw.Restart();
            SortBox.MergeSort(arr);
            sw.Stop();
            long mergeT = sw.ElapsedTicks;
            sw.Reset();
            Console.WriteLine($"\nInsert: {insertT}, shell: {shellT}, merge: {mergeT}");

            Console.WriteLine();
            #endregion

            #region Les 4
            // Op2 les 4

            FCNSNode<int> root = new FCNSNode<int>(7);
            root.Child = new FCNSNode<int>(2, new FCNSNode<int>(1, null, new FCNSNode<int>(5, new FCNSNode<int>(3))), new FCNSNode<int>(9));
            FCNSTree<int> tree = new FCNSTree<int>(root);
            tree.PrintPreOrder();

            // Op3
            BinaryTree<int> bTree = new BinaryTree<int>(
                new BinaryNode<int>()
                {
                    Data = 4,
                    Left = new BinaryNode<int>()
                    {
                        Data = 2,
                        Left = new BinaryNode<int>() { Data = 1 },
                        Right = new BinaryNode<int>() { Data = 3 }
                    },
                    Right = new BinaryNode<int>() { Data = 6 }
                });

            // op4
            Console.WriteLine(bTree.ToString());

            Console.WriteLine(bTree.Height());
            #endregion

            #region Les 5

            Console.WriteLine("Binary search tree");
            IBinarySearchTree searchTree = new BinarySearchTree(6);
            searchTree.Insert(4);
            searchTree.Insert(5);
            searchTree.Insert(7);
            searchTree.Insert(2);
            searchTree.Insert(3);
            Console.WriteLine(searchTree);
            searchTree.Remove(3);
            Console.WriteLine(searchTree);

            Console.WriteLine("\nBinary heap");
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            binaryHeap.Add(3);
            binaryHeap.Add(6);
            binaryHeap.Add(13);
            binaryHeap.Add(55);
            Console.WriteLine(binaryHeap.StringPreOrder());
            Console.WriteLine(binaryHeap.RemoveMin());
            Console.WriteLine(binaryHeap.StringPreOrder());
            Console.WriteLine(binaryHeap.RemoveMin());
            Console.WriteLine(binaryHeap.StringPreOrder());
            binaryHeap.AddFree(new int[] { 1, 7, 99, 21, 11 });
            Console.WriteLine(binaryHeap.StringPreOrder());
            binaryHeap.BuildHeap();
            while (binaryHeap.Size > 0)
                Console.Write($"{binaryHeap.RemoveMin()} ");
            Console.WriteLine("\n\n");

            #endregion

#endif
            #region Les 6

            Graph graph = new Graph();
            #region Make vertices
            graph.GetVertex("v0");
            graph.GetVertex("v1");
            graph.GetVertex("v2");
            graph.GetVertex("v3");
            graph.GetVertex("v4");
            graph.GetVertex("v5");
            graph.GetVertex("v6");
            #endregion
            graph.AddEdge("v0", "v1", 2);
            graph.AddEdge("v0", "v3", 1);
            graph.AddEdge("v1", "v3", 3);
            graph.AddEdge("v1", "v4", 10);
            graph.AddEdge("v2", "v0", 4);
            graph.AddEdge("v2", "v5", 5);
            graph.AddEdge("v3", "v2", 2);
            graph.AddEdge("v3", "v4", 2);
            graph.AddEdge("v3", "v5", 8);
            graph.AddEdge("v3", "v6", 4);
            graph.AddEdge("v4", "v6", 6);
            graph.AddEdge("v6", "v5", 1);
            Console.WriteLine(graph);
            graph.Unweighted("v3");
            graph.PrintPath("v1");
            graph.PrintPath("v4");
            graph.PrintPath("v5");
            graph.PrintPath("v6");

            #endregion
            


            Console.WriteLine("\n\n\nEND");
            Console.ReadLine();
        }
    }
}
