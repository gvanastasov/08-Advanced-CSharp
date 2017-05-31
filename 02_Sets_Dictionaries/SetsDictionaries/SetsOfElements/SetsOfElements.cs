namespace _02_SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SetsOfElements
    {
        static void Main()
        {
            var lengths = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var nLen = lengths[0];
            var mLen = lengths[1];

            var n = new HashSet<int>();
            for (int i = 0; i < nLen; i++)
            {
                var entry = int.Parse(Console.ReadLine());
                n.Add(entry);
            }

            var m = new HashSet<int>();
            for (int i = 0; i < mLen; i++)
            {
                var entry = int.Parse(Console.ReadLine());
                m.Add(entry);
            }

            n.IntersectWith(m);

            foreach (var item in n)
            {
                Console.Write(item + " ");
            }
        }
    }
}
