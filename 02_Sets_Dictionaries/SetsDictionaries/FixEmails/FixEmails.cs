namespace _07_FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    class FixEmails
    {
        static void Main()
        {
            var emails = new Dictionary<string, string>();
            var emailRegex = new Regex("^.*@.*\\.(us|uk)$", RegexOptions.IgnoreCase);

            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if(emailRegex.IsMatch(email) == false)
                {
                    emails.Add(cmd, email);
                }
            }

            foreach (var kvp in emails)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
