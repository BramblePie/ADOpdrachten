using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    public static class SortBox
    {
        public static void InsertionSort<Comparable>(Comparable[] arr) where Comparable : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                Comparable tmp = arr[i];
                int j = i;
                for (; j > 0 && tmp.CompareTo(arr[j - 1]) < 0; j--)
                    arr[j] = arr[j - 1];
                arr[j] = tmp;
            }
        }

        public static void ShellSort<Comparable>(Comparable[] arr) where Comparable : IComparable
        {
            for (int gap = arr.Length / 2; gap > 0; gap = gap == 2 ? 1 : (int)(gap / 2.2))
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    Comparable tmp = arr[i];
                    int j = i;
                    for (; j >= gap && tmp.CompareTo(arr[j - gap]) < 0; j -= gap)
                        arr[j] = arr[j - gap];
                    arr[j] = tmp;
                }
            }
        }

        public static void MergeSort<T>(T[] arr) where T : IComparable
        {
            T[] tmp = new T[arr.Length];
            MergeSort(arr, tmp, 0, arr.Length - 1);
        }

        private static void MergeSort<T>(T[] arr, T[] tmp, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int centre = (left + right) / 2;
                MergeSort(arr, tmp, left, centre);
                MergeSort(arr, tmp, centre + 1, right);
                Merge(arr, tmp, left, centre + 1, right);
            }
        }

        private static void Merge<T>(T[] arr, T[] tmp, int leftPos, int rightPos, int right) where T : IComparable
        {
            int left = rightPos - 1;
            int tmpPos = leftPos;
            int count = right - leftPos + 1;

            while (leftPos <= left && rightPos <= right)
            {
                if (arr[leftPos].CompareTo(arr[rightPos]) <= 0)
                    tmp[tmpPos++] = arr[leftPos++];
                else
                    tmp[tmpPos++] = arr[rightPos++];
            }

            while (leftPos <= left)
                tmp[tmpPos++] = arr[leftPos++];

            while (rightPos <= right)
                tmp[tmpPos++] = arr[rightPos++];

            for (int i = 0; i < count; i++, right--)
                arr[right] = tmp[right];
        }
    }
}
