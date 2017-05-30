namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();

            queue.Enqueue(n);
            for (int i = 1; i <= 50; i++)
            {
                var s = queue.Dequeue();
                queue.Enqueue(s + 1);
                queue.Enqueue(2 * s + 1);
                queue.Enqueue(s + 2);

                Console.Write(s + " ");
            }

            Console.WriteLine();
        }
    }
}
