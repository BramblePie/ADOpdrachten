using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IStack<T>
    {
        /// <summary>
        /// Look and pop top
        /// </summary>
        /// <returns>Top data</returns>
        T Pop();

        /// <summary>
        /// Push data to top
        /// </summary>
        /// <param name="data">Data</param>
        void Push(T data);

        /// <summary>
        /// Look at top
        /// </summary>
        /// <returns>Top data</returns>
        T Top();
    }

    public class MyStack<T> : IStack<T>
    {
        private MyNode<T> head = null;

        public bool CheckBrackets(string s)
        {
            MyStack<bool> brackets = new MyStack<bool>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                        brackets.Push(true);
                        break;
                    case ')':
                        if (!brackets.Pop())
                            return false;
                        break;
                }
            }
            return !brackets.Pop();
        }

        public bool CheckBrackets2(string s)
        {
            MyStack<byte> brackets = new MyStack<byte>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                        brackets.Push(1);
                        break;
                    case ')':
                        if (brackets.Pop() != 1)
                            return false;
                        break;
                    case '[':
                        brackets.Push(2);
                        break;
                    case ']':
                        if (brackets.Pop() != 2)
                            return false;
                        break;
                }
            }
            return !(brackets.Pop() != 0 || brackets.Pop() != 0);
        }

        public T Pop()
        {
            if (head == null)
                return default(T);
            T data = head.Data;
            head = head.Next;
            return data;
        }

        public void Push(T data) => head = new MyNode<T>() { Data = data, Next = head };

        public T Top()
        {
            if (head == null)
                return default(T);
            return head.Data;
        }

        private class MyNode<U>
        {
            public U Data { get; set; }
            public MyNode<U> Next { get; set; }
        }
    }
}
