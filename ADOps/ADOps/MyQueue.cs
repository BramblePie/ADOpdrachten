using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Get and remove front
        /// </summary>
        /// <returns>Front</returns>
        T Dequeue();

        /// <summary>
        /// Place at the back
        /// </summary>
        void Enqueue(T data);

        /// <summary>
        /// Get front
        /// </summary>
        /// <returns>Front</returns>
        T Front();
    }

    public class MyQueue<T> : IQueue<T>
    {
        private T[] array;
        private int size;

        public int Count { get => count; }
        private int count;

        private int f;
        private int b;

        public MyQueue() : this(8) { }

        public MyQueue(int size)
        {
            this.size = size;
            count = 0;
            array = new T[this.size];
            f = 0;
            b = -1;
        }

        public T Dequeue()
        {
            T data = Front();
            array[f] = default(T);
            f = Increment(f);
            return data;
        }

        public void Enqueue(T data)
        {
            if (count >= size)
                Requeue();
            b = Increment(b);
            array[b] = data;
            count++;
        }

        public T Front() => count > 0 ? array[f] : throw new NullReferenceException();

        private void Requeue()
        {
            MyQueue<T> queue = new MyQueue<T>(size * 2);
            for (int i = 0; i < size; i++)
                queue.Enqueue(Dequeue());
            array = queue.array;
            f = queue.f;
            b = queue.b;
            size = queue.size;
            count = queue.count;
        }

        private int Increment(int i) => (++i >= size) ? 0 : i;
    }
}
