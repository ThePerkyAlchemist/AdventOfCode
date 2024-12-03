// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static int ProcessCorruptedMemory(string memory)
    {
        string mulPattern = @"mul\(([1-9]\d{0,2}),([1-9]\d{0,2})\)";
        string controlPattern = @"(?:do|don't)\(\)";
        
        bool enabled = true;
        int sum = 0;
        int currentPosition = 0;
        
        // Find all mul instructions and control instructions
        var mulMatches = Regex.Matches(memory, mulPattern);
        var controlMatches = Regex.Matches(memory, controlPattern);
        int controlIndex = 0;
        
        foreach (Match mul in mulMatches)
        {
            // Check if there are any control instructions before this mul
            while (controlIndex < controlMatches.Count && 
                   controlMatches[controlIndex].Index < mul.Index)
            {
                enabled = controlMatches[controlIndex].Value == "do()";
                controlIndex++;
            }
            
            if (enabled)
            {
                int x = int.Parse(mul.Groups[1].Value);
                int y = int.Parse(mul.Groups[2].Value);
                sum += x * y;
            }
        }
        
        return sum;
    }

    static void Main()
    {
        string corruptedMemory = File.ReadAllText("input.txt");
        int result = ProcessCorruptedMemory(corruptedMemory);
        Console.WriteLine($"Sum of enabled multiplication results: {result}");
    }
}
