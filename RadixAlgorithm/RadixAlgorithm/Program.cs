using System;
using System.Collections.Generic;
using System.Linq;

namespace RadixAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedArray = new int[] { 5, 15, 2, 6, 85, 10, 1345, 99, 0, 243 };
            int[] result = Sort(unsortedArray);
            foreach (int x in result) Console.Write(x + " ");
            Console.ReadLine();
        }

        public static int[] Sort(int[] array)
        {
            return RadixSortAux(array, 1);
        }

        static int[] RadixSortAux(int[] array, int digit)
        {
            bool empty = true;

            List<int>[] current = new List<int>[10];
            for(int j = 0; j < array.Length; j++)
            {
                current[j] = new List<int>();
            }
            for (int i = 0; i < array.Length; i++)
            {
                int index = (array[i] / digit) % 10;
                current[index].Add(array[i]);
                if (array[i] / digit != 0)
                    empty = false;
            }

            int[] sortedArray = current.SelectMany(x => x).ToArray();

            if (empty) return sortedArray;

            return RadixSortAux(sortedArray, digit * 10);
        }
    }
}
