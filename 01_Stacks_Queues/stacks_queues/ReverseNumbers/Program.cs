namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ');
            var stk = new Stack<string>(numbers);

            while (stk.Count != 1)
            {
                Console.Write(stk.Pop() + ' ');
            }
            Console.Write(stk.Pop());

            Console.WriteLine();
        }
    }
}
