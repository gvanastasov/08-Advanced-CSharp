namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);

            var n = inputs[0];
            var s = inputs[1];
            var x = inputs[2];

            var queue = new Queue<int>(numbers);
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if(queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if(queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var min = int.MaxValue;
                    while (queue.Count != 0)
                    {
                        var del = queue.Dequeue();
                        if(del < min)
                        {
                            min = del;
                        }
                    }
                    Console.WriteLine(min.ToString());
                }
            }
        }
    }
}
