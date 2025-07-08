class Program
{
    static void Main()
    {
        int[] input = {
            7, 42, 93, 128, 15, 67, 184, 36, 109, 51,
            172, 25, 88, 143, 19, 74, 157, 3, 112, 60,
            198, 31, 103, 46, 179, 22, 85, 134, 11, 68,
            149, 54, 191, 38, 117, 79, 162, 8, 95, 27
        };
        int target = 500;

        Console.WriteLine($"Searching subsets summing to {target}...");

        var results = PerfectSumFinder.FindPerfectSums(input, target);

        Console.WriteLine($"Found {results.Count} subsets:\n");
        foreach (var subset in results)
        {
            Console.WriteLine($"[{string.Join(", ", subset)}]");
        }
    }
}
