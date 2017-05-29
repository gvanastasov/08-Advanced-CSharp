namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var args = new Stack<string>(input.Reverse());

            while (args.Count > 1)
            {
                var a = int.Parse(args.Pop());
                var op = args.Pop();
                var b = int.Parse(args.Pop());

                if(op == "+")
                {
                    args.Push((a + b).ToString());
                }
                else if(op == "-")
                {
                    args.Push((a - b).ToString());
                }
            }

            Console.WriteLine(args.Peek());
        }
    }
}
