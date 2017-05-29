namespace MaximumElement
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var cmdCount = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            var maxes = new Stack<int>();
            maxes.Push(int.MinValue);

            for (int i = 0; i < cmdCount; i++)
            {
                var cmdTokens = Console.ReadLine().Split(' ');
                var cmd = int.Parse(cmdTokens[0]);

                switch (cmd)
                {
                    case 1:
                        {
                            var val = int.Parse(cmdTokens[1]);
                            stack.Push(val);

                            if(val > maxes.Peek())
                            {
                                maxes.Push(val);
                            }
                        }
                        break;
                    case 2:
                        {
                            var del = stack.Pop();

                            if(del == maxes.Peek())
                            {
                                maxes.Pop();
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine(maxes.Peek());
                        }
                        break;
                }
            }
        }
    }
}
