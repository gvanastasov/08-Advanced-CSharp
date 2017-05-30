using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParentheses
{
    class Program
    {
        private static char[] openParentheses = new char[3] { '[', '{', '('};
        private static char[] closeParentheses = new char[3] { ']', '}', ')' };

        static void Main()
        {
            var str = Console.ReadLine();

            var stack = new Stack<char>();
            for (var i = 0; i < str.Length; i++)
            {
                var symbol = str[i];
                if (openParentheses.Contains(symbol))
                {
                    stack.Push(symbol);
                }
                else if (closeParentheses.Contains(symbol))
                {
                    if (stack.Count > 0)
                    {
                        var last = stack.Pop();

                        switch (last)
                        {
                            case '[':
                                if(symbol != ']')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;
                            case '{':
                                if (symbol != '}')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;
                            case '(':
                                if (symbol != ')')
                                {
                                    Console.WriteLine("NO");
                                    return;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if(stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
