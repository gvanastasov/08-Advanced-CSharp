namespace _09_Crossfire
{
    using System;
    using System.Collections.Generic;

    class Crossfire
    {
        private static int[,] matrix;

        static void Main()
        {
            var dim = Console.ReadLine().Split(' ');
            var rows = int.Parse(dim[0]);
            var cols = int.Parse(dim[1]);

            matrix = new int[rows, cols];

            for (int r = 0, counter = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++, counter++)
                {
                    matrix[r, c] = counter;
                }
            }

            while (true)
            {
                var cmd = Console.ReadLine();

                if (cmd == "Nuke it from orbit")
                {
                    break;
                }

                var tokens = cmd.Split(' ');
                var blast_r = int.Parse(tokens[0]);
                var blast_c = int.Parse(tokens[1]);
                var rad = int.Parse(tokens[2]);

                DestroyCell(blast_r, blast_c);

                // destroy down
                for (int i = blast_r + 1; i <= blast_r + rad; i++)
                {
                    DestroyCell(i, blast_c);
                }

                // destroy up
                for (int i = blast_r - 1; i >= blast_r - rad; i--)
                {
                    DestroyCell(i, blast_c);
                }

                // destroy right
                for(int i = blast_c + 1; i <= blast_c + rad; i++)
                {
                    DestroyCell(blast_r, i);
                }

                // destroy left
                for (int i = blast_c - 1; i >= blast_c - rad; i--)
                {
                    DestroyCell(blast_r, i);
                }

                ShiftDestroyedCells();
            }
            PrintMatrix();
        }

        private static void ShiftDestroyedCells()
        {
            var queue = new Queue<int>();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    var cell = matrix[r, c];
                    if(cell != 0)
                    {
                        queue.Enqueue(cell);
                    }
                }

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = (queue.Count > 0) ? queue.Dequeue() : 0;
                }
            }
        }

        private static void DestroyCell(int r, int c)
        {
            if(r < 0 || 
                c < 0 || 
                r > matrix.GetLength(0) - 1 || 
                c > matrix.GetLength(1) - 1)
            {
                return;
            }

            matrix[r, c] = 0;
        }

        private static void PrintMatrix()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                bool flag = false;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    var cell = matrix[r, c];

                    if(cell != 0)
                    {
                        flag = true;
                        Console.Write(cell + " ");
                    }
                }

                if(flag)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
