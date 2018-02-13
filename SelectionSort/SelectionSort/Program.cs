using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsrotedArray = new int[] {1,9,2,19,3,4,5,6,7,8 };

            var result = SelectionSortMethod(unsrotedArray);
            foreach(int x in result)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
        public static int[] SelectionSortMethod(int[] something)
        {
            for(int i = 0; i < something.Length; i++)
            {
                for(int j = i; j < something.Length; j++)
                {
                    if(something[j] < something[i])
                    {
                        int temp = something[i];
                        something[i] = something[j];
                        something[j] = temp;
                    }
                }
            }
            return something;
        }
    }
}
