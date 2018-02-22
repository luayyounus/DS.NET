using System;
using System.Collections.Generic;

namespace NumberOfPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            // Block at first cell/box
            int[] blockOne = new int[] { 4, 4 };
            int[] blockTwo = new int[] { 1, 3 };

            // List of Blocks
            List<int[]> listOfBlocks = new List<int[]>();
            listOfBlocks.Add(blockOne);
            listOfBlocks.Add(blockTwo);

            Console.WriteLine($"4 X 4 Grid = {CalculatePaths(4, 4, listOfBlocks)} Paths without Recursion with block at the end");

            Console.WriteLine($"2 X 2 Grid = { CalculatePaths(2, 2, null)} Paths without recursion and NO blocks");

            Console.WriteLine($"3 X 3 Grid = {CalculatePathsWithRecursion(3, 3)} Paths with Recursion");

            Console.ReadLine();
        }

        // With nested For loops
        public static int CalculatePaths(int m, int n, List<int[]> blocks)
        {
            int[,] paths = new int[m, n];

            //Stretch goal - Check if there's a block preventing the path from starting or ending
            if (blocks != null)
                foreach (int[] x in blocks)
                    paths[x[0] - 1, x[1] - 1] = -1; // Adding -1 to represent a block in the grid  

            // Checking if first or end have blocks
            if (paths[0, 0] == -1 || paths[m - 1, n - 1] == -1) return 0;

            // Eg.3 x 3
            // --------
            // 1  1  1
            // 1  0  0
            // 1  0  0
            // --------
            for (int i = 0; i < m; i++)
            {
                paths[i, 0] = 1;
                paths[0, i] = 1;
            }

            // // --------
            // 1  1  1
            // 1  2  3   <- 2 is the sum of both the values above it and on the left of it... same goes for 3
            // 1  3  6   <- 6 is the sum of both the values above it and on the left of it
            // --------
            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    paths[i, j] = paths[i - 1, j] + paths[i, j - 1]; // to include diagonal, we sum it with 

            return paths[m - 1, n - 1]; // return the most lower right corner value
        }

        // With Recursion
        public static int CalculatePathsWithRecursion(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            int left = CalculatePathsWithRecursion(m - 1, n);
            int right = CalculatePathsWithRecursion(m, n - 1);
            int allPaths = left + right;
            return allPaths;
        }
    }
}
