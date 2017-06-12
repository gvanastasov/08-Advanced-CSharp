namespace _12_CharacterMultiplier
{
    using System;
    class CharacterMultiplier
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(' ');

            var str1 = tokens[0].ToCharArray();
            var str2 = tokens[1].ToCharArray();

            var max = Math.Max(str1.Length, str2.Length);
            var sum = 0;

            for (int i = 0; i < max; i++)
            {
                if(i < str1.Length)
                {
                    if(i < str2.Length)
                    {
                        sum += (str1[i] * str2[i]);
                    }
                    else
                    {
                        sum += str1[i];
                    }
                }
                else
                {
                    sum += str2[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
