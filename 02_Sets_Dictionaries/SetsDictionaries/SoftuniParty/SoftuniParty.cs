namespace _02_SoftuniParty
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var regular = new SortedSet<string>();
            var vips = new SortedSet<string>();
            var vipRegex = new Regex("^[0-9].{7}$");

            while (true)
            {
                var cmd = Console.ReadLine();
                
                if(cmd == "PARTY")
                {
                    break;
                }
                else
                {
                    if(vipRegex.IsMatch(cmd))
                    {
                        vips.Add(cmd);
                    }
                    else
                    {
                        regular.Add(cmd);
                    }
                }
            }

            while (true)
            {
                var cmd = Console.ReadLine();

                if (cmd == "END")
                {
                    break;
                }
                else
                {
                    if (vipRegex.IsMatch(cmd))
                    {
                        vips.Remove(cmd);
                    }
                    else
                    {
                        regular.Remove(cmd);
                    }
                }
            }

            vips.UnionWith(regular);
            Console.WriteLine(vips.Count);
            foreach (var missingPerson in vips)
            {
                Console.WriteLine(missingPerson);
            }
        }
    }
}
