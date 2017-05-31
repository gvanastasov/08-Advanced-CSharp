namespace _05_Phonebook
{
    using System;
    using System.Collections.Generic;

    class Phonebook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "search")
                {
                    break;
                }

                var tokens = cmd.Split('-');
                var name = tokens[0];
                var phone = tokens[1];

                if(phonebook.ContainsKey(name))
                {
                    phonebook[name] = phone;
                }
                else
                {
                    phonebook.Add(name, phone);
                }
            }

            var log = new List<string>();
            while (true)
            {
                var search = Console.ReadLine();

                if(search == "stop")
                {
                    break;
                }

                if(phonebook.ContainsKey(search))
                {
                    log.Add($"{search} -> {phonebook[search]}");
                }
                else
                {
                    log.Add($"Contact {search} does not exist.");
                }
            }

            foreach (var entry in log)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
