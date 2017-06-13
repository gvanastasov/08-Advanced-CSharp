namespace _02_VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    class VowelsCount
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var pattern = "[AOUIEYaouiey]";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
