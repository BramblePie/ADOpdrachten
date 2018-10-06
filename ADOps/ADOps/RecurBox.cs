using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public static class RecurBox
    {
        /// <summary>
        /// Calculate n!
        /// </summary>
        /// <param name="n">Number to factorial</param>
        /// <param name="recursive">Do recursive?</param>
        /// <returns></returns>
        public static ulong Factorial(uint n, bool recursive = true)
        {
            if (recursive)
                return FactorialRecurive(n);
            return FactorialLoop(n);
        }

        /// <summary>
        /// Calculate first n number of fibonacci numbers
        /// </summary>
        /// <param name="n">Number of fibonacci numbers</param>
        /// <param name="recursive">Do recursive?</param>
        /// <returns></returns>
        public static int[] Fibonacci(int n, bool recursive = true)
        {
            if (recursive)
                return FibonacciRecursive(n, new int[n]);
            return FibonacciLoop(n);
        }

        /// <summary>
        /// Sum of every other number down from n
        /// </summary>
        /// <param name="n">From n</param>
        /// <returns></returns>
        public static int OmEnOm(int n)
        {
            if (n <= 2)
                return n;
            return n + OmEnOm(n - 2);
        }

        /// <summary>
        /// Count all the ones in binary rep
        /// </summary>
        /// <param name="n">Number to count in</param>
        /// <returns></returns>
        public static int OnesInBinary(int n)
        {
            return (((n & 1) == 1) ? 1 : 0) + OnesInBinary(n, 2);
        }

        /// <summary>
        /// Print list from index
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="i">Index</param>
        public static void PrintForward(List<int> list, int i)
        {
            if (list.Count == i)
                return;
            Console.Write(list[i]);
            PrintForward(list, i + 1);
        }

        public static void PrintBackward(List<int> list, int i)
        {
            if (list.Count == i)
                return;
            PrintBackward(list, i + 1);
            Console.Write(list[i]);
        }

        private static int OnesInBinary(int n, int i)
        {
            if (i > n)
                return 0;
            return (((n & i) == i) ? 1 : 0) + OnesInBinary(n, i * 2);
        }

        private static int[] FibonacciLoop(int n)
        {
            int[] ans = new int[n];
            ans[0] = 0;
            ans[1] = 1;
            for (int i = 2; i < n; i++)
                ans[i] = ans[i - 1] + ans[i - 2];
            return ans;
        }

        private static int[] FibonacciRecursive(int n, int[] ans)
        {
            if (n <= 2)
            {
                ans[0] = 0;
                ans[1] = 1;
                return ans;
            }
            ans[n - 1] = FibonacciRecursive(n - 1, ans)[n - 2] + FibonacciRecursive(n - 2, ans)[n - 3];
            return ans;
        }

        private static ulong FactorialLoop(uint n)
        {
            ulong ans = 1;
            for (ulong i = 2; i <= n; i++)
                ans *= i;

            return ans;
        }

        private static ulong FactorialRecurive(uint n)
        {
            if (n <= 2)
                return 2;
            return n * FactorialRecurive(n - 1);
        }
    }
}
