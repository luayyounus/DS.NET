using System;

namespace QuickSort
{
    class Program
    {
        public static void Main(string[] args)
        {
            QuickSortAlgorithm.arr = new int[] { 1, 5, 7, 3, 10, 2 };
            QuickSortAlgorithm.QuickSort(QuickSortAlgorithm.arr);
            foreach(int x in QuickSortAlgorithm.arr)
            {
                Console.WriteLine(x);
            }

            Console.ReadLine();
        }
    }

    public static class QuickSortAlgorithm
    {
        public static int[] arr = null;

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;
            int pivot = array[(left + right) / 2];
            int index = Partition(array, left, right, pivot);
            QuickSort(array, left, index - 1);
            QuickSort(array, index, right);
        }

        public static int Partition(int[] array, int left, int right, int pivot)
        {
            int temp;
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
            return left;
        }
    }
}
