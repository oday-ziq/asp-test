using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string sampleText = @"
        Mrs. Beth Boren imperdiet enim placerat...
        willy_wals8@gmail.com
        1-3270-72512-82-9
        1995-11-30
        08-1234-5678
        1117-8578-6969-7741";

        var patterns = new Dictionary<string, string>
        {
            { "Title + Name + Surname", @"(?:Mr|Mrs|Ms|Dr|Prof)\.\s+[A-Z][a-z]+\s+[A-Z][a-z]+" },
            { "Email", @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}" },
            { "Phone Number", @"\d{2}-\d{4}-\d{4}" },
            { "Credit Card Number", @"\d{4}-\d{4}-\d{4}-\d{4}" },
            { "SSN-like ID", @"\d{1}-\d{4}-\d{5}-\d{2}-\d" },
            { "Birthdate", @"\d{4}-\d{2}-\d{2}" }
        };

        foreach (var item in patterns)
        {
            Console.WriteLine($"\n{item.Key}:");
            var matches = Regex.Matches(sampleText, item.Value);
            foreach (Match match in matches)
            {
                Console.WriteLine($"  {match.Value}");
            }
        }
    }
}
