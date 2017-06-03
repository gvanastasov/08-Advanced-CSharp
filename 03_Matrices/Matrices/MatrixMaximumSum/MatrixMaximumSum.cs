namespace _02_MatrixMaximumSum
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class MatrixMaximumSum
    {
        static void Main()
        {
            var size = Regex.Split(Console.ReadLine(), ", ");

            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            var matrix = ReadMatrix(rows, cols);

            var max = 0;
            var max_coords_x = 0;
            var max_coords_y = 0;

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    var submatrixSum = 0;

                    for (int coord_x = i; coord_x < i+2; coord_x++)
                    {
                        for (int coord_y = j; coord_y < j+2; coord_y++)
                        {
                            submatrixSum += matrix[coord_x, coord_y];
                        }
                    }

                    if(submatrixSum > max)
                    {
                        max = submatrixSum;
                        max_coords_x = i;
                        max_coords_y = j;
                    }
                }
            }

            for (int x = max_coords_x; x < max_coords_x + 2; x++)
            {
                for (int y = max_coords_y; y < max_coords_y + 2; y++)
                {
                    Console.Write($"{matrix[x, y]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var rowData = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            return matrix;
        }
    }
}
