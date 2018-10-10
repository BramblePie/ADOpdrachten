using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface IBinaryHeap
    {
        void Add(int n);
        int FindMin();
        int RemoveMin();
    }

    public class BinaryHeap : IBinaryHeap
    {
        private int[] array;

        /// <summary>
        /// Number of elements in array. 
        /// Index 0 is 0, thus 'last' is index of last element
        /// </summary>
        private int last;

        public int Size { get => last; }

        #region Constructors

        public BinaryHeap(int[] array)
        {
            this.array = new int[array.Length + 1];
            last = array.Length;
            // All initial elements to heap array, index 0 is 0
            for (int i = 1; i <= last; i++)
                this.array[i] = array[i - 1];
            BuildHeap();
        }

        public BinaryHeap(int capacity)
        {
            array = new int[capacity];
            last = 0;
        }

        public BinaryHeap() : this(8) { }

        #endregion

        /// <summary>
        /// No percolation add
        /// </summary>
        /// <param name="n">n to add to heap</param>
        public void AddFree(int n)
        {
            if (last + 1 >= array.Length)
                RedoArray();
            array[++last] = n;
        }

        /// <summary>
        /// Add all elements of given array without percolation
        /// </summary>
        /// <param name="array">Given array</param>
        public void AddFree(int[] array)
        {
            while (last + array.Length > this.array.Length)
                RedoArray();

            for (int i = 1; i <= array.Length; i++)
                this.array[last + i] = array[i - 1];

            last += array.Length;
        }

        public void BuildHeap()
        {
            for (int i = last / 2; i > 0; i--)
                PercolateDown(i);
        }

        /// <summary>
        /// Add n to heap
        /// </summary>
        /// <param name="n">n to add to heap</param>
        public void Add(int n)
        {
            AddFree(n);
            PercolateUp(last);
        }

        /// <summary>
        /// Swap indices i and j
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="j">index</param>
        private void Swap(int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        private void RedoArray()
        {
            int[] newArr = new int[array.Length * 2];
            for (int i = 1; i < array.Length; i++)
                newArr[i] = array[i];
            array = newArr;
        }

        /// <summary>
        /// Shows minimun
        /// </summary>
        /// <returns>Minimun value in heap</returns>
        public int FindMin()
        {
            if (last > 0)
                return array[1];
            throw new NullReferenceException();
        }

        /// <summary>
        /// Show and delete minimun
        /// </summary>
        /// <returns>Minimun value in heap</returns>
        public int RemoveMin()
        {
            int min = FindMin();
            array[1] = array[last];
            array[last] = 0;
            last--;
            PercolateDown(1);
            return min;
        }

        private void PercolateUp(int i)
        {
            for (; array[i / 2] > array[i]; i /= 2)
                Swap(i / 2, i);
        }

        public void PercolateDown(int i)
        {
            int j;
            int tmp = array[i];
            for (; i * 2 <= last; i = j)
            {
                j = i * 2;
                if (last > j + 1 && (array[j + 1] < array[j]))
                    j++;
                if (array[j] < tmp)
                    array[i] = array[j];
                else
                    break;
            }
            array[i] = tmp;
        }

        public string StringPreOrder()
        {
            string str = "PreOrder: [ ";
            str += StringPreOrder(1) + " ]";
            return str;
        }

        private string StringPreOrder(int i)
        {
            if (i * 2 + 1 <= last)
                return $"{array[i]}, {StringPreOrder(i * 2)}, {StringPreOrder(i * 2 + 1)}";
            if (i * 2 <= last)
                return $"{array[i]}, {StringPreOrder(i * 2)}";

            return $"{array[i]}";
        }

        public override string ToString()
        {
            if (last < 1)
                return "[ ]";
            return ToString(1);
        }

        private string ToString(int i)
        {
            if (i * 2 + 1 <= last)
                return $"[ {ToString(i * 2)} {array[i]} {ToString(i * 2 + 1)} ]";
            if (i * 2 <= last)
                return $"[ {ToString(i * 2)} {array[i]} ]";
            return $"[ {array[i]} ]";
        }
    }
}
