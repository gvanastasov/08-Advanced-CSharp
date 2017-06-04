namespace _01_PalindromesMatrix
{
    using System;

    class PalindromesMatrix
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split(' ');

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            var palindromes = new string[rows,cols];
            for (int x = 'a', i = 0; i < rows; x++, i++)
            {
                for (int y = x, j = 0; j < cols; y++, j++)
                {
                    var f = (char)x;
                    var m = (char)y;
                    var p = string.Format($"{f}{m}{f}");
                    palindromes[i, j] = p;
                    Console.Write(p + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
