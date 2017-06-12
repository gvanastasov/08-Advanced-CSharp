namespace _10_UnicodeCharacters
{
    using System;
    using System.Text;

    class UnicodeCharacters
    {
        static void Main()
        {
            var symbols = Console.ReadLine().ToCharArray();

            var sb = new StringBuilder();
            for (int i = 0; i < symbols.Length; i++)
            {
                sb.Append(GetEscapeSequence(symbols[i]));
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("x4");
        }
    }
}
