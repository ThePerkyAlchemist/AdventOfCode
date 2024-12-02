// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static bool IsSafeReport(int[] report)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 0; i < report.Length - 1; i++)
        {
            int diff = report[i + 1] - report[i];
            
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            if (diff > 0) isDecreasing = false;
            if (diff < 0) isIncreasing = false;
        }

        return isIncreasing || isDecreasing;
    }

    static bool CanBeMadeSafe(int[] report)
    {
        // First check if it's already safe
        if (IsSafeReport(report))
            return true;

        // Try removing each number one at a time
        for (int i = 0; i < report.Length; i++)
        {
            int[] newReport = new int[report.Length - 1];
            int newIndex = 0;
            
            // Create a new array without the current number
            for (int j = 0; j < report.Length; j++)
            {
                if (j != i)
                    newReport[newIndex++] = report[j];
            }

            if (IsSafeReport(newReport))
                return true;
        }

        return false;
    }

    static void Main()
    {
        Console.WriteLine("Enter number of reports:");
        int n = int.Parse(Console.ReadLine());
        
        int safeCount = 0;

        Console.WriteLine("Enter reports (space-separated numbers):");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] report = Array.ConvertAll(input, int.Parse);
            
            if (CanBeMadeSafe(report))
                safeCount++;
        }

        Console.WriteLine($"Number of safe reports: {safeCount}");
    }
}
