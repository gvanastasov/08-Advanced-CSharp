namespace _03_NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    class NonDigitCount
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var pattern = "[^0-9]";
            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
