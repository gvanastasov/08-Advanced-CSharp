namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(names);
            while (queue.Count != 1)
            {
                var toss = 1;
                while (true)
                {
                    var tosser = queue.Dequeue();

                    if(toss == n)
                    {
                        Console.WriteLine($"Removed {tosser}");
                        break;
                    }

                    queue.Enqueue(tosser);
                    toss++;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
