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

        List<int> listA = new List<int>();
        List<int> listB = new List<int>();

        // Parse input into two lists
        foreach (string inputLine in inputLines)
        {
            string[] parts = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listA.Add(int.Parse(parts[0]));
            listB.Add(int.Parse(parts[1]));
        }

        // Calculate and print result
        int result = CalculateDistance(listA, listB);
        Console.WriteLine($"Total distance: {result}");
    }

    public static int CalculateDistance(List<int> listA, List<int> listB)
    {
        var sortedA = listA.OrderBy(x => x).ToList();
        var sortedB = listB.OrderBy(x => x).ToList();
        
        int distance = 0;
        for (int i = 0; i < sortedA.Count; i++)
        {
            distance += Math.Abs(sortedA[i] - sortedB[i]);
        }
        
        return distance;
    }
}