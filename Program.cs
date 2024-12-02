using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "input.txt";
        int difference = 0;
        int similarity = 0;

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        foreach (string line in File.ReadLines(filePath)) {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2) {
                left.Add(int.Parse(parts[0]));
                right.Add(int.Parse(parts[1]));
            }
        }

        left.Sort();
        right.Sort();

        for (int i = 0; i < left.Count() && i < right.Count(); i++) {
            difference += Math.Abs(left[i] - right[i]);
        }

        var rightCounts = right.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        foreach (int number in left)
        {
            if (rightCounts.ContainsKey(number))
            {
                similarity += number * rightCounts[number];
            }
        }

        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Similarity: {similarity}");
    }
}
