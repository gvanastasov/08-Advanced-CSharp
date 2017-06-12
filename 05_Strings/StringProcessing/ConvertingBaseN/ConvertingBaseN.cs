using System;
using System.Numerics;

namespace _05_ConvertingBaseN
{
    class ConvertingBaseN
    {
        static void Main()
        {
            var input = Console.ReadLine().Trim().Split();
            var baseNNum = int.Parse(input[0]);
            var baseTenNum = input[1].ToCharArray();

            BigInteger result = new BigInteger(0);

            for (int i = 0; i < baseTenNum.Length; i++)
            {
                int currentNum = (int)Char.GetNumericValue(baseTenNum[i]);
                result += currentNum * BigInteger.Pow(baseNNum, baseTenNum.Length - i - 1);
            }

            Console.WriteLine(result);
        }
    }
}
