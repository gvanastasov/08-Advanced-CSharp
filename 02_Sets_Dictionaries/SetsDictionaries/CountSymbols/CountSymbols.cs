namespace _04_CountSymbols
{
    using System;
    using System.Collections.Generic;
    class CountSymbols
    {
        static void Main()
        {
            var str = Console.ReadLine();

            var occurances = new SortedDictionary<char, int>();
            foreach (var c in str)
            {
                if(occurances.ContainsKey(c))
                {
                    occurances[c]++;
                }
                else
                {
                    occurances.Add(c, 1);
                }
            }

            foreach (var kvp in occurances)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
