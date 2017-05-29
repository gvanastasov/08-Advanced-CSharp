namespace Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var stk = new Stack<char>(str.Length);
            foreach (var c in str)
            {
                stk.Push(c);
            }

            while (stk.Count != 0)
            {
                Console.Write(stk.Pop());
            }

            Console.WriteLine();
        }
    }
}
