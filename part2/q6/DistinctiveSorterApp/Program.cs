using System;

class Program
{
    static void Main()
    {
        var testCases = new[]
        {
            new int[] { 5, 6, 2, 5, 4, 9, 4, 5 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 10, 3, 7, 10, 2 },
            new int[] { },
            null
        };

        Console.WriteLine("Distinctive Sorting Results:\n");
        foreach (var test in testCases)
        {
            var result = DistinctiveSorter.DistinctSort(test);
            Console.WriteLine($"Input: [{(test == null ? "" : string.Join(", ", test))}] → Output: [{string.Join(", ", result)}]");
        }
    }
}

