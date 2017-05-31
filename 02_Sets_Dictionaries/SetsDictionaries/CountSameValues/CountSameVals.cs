namespace _03_CountSameValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSameVals
    {
        static void Main()
        {
            var values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);

            var occurences = new SortedDictionary<double, int>();
            foreach (var v in values)
            {
                if(occurences.ContainsKey(v))
                {
                    occurences[v]++;
                }
                else
                {
                    occurences.Add(v, 1);
                }
            }

            foreach (var kvp in occurences)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
