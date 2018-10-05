using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface ISimpleLinkedList<T>
    {
        // Voeg een item toe aan het begin van de lijst void addFirst(T data);
        void Clear();
        // O(1)

        void Print();
        // O(N)

        // Voeg een item in op een bepaalde index (niet overschrijven!) 
        void Insert(int index, T data);
        // O(N)

        // verwijder het eerste item 
        void RemoveFirst();
        // O(1)

        // geeft het eerste item terug 
        T GetFirst();
        // O(1)
    }

    public class MyLinkedList<T> : ISimpleLinkedList<T>
    {
        private MyNode<T> head;

        public MyLinkedList() => head = new MyNode<T>(default(T), null);

        public void Add(T data)
        {
            MyNode<T> node = new MyNode<T>(data, null);
            MyNode<T> i;
            for (i = head; i.Next != null; i = i.Next) ;
            i.Next = node;
        }

        public void Clear() => head.Next = null;

        public T GetFirst() => head.Next != null ? head.Next.Data : default(T);

        public void Insert(int index, T data)
        {
            MyNode<T> node = head;
            for (int i = 0; i < index; i++)
            {
                if (node == null)
                    throw new IndexOutOfRangeException();
                node = node.Next;
            }

            MyNode<T> insert = new MyNode<T>(data, node.Next);
            node.Next = insert;
        }

        public void Print()
        {
            string str = "[";
            for (MyNode<T> i = head.Next; i != null; i = i.Next)
                str += $"{i.Data}, ";

            str = str.TrimEnd(' ').TrimEnd(',') + "]";
            Console.WriteLine(str);
        }

        public void RemoveFirst() => head = head.Next ?? head;

        private class MyNode<U>
        {
            public MyNode(U data, MyNode<U> next)
            {
                Data = data;
                Next = next;
            }

            public U Data { get; set; }
            public MyNode<U> Next { get; set; }
        }
    }

}
