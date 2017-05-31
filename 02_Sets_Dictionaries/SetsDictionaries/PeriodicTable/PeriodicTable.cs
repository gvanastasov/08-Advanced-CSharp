namespace _03_PeriodicTable
{
    using System;
    using System.Collections.Generic;

    class PeriodicTable
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var uniques = new SortedSet<string>();
            for (int i = 0; i < count; i++)
            {
                var elements = Console.ReadLine().Split(' ');

                foreach (var el in elements)
                {
                    uniques.Add(el);
                }
            }

            foreach (var el in uniques)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
    }
}
