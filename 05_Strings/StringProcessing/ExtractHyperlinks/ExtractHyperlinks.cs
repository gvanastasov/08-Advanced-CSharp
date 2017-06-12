namespace _16_ExtractHyperlinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class ExtractHyperlinks
    {
        private static List<string> _result;

        static void Main()
        {
            _result = new List<string>();
            var input = GetInput();

            GetResults(input);
            PrintResults();
        }

        private static void PrintResults()
        {
            foreach (var i in _result)
            {
                Console.WriteLine(i);
            }
        }

        private static void GetResults(string input)
        {
            var pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";
            var rex = new Regex(pattern);
            var match = rex.Match(input);

            while (match.Success)
            {
                if (!(match.Groups[2].Value == "fake"))
                {
                    _result.Add(match.Groups[2].Value);
                }
                match = match.NextMatch();
            }
        }

        private static string GetInput()
        {
            var sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                sb.Append(input);
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
