namespace _04_AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var studentsCount = int.Parse(Console.ReadLine());

            var students = new SortedDictionary<string, double[]>();

            for (int i = 0; i < studentsCount; i++)
            {
                var name = Console.ReadLine();
                var scores = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                students.Add(name, scores);
            }

            foreach (var kvp in students)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }
    }
}
