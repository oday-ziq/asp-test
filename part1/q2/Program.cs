using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string sampleCode = @"
            /*
             * 1. This is a function to calculate square value of 'x'
             * The input is double (x)
             * The output is the 
             */
            public double Square(double x)
            {
                var result = x * x; // 2. Variable for storing result
                // 3. Result
                return result;
            }
            /* 4. This program has written by AnnTac. */
            ";

        string commentPattern = @"(\/\*[\s\S]*?\*\/)|(\/\/.*)";

        Console.WriteLine("=== Extracted Comments ===");
        var matches = Regex.Matches(sampleCode, commentPattern);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        Console.WriteLine("\n=== Code Only (Comments Removed) ===");
        var codeOnly = Regex.Replace(sampleCode, commentPattern, "").Trim();
        Console.WriteLine(codeOnly);
    }
}
