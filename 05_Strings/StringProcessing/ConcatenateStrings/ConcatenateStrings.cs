namespace _05_ConcatenateStrings
{
    using System;
    using System.Text;

    class ConcatenateStrings
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                sb.Append($"{input} ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
