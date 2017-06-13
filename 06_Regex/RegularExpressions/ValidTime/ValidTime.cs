namespace _07_ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    class ValidTime
    {
        static void Main()
        {
            var pattern = @"^([0][0-9]|[1][012]):([0-5][0-9]):([0-5][0-9])\s[AP]M$";
            var regex = new Regex(pattern);

            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "END")
                {
                    break;
                }

                Console.WriteLine(regex.IsMatch(cmd) ? "valid" : "invalid");
            }
        }
    }
}
