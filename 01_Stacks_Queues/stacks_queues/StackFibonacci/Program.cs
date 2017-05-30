namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);
            for (int i = 0; i < n-1; i++)
            {
                var prev = stack.Pop();
                var next = stack.Peek() + prev;

                stack.Push(prev);
                stack.Push(next);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
