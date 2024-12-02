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
            
            // Check if difference is within valid range (1 to 3 or -3 to -1)
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            // Check if sequence breaks increasing/decreasing pattern
            if (diff > 0) isDecreasing = false;
            if (diff < 0) isIncreasing = false;
        }

        return isIncreasing || isDecreasing;
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
            
            if (IsSafeReport(report))
                safeCount++;
        }

        Console.WriteLine($"Number of safe reports: {safeCount}");
    }
}