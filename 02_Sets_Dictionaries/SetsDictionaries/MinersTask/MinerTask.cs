namespace _06_MinersTask
{
    using System;
    using System.Collections.Generic;

    class MinerTask
    {
        static void Main()
        {
            var resources = new Dictionary<string, int>();
            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "stop")
                {
                    break;
                }

                if(resources.ContainsKey(cmd) == false)
                {
                    resources.Add(cmd, 0);
                }

                var quantity = int.Parse(Console.ReadLine());
                resources[cmd] += quantity;
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
