using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var reports = new List<int[]>();
        string filePath = "input.txt"; // Ensure this path is correct

        try
        {
            using (var sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(' ');
                    int[] arrNum = new int[parts.Length];
                    for (int i = 0; i < parts.Length; i++)
                    {
                        arrNum[i] = int.Parse(parts[i]);
                        Console.Write(arrNum[i] + " ");
                    }
                    reports.Add(arrNum);
                    Console.WriteLine();
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"File not found: {e.FileName}");
            return;
        }

        int safe = 0;

        for (int i = 0; i < reports.Count; i++)
        {
            bool success = IsSafeReport(reports[i]);
            if (!success)
            {
                for (int j = 0; j < reports[i].Length; j++)
                {
                    int[] modifiedReport = reports[i].Where((_, index) => index != j).ToArray();
                    if (IsSafeReport(modifiedReport))
                    {
                        success = true;
                        break;
                    }
                }
            }
            if (success) safe++;
        }

        Console.WriteLine($"Number of safe reports: {safe}");
    }

    static bool IsSafeReport(int[] report)
    {
        for (int y = 0; y < report.Length - 1; y++)
        {
            int a = report[y];
            int b = report[y + 1];

            if (Math.Abs(a - b) > 3 || Math.Abs(a - b) == 0)
            {
                return false;
            }
        }

        var sortedArray = (int[])report.Clone();
        Array.Sort(sortedArray);
        if (report.SequenceEqual(sortedArray) || report.SequenceEqual(sortedArray.Reverse().ToArray()))
        {
            return true;
        }

        return false;
    }
}