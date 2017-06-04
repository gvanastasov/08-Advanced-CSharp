namespace _02_DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            var ld = 0;
            var rd = 0;

            for (int i = 0; i < n; i++)
            {
                var entries = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    var entry = entries[j];
                    matrix[i, j] = entry;

                    if(i == j)
                    {
                        ld += entry;
                    }

                    if(n - 1 - j == i)
                    {
                        rd += entry;
                    }
                }
            }

            var diff = Math.Abs(ld - rd);
            Console.WriteLine(diff);
        }
    }
}
