using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCSharpSolutions._1_1765_Map_of_Highest_Peak
{
    class Solution
    {
        public int[][] HighestPeak(int[][] isWater)
        {
            int rows = isWater.Length;
            int cols = isWater[0].Length;
            Console.WriteLine($"Rows: {rows}, Columns: {cols}");

            if (rows == cols && cols == 1)
                return new int[][] { new int[] { 0 } };


            // Create a jagged array 
            int[][] height = new int[rows][];

            // Initialize the jagged array
            for (int i = 0; i < rows; i++)
            {
                height[i] = new int[cols];
            }

            // Transform and flip the matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Apply transformation rules
                    if (isWater[i][j] == 0)
                    {
                        height[i][j] = 1;
                    }
                }
            }

            int maxIterations = rows + cols - 2;

            int left, right, up, down, min;

            for (int iter = 1; iter <= maxIterations; iter++)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        // TODO: Improve so that first row won't check 'up'
                        // same with first elemnt not checking 'left'
                        // last col not checking 'right'
                        // and last row not checking 'down'
                        if (height[r][c] == iter)
                        {
                            left = c > 0 ? height[r][c - 1] : int.MaxValue;
                            right = c + 1 < cols ? height[r][c + 1] : int.MaxValue;
                            up = r > 0 ? height[r - 1][c] : int.MaxValue;
                            down = r + 1 < rows ? height[r + 1][c] : int.MaxValue;

                            min = Math.Min(Math.Min(left, right), Math.Min(up, down));
                            height[r][c] = min + 1;
                        }
                    }
                }
            }

            return height;
        }
    }
}
