namespace _02_StringLength
{
    using System;
    class StringLength
    {
        static void Main()
        {
            var inputStr = Console.ReadLine();

            if(inputStr.Length > 20)
            {
                inputStr = inputStr.Substring(0, 20);
            }

            inputStr = inputStr.PadRight(20, '*');

            Console.WriteLine(inputStr);
        }
    }
}
