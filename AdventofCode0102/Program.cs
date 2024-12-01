// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Read all input lines until empty line
        List<string> inputLines = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null && line != "")
        {
            inputLines.Add(line);
        }

        List<long> listA = new List<long>();
        List<long> listB = new List<long>();

        // Parse input into two lists
        foreach (string inputLine in inputLines)
        {
            string[] parts = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listA.Add(long.Parse(parts[0]));
            listB.Add(long.Parse(parts[1]));
        }

        // Calculate and print result
        long result = CalculateSimilarityScore(listA, listB);
        Console.WriteLine($"Similarity Score: {result}");
    }

    public static long CalculateSimilarityScore(List<long> listA, List<long> listB)
    {
        // Create a dictionary to count occurrences in listB
        Dictionary<long, int> countInB = new Dictionary<long, int>();
        foreach (long num in listB)
        {
            if (!countInB.ContainsKey(num))
                countInB[num] = 0;
            countInB[num]++;
        }

        // Calculate similarity score
        long totalScore = 0;
        foreach (long num in listA)
        {
            int count = countInB.ContainsKey(num) ? countInB[num] : 0;
            totalScore += num * count;
        }
        
        return totalScore;
    }
}
