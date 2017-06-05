namespace _07_LegoBlocks
{
    using System;
    using System.Linq;

    class LegoBlocks
    {
        private static int firstMaxLen = 0;
        private static int secondMaxLen = 0;

        static void Main()
        {
            var rowCount = int.Parse(Console.ReadLine());

            var blockOne = ReadConsoleJaggedArray(rowCount, ref firstMaxLen);
            var blockTwo = ReadConsoleJaggedArray(rowCount, ref secondMaxLen);

            FlipJaggedArray(blockTwo);

            JoinArrays(blockOne, blockTwo);

            if(BlocksFit(blockOne))
            {
                for (int r = 0; r < blockOne.Length; r++)
                {
                    Console.WriteLine($"[{string.Join(", ", blockOne[r])}]");
                }
            }
            else
            {
                var cellCount = 0;
                for (int r = 0; r < blockOne.Length; r++)
                {
                    cellCount += blockOne[r].Length;
                }
                Console.WriteLine($"The total number of cells is: {cellCount}");
            }
        }

        private static void JoinArrays(char[][] first, char[][] second)
        {
            for (int r = 0; r < first.Length; r++)
            {
                Array.Resize(ref first[r], first[r].Length + second[r].Length);

                for (int el = 0; el < second[r].Length; el++)
                {
                    first[r][first[r].Length - second[r].Length + el] = second[r][el];
                }
            }
        }

        private static bool BlocksFit(char[][] blockOne)
        {
            var commonLen = blockOne[0].Length;
            for (int r = 1; r < blockOne.Length; r++)
            {
                if(blockOne[r].Length != commonLen)
                {
                    return false;
                }
            }
            return true;
        }

        private static char[][] ReadConsoleJaggedArray(int rowCount, ref int max)
        {
            var arr = new char[rowCount][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(e => e[0]).ToArray();

                if(arr[i].Length > max)
                {
                    max = arr[i].Length;
                }
            }
            return arr;
        }

        private static void FlipJaggedArray(char[][] arr)
        {
            for (int r = 0; r < arr.Length; r++)
            {
                arr[r] = arr[r].Reverse().ToArray();
            }
        }
    }
}
