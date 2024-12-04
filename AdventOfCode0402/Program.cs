using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] wordSearch = File.ReadAllLines("input.txt");
            int result = CountXMasPatterns(wordSearch);
            Console.WriteLine($"X-MAS is in the puzzle " +result+ " times");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int CountXMasPatterns(string[] grid)
    {
        int count = 0;
        int rows = grid.Length;
        int cols = rows > 0 ? grid[0].Length : 0;

        for (int row = 1; row < rows - 1; row++)
        {
            for (int col = 1; col < cols - 1; col++)
            {
                if (grid[row][col] == 'A')
                {
                    if (IsValidXMas(grid, row, col))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    static bool IsValidXMas(string[] grid, int centerRow, int centerCol)
    {
        // Check all possible combinations of MAS in X pattern
        char topLeft = grid[centerRow - 1][centerCol - 1];
        char topRight = grid[centerRow - 1][centerCol + 1];
        char bottomLeft = grid[centerRow + 1][centerCol - 1];
        char bottomRight = grid[centerRow + 1][centerCol + 1];

        bool hasFirstMas = IsMas(topLeft, grid[centerRow][centerCol], bottomRight) ||
                          IsMas(bottomRight, grid[centerRow][centerCol], topLeft);

        bool hasSecondMas = IsMas(topRight, grid[centerRow][centerCol], bottomLeft) ||
                           IsMas(bottomLeft, grid[centerRow][centerCol], topRight);

        return hasFirstMas && hasSecondMas;
    }

    static bool IsMas(char first, char middle, char last)
    {
        return (first == 'M' && middle == 'A' && last == 'S') ||
               (first == 'S' && middle == 'A' && last == 'M');
    }
}