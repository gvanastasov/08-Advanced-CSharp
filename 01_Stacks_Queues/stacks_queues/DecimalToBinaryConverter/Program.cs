namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            if(num == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var binary = new Stack<int>();
                while (num > 0)
                {
                    binary.Push((num % 2 == 0) ? 0 : 1);
                    num = num / 2;
                }

                while (binary.Count != 0)
                {
                    Console.Write(binary.Pop());
                }
            }
            Console.WriteLine();
        }
    }
}
