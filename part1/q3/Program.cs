using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string references = @"
            1. W. H. Wolberg, O. L. Mangasarian, ""Multisurface..."", 1990.
            2. D. Delen, G. Walker, A. Kadam, ""Predicting..."", 2005.
            3. A. Niwińska, M. Murawska, ""New breast cancer..."", 2012.
            4. J. R. Quinlan, ""Induction of decision trees..."", 1986.
            5. U. M. Fayyad, K. B. Irani, ""On the handling..."", 1992.
            6. Y. Wang, I. H. Witten, ""Induction of model trees..."", 1997.
            7. W. Sun, J. Chen, J. Li, ""Decision tree..."", 2007.
            8. K. Sinapiromsaran, N. Techaval, ""Network intrusion..."", 2012.
            9. T. Curk, J. Demsar, Q. Xu, ""Microarray..."", 2005.
            ";

        string pattern = @"^\s*\d+\.\s+([A-Z]\.\s?(?:[A-Z]\.\s?)?[A-Z][a-zA-ZÀ-ÿ]*)[^0-9]*?(\d{4})";

        Console.WriteLine("First Author and Year:");
        var matches = Regex.Matches(references, pattern, RegexOptions.Multiline);
        foreach (Match match in matches)
        {
            Console.WriteLine($"Author: {match.Groups[1].Value}, Year: {match.Groups[2].Value}");
        }
    }
}
