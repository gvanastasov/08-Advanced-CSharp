namespace _08_MultiplyBigNumbers
{
    using System;
    using System.Text;

    class MultiplyBigNumbers
    {
        static void Main()
        {
            var num = Console.ReadLine().Trim().TrimStart(new char[] { '0'});
            var multiplier = int.Parse(Console.ReadLine());

            if(multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var result = new StringBuilder();
            var sideAdd = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                var digit = int.Parse(num[i].ToString());

                var local = digit * multiplier + sideAdd;
                result.Insert(0, (local % 10).ToString());

                sideAdd = local / 10;
            }

            if(sideAdd != 0)
            {
                result.Insert(0, sideAdd);
            }

            Console.WriteLine(result.ToString()); 
        }
    }
}
