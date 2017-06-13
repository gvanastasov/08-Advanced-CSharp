namespace _01_MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    class MatchCount
    {
        static void Main()
        {
            var pattern = Console.ReadLine();

            var regex = new Regex(pattern);
            var text = Console.ReadLine();

            var matches = regex.Matches(text);

            Console.WriteLine(matches.Count);
        }
    }
}
