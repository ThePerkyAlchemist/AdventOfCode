using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

class Program
{
    static int ProcessCorruptedMemory(string memory)
    {
        string pattern = @"mul\(([1-9]\d{0,2}),([1-9]\d{0,2})\)";
        var matches = Regex.Matches(memory, pattern);
        
        return matches.Sum(match => 
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            return x * y;
        });
    }

    static void Main()
    {
        try
        {
            string corruptedMemory = File.ReadAllText("input.txt");
            int result = ProcessCorruptedMemory(corruptedMemory);
            Console.WriteLine($"Sum of all multiplication results: {result}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: input.txt file not found");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}