namespace _03_FormattingNumbers
{
    using System;
    class FormatingNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            var num1 = int.Parse(numbers[0]);
            var binary = Convert.ToString(num1, 2);

            if(binary.Length > 10)
            {
                binary = binary.Substring(0, 10);
            }
            else
            {
                binary = binary.PadLeft(10, '0');
            }

            var result = string.Format("|{0,-10:X}|{1,10}|{2,10:f2}|{3,-10:f3}|",
                num1,
                binary,
                double.Parse(numbers[1]),
                double.Parse(numbers[2]));
            Console.WriteLine(result);
        }
    }
}
