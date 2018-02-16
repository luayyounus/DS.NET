using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 7, 9, 3, 5, 6, 4, 8 };
            MergeSortAlgorithm.MergeSort(arr, 0, arr.Length - 1);
            foreach (int x in arr) Console.WriteLine(x);
            Console.ReadLine();
        }
    }

    public static class MergeSortAlgorithm
    {
        public static void MergeSort(int[] array, int min, int max)
        {
            if (max - min < 1) return;
            int middle = (min + max) / 2;
            MergeSort(array, min, middle);
            MergeSort(array, middle + 1, max);
            MergeHalves(array, min, max);
        }

        public static void MergeHalves(int[] array, int min, int max)
        {
            int[] tempArray = new int[array.Length];

            int leftEnd = (max + min) / 2;
            int rightStart = leftEnd + 1;
            int size = max - min + 1;

            int left = min;
            int right = rightStart;
            int k = min;

            while (left <= leftEnd && right <= max)
            {
                if (array[left] <= array[right])
                {
                    tempArray[k] = array[left];
                    left++;
                }
                else
                {
                    tempArray[k] = array[right];
                    right++;
                }
                k++;
            }

            for (int i = 0; i <= leftEnd - left; i++)
            {
                tempArray[k] = array[left];
                left++;
                k++;
            }

            for (int j = 0; j <= max - right; j++)
            {
                tempArray[k] = array[right];
                right++;
                k++;
            }

            for (int m = 0; m < size; m++)
            {
                array[min] = tempArray[min];
                min++;
            }
        }
    }
}
