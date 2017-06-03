
namespace _01_SumMatrixElements
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SumMatrixElements
    {
        static void Main()
        {
            var size = Regex.Split(Console.ReadLine(), ", ");

            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);
            var sum = 0;

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var rowData = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowData[j];
                    sum += rowData[j];
                }
            }

            Console.WriteLine($"{rows}\n{cols}\n{sum}");
        }
    }
}
