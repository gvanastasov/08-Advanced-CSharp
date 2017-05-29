namespace BasicStackOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(' ');
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);

            var n = int.Parse(inputs[0]);
            var s = int.Parse(inputs[1]);
            var x = int.Parse(inputs[2]);

            var stack = new Stack<int>(numbers);

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if(stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if(stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min(a => a).ToString());
                }
            }
        }
    }
}
