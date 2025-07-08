using System;

class Program
{
    static void Main()
    {
        var testCases = new[]
        {
            "level",
            "605506",
            "live on time emit no evil",
            "Was it a car or a cat I saw?",
            "Not a palindrome",
            " ",
            "",
            "A man, a plan, a canal: Panama"
        };

        Console.WriteLine("Palindrome Test Results:\n");
        foreach (var test in testCases)
        {
            bool result = PalindromeChecker.IsPalindrome(test);
            Console.WriteLine($"Input: \"{test}\" → Result: {result}");
        }
    }
}
