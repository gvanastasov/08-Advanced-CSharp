namespace _05_RubiksMatrix
{
    using System;
    using System.Collections.Generic;

    class RubiksMatrix
    {
        private static int[,] matrix;
        private static Queue<int> buffer;

        static void Main()
        {
            buffer = new Queue<int>();
            var dimensions = Console.ReadLine().Split(' ');

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            matrix = new int[rows, cols];

            var counter = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++, counter++)
                {
                    matrix[i, j] = counter;
                }
            }

            var cmdCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < cmdCount; i++)
            {
                var cmdString = Console.ReadLine();
                var tokens = cmdString.Split(' ');

                var target = int.Parse(tokens[0]);
                var cmd = tokens[1];
                var moves = int.Parse(tokens[2]);

                switch (cmd)
                {
                    case "up":
                        {
                            RotateColumn(target, moves, true);
                        }
                        break;
                    case "down":
                        {
                            RotateColumn(target, moves, false);
                        }
                        break;
                    case "right":
                        {
                            RotateRow(target, moves, false);
                        }
                        break;
                    case "left":
                        {
                            RotateRow(target, moves, true);
                        }
                        break;
                }

            }
            RearangeMatrix();
        }

        public static void RearangeMatrix()
        {
            var expectedValue = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++, expectedValue++)
                {
                    var currentValue = matrix[i, j];
                    if(expectedValue == currentValue)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        // find coords of expectedValue
                        bool seaching = true;
                        for (int r = 0; r < matrix.GetLength(0) && seaching; r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1) && seaching; c++)
                            {
                                if(matrix[r,c] == expectedValue)
                                {
                                    var bufferSlot = matrix[i, j];
                                    matrix[i, j] = matrix[r, c];
                                    matrix[r, c] = bufferSlot;
                                    Console.WriteLine($"Swap ({i}, {j}) with ({r}, {c})");
                                    seaching = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void RotateColumn(int col, int times, bool upwards)
        {
            int m = (int)(times % matrix.GetLength(1));

            GetColumnData(col, upwards);
            for (int t = 0; t < m; t++)
            {
                buffer.Enqueue(buffer.Dequeue());
            }
            SetColumnData(col, upwards);
        }

        private static void GetColumnData(int col, bool upwards)
        {
            buffer.Clear();

            var rowCount = matrix.GetLength(0);

            if (upwards)
            {
                for (int r = 0; r < rowCount; r++)
                {
                    buffer.Enqueue(matrix[r, col]);
                }
            }
            else
            {
                for (int r = rowCount - 1; r >= 0; r--)
                {
                    buffer.Enqueue(matrix[r, col]);
                }
            }
        }

        private static void SetColumnData(int col, bool upwards)
        {
            var rowCount = matrix.GetLength(0);
            if (upwards)
            {
                for (int r = 0; r < rowCount; r++)
                {
                    matrix[r, col] = buffer.Dequeue();
                }
            }
            else
            {
                for (int r = rowCount - 1; r >= 0; r--)
                {
                    matrix[r, col] = buffer.Dequeue();
                }
            }
        }


        private static void GetRowData(int row, bool forwards)
        {
            buffer.Clear();

            var columnCount = matrix.GetLength(1);

            if (forwards)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    buffer.Enqueue(matrix[row, c]);
                }
            }
            else
            {
                for (int c = columnCount - 1; c >= 0; c--)
                {
                    buffer.Enqueue(matrix[row, c]);
                }
            }
        }

        public static void RotateRow(int row, int times, bool forwards)
        {
            int m = (int)(times % matrix.GetLength(0));

            GetRowData(row, forwards);
            for (int t = 0; t < m; t++)
            {
                buffer.Enqueue(buffer.Dequeue());
            }
            SetRowData(row, forwards);
        }

        private static void SetRowData(int row, bool forwards)
        {
            var columnCount = matrix.GetLength(1);

            if (forwards)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    matrix[row, c] = buffer.Dequeue();
                }
            }
            else
            {
                for (int c = columnCount - 1; c >= 0; c--)
                {
                    matrix[row, c] = buffer.Dequeue();
                }
            }
        }
    }
}
