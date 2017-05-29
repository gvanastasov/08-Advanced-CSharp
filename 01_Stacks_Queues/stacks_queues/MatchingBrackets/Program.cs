namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine();

            var stack = new Stack<int>();
            for(var i = 0; i < str.Length; i++)
            {
                var symbol = str[i];
                if(symbol == '(')
                {
                    stack.Push(i);
                } 
                else if(symbol == ')')
                {
                    var startIdx = stack.Pop();
                    var len = i - startIdx + 1;

                    var sub = str.Substring(startIdx, len);
                    Console.WriteLine(sub);
                }
            }
        }
    }
}
