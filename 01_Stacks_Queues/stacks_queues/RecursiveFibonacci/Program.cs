namespace RecursiveFibonacci
{
    using System;
    class Program
    {
        private static long[] memo;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            memo = new long[n];

            Console.WriteLine(recursiveFibonacci(n-1));
        }

        private static long recursiveFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = recursiveFibonacci(n - 1) + recursiveFibonacci(n - 2);
            return memo[n];
        }
    }
}
