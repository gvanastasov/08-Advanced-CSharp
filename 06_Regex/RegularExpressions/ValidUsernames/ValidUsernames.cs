namespace _06_ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;
    class ValidUsernames
    {
        static void Main()
        {
            var pattern = "^[0-9a-zA-Z-_]{3,16}$";
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
