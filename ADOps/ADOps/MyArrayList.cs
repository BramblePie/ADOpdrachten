using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public interface ISimpleArrayList
    {
        // Toevoegen aan het einde van de lijst, mits de lijst niet vol is 
        void Add(int n);
        // O(1)

        // Maak de list leeg 
        void Clear();
        // O(1)

        // Tel hoe vaak het gegeven getal voorkomt 
        int CountOccurences(int n);
        // O(N)

        // Haal de waarde op van een bepaalde index 
        int Get(int index);
        // O(1)

        // Wijzig een item op een bepaalde index 
        void Set(int index, int n);
        // O(1)

        // Print de inhoud van de list 
        void Print();
        // O(N)
    }

    public class MyArrayList : ISimpleArrayList
    {
        private int[] array;
        private int i;

        public MyArrayList() : this(8) { }

        public MyArrayList(int capacity) : this((long)capacity) { }

        public MyArrayList(long capacity)
        {
            array = new int[capacity];
            i = 0;
        }

        private void RedoArray()
        {
            int[] newArray = new int[array.LongLength * 2];
            for (long j = 0; j < array.LongLength; j++)
                newArray[j] = array[j];
            array = newArray;
        }

        public void Add(int n)
        {
            if (i + 1 >= array.LongLength)
                RedoArray();
            array[i++] = n;
        }

        public void Clear()
        {
            array = new int[array.LongLength];
            i = 0;
        }

        public int CountOccurences(int n)
        {
            int count = 0;
            for (long j = 0; j < array.LongLength; j++)
            {
                if (array[j] == n)
                    count++;
            }
            return count;
        }

        public int Get(int index)
        {
            return array[index];
        }

        public void Set(int index, int n)
        {
            if (index > i)
                throw new IndexOutOfRangeException();

            array[index] = n;
        }

        public void Print()
        {
            string str = "[";
            for (int j = 0; j < i; j++)
            {
                str += array[j] + ", ";
            }
            str = str.TrimEnd(' ').TrimEnd(',') + ']';
            Console.WriteLine(str);
        }
    }
}
