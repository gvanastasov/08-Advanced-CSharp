namespace _04_MatrixSum
{
    using System;
    using System.Linq;

    class MaximalSum
    {
        static void Main()
        {
            var size = Console.ReadLine().Split(' ');

            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            if(rows < 3 || cols < 3)
            {
                Console.WriteLine("0");
                return;
            }

            var maxSum = 0;
            var maxTopLeft_x = 0;
            var maxTopLeft_y = 0;

            for (int i = 0; i <= rows - 3; i++)
            {
                for (int j = 0; j <= cols - 3; j++)
                {
                    var localSum = 0;

                    for (int coord_x = i; coord_x < i + 3; coord_x++)
                    {
                        for (int coord_y = j; coord_y < j + 3; coord_y++)
                        {
                            localSum += matrix[coord_x, coord_y];
                        }

                    }

                    if (localSum > maxSum)
                    {
                        maxSum = localSum;
                        maxTopLeft_x = i;
                        maxTopLeft_y = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxTopLeft_x; i < maxTopLeft_x + 3; i++)
            {
                for (int j = maxTopLeft_y; j < maxTopLeft_y + 3; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
