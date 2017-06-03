namespace _03_GroupNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class GroupNumbers
    {
        static void Main()
        {
            var numbers = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

            var sizes = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                var reminder = Math.Abs(numbers[i] % 3);
                sizes[reminder]++;
            }

            var divisionMatrix = new int[3][];
            for (int i = 0; i < divisionMatrix.Length; i++)
            {
                divisionMatrix[i] = new int[sizes[i]];
            }

            var offsets = new int[3];
            foreach (var n in numbers)
            {
                var reminder = Math.Abs(n % 3);
                var index = offsets[reminder];
                divisionMatrix[reminder][index] = n;
                offsets[reminder]++;
            }

            for (int i = 0; i < divisionMatrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", divisionMatrix[i]));
            }
        }
    }
}
