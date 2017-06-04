namespace _03_SquareMatrix
{
    using System;

    class SquareMatrix
    {
        static void Main()
        {
            var size = Console.ReadLine().Split(' ');

            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            var matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var chars = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = chars[j][0];
                }
            }

            var sqMatrixCount = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    var isSqMatrix = true;
                    var topLeftChar = matrix[i, j];

                    for (int coord_x = i; coord_x < i + 2; coord_x++)
                    {
                        for (int coord_y = j; coord_y < j + 2; coord_y++)
                        {
                            if(matrix[coord_x, coord_y] != topLeftChar)
                            {
                                isSqMatrix = false;
                                break;
                            }
                        }

                        if(isSqMatrix == false)
                        {
                            break;
                        }
                    }

                    sqMatrixCount += (isSqMatrix) ? 1 : 0;
                }
            }

            Console.WriteLine(sqMatrixCount);
        }
    }
}
