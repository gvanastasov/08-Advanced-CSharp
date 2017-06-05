namespace _06_TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TargetPractice
    {
        private static char[,] matrix;

        static void Main()
        {
            var dimensions = Console.ReadLine().Split(' ');
            var keyword = Console.ReadLine();

            var symbols = new Queue<char>(keyword.ToCharArray());

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            matrix = new char[rows, cols];

            bool backward = true;
            for (int x = matrix.GetLength(0) - 1; x >= 0; x--)
            {
                if (backward)
                {
                    for (int y = matrix.GetLength(1) - 1; y >= 0; y--)
                    {
                        matrix[x, y] = symbols.Peek();
                        symbols.Enqueue(symbols.Dequeue());
                    }
                }
                else
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                    {
                        matrix[x, y] = symbols.Peek();
                        symbols.Enqueue(symbols.Dequeue());
                    }
                }
                backward = !backward;
            }

            var shotParams = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var shot_x = shotParams[0];
            var shot_y = shotParams[1];

            var shotRadius = shotParams[2];

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if(Math.Pow(x - shot_x, 2) + Math.Pow(y - shot_y, 2) <= Math.Pow(shotRadius, 2))
                    {
                        matrix[x, y] = ' ';
                    }
                }
            }

            var stack = new Queue<char>();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    var symbol = matrix[row, col];

                    if(symbol != ' ')
                    {
                        stack.Enqueue(symbol);
                    }
                }

                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix[row, col] = (stack.Count > 0) ? stack.Dequeue() : ' ';
                }
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
