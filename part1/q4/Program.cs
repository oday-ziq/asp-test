using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = @"
                        Naar aanleiding van ons telefoongesprek op 24 oktober jl. wil ik bij
                        deze meer informatie verschaffen over onze cliënt Jan Pieterszoon Coen,
                        wonende op de Grote Singel 32 in Utrecht. J.P. Coen is sinds lange tijd
                        goede vriend van Michiel de Ruyter en zij woonden voorheen op het adres
                        Kleine Veemarkt 24 bis, in Amsterdam.";

        string pattern = @"\b(?:[A-Z][a-z]+|(?:[A-Z]\.){1,2})\s+(?:(?:de|van|van der|van den|v\.d\.)\s+)?[A-Z][a-z]+\b(?!\s+\d+)";

        Console.WriteLine("Extracted Names:");
        var matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
