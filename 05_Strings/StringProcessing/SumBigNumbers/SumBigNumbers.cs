namespace _07_SumBigNumbers
{
    using System;
    using System.Text;

    class SumBigNumbers
    {
        static void Main()
        {
            var num1 = Console.ReadLine().TrimStart(new char[] { '0' });
            var num2 = Console.ReadLine().TrimStart(new char[] { '0' });

            var max = Math.Max(num1.Length, num2.Length);

            if(num1.Length != num2.Length)
            {
                num1 = num1.PadLeft(max, '0');
                num2 = num2.PadLeft(max, '0');
            }

            var result = new StringBuilder();
            var add = false;
            for (int i = max - 1; i >= 0; i--)
            {
                var n1char = num1[i];
                var n2char = num2[i];

                var n1 = int.Parse(num1[i].ToString());
                var n2 = int.Parse(num2[i].ToString());

                var adding = n1 + n2 + (add ? 1 : 0);
                add = (adding >= 10);

                result.Insert(0, (adding % 10).ToString());
            }

            if(add)
            {
                result.Insert(0, 1.ToString());
            }

            Console.WriteLine(result.ToString());
        }
    }
}
