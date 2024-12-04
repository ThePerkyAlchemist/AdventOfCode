using System;
using System.IO;

class Program
{
    private static readonly (int dr, int dc)[] Directions = new[]
    {
        (0, 1), (1, 0), (1, 1), (1, -1),
        (0, -1), (-1, 0), (-1, -1), (-1, 1)
    };

    static void Main()
    {
        try
        {
            string[] wordSearch = File.ReadAllLines("input.txt");
            int result = FindAllXmas(wordSearch);
            Console.WriteLine($"XMAS is in the puzzle " +result+ " times");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int FindAllXmas(string[] wordSearch)
    {
        const string word = "XMAS";
        int wordLen = word.Length;
        int count = 0;
        int rows = wordSearch.Length;
        int cols = rows > 0 ? wordSearch[0].Length : 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                foreach (var (dr, dc) in Directions)
                {
                    int endRow = row + (wordLen - 1) * dr;
                    int endCol = col + (wordLen - 1) * dc;

                    if (endRow >= 0 && endRow < rows && endCol >= 0 && endCol < cols)
                    {
                        string foundWord = "";
                        for (int k = 0; k < wordLen; k++)
                        {
                            int r = row + k * dr;
                            int c = col + k * dc;
                            foundWord += wordSearch[r][c];
                        }
                        
                        if (foundWord == word)
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }
}