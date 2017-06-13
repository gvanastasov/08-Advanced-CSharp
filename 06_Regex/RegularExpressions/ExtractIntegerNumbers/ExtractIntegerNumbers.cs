namespace _04_ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    class ExtractIntegerNumbers
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var pattern = "[0-9]+";
            var regex = new Regex(pattern);

            var matches = regex.Matches(text);
            foreach (var m in matches)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
