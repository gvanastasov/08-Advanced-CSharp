namespace _08_ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    class ExtractQuotations
    {
        static void Main()
        {
            var line = Console.ReadLine();

            var pattern = "(\"|')(.*?)(\\1)";
            var regex = new Regex(pattern);

            foreach (Match m in regex.Matches(line))
            {
                Console.WriteLine(m.Groups[2].ToString());
            }
        }
    }
}
