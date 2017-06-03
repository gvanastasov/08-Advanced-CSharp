namespace _04_PascalTriangle
{
    using System;

    class PascalTriangle
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());


            var matrix = new decimal[rows][];
            matrix[0] = new decimal[1] { 1 };
            
            Console.WriteLine(string.Join(" ", matrix[0]));

            for (int row = 1; row < matrix.Length; row++)
            {
                matrix[row] = new decimal[row + 1];

                for (int el = 0; el < matrix[row].Length; el++)
                {
                    var prevRow = row - 1;

                    var aboveLeft_y = el - 1;
                    var aboveLeft = (aboveLeft_y < 0) ? 0 : matrix[prevRow][aboveLeft_y];

                    var aboveRight_y = el;
                    var aboveRight = (aboveRight_y > matrix[prevRow].Length - 1) ? 0 : matrix[prevRow][aboveRight_y];

                    matrix[row][el] = aboveLeft + aboveRight;
                }

                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
