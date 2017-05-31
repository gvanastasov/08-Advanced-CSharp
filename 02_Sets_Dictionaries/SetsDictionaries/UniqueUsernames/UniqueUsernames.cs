namespace _01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class UniqueUsernames
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                var name = Console.ReadLine();
                usernames.Add(name);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
