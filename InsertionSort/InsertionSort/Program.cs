using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertionSortAlgorithm insertionSortAlgorithm = new InsertionSortAlgorithm();
            insertionSortAlgorithm.Array = new int[] { 3,5,1,93,6,32,1,0};
            insertionSortAlgorithm.InsertionSort();
            foreach(int x in insertionSortAlgorithm.Array)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }

    class InsertionSortAlgorithm
    {
        public int[] Array { get; set; }
        public void InsertionSort()
        {
            for(int i = 1; i< Array.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (Array[j] < Array[j - 1])
                    {
                        int temp = Array[j - 1];
                        Array[j - 1] = Array[j];
                        Array[j] = temp;
                    }
                    else break;
                }
            }
        }
    }
}
