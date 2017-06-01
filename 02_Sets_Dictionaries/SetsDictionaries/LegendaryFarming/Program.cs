using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class Program
    {
        static void Main()
        {
            var farm = new Dictionary<string, int>()
            {
                {"fragments",0 },
                {"shards",0 },
                {"motes",0 }
            };
            var junks = new SortedDictionary<string, int>();

            for (int i = 0; i < 10; i++)
            {
                var cmd = Console.ReadLine();

                if(string.IsNullOrEmpty(cmd))
                {
                    break;
                }

                var canGetLegendary = false;
                var tokens = cmd.Split(' ');
                for (int j = 0; j < tokens.Length; j+=2)
                {
                    var qnt = int.Parse(tokens[j]);
                    var type = tokens[j + 1].ToLower();


                    switch (type)
                    {
                        case "fragments":
                        case "shards":
                        case "motes":
                            {
                                AddFarm(qnt, type, farm);
                                canGetLegendary = HasMaterials(type, farm);

                                if(canGetLegendary)
                                {
                                    farm[type] -= 250;
                                    switch (type)
                                    {
                                        case "fragments":
                                            Console.WriteLine("Valanyr obtained!");
                                            break;
                                        case "shards":
                                            Console.WriteLine("Shadowmourne obtained!");
                                            break;
                                        case "motes":
                                            Console.WriteLine("Dragonwrath obtained!");
                                            break;
                                    }
                                }
                            }
                            break;
                        default:
                            {
                                AddJunk(qnt, type, junks);
                            }
                            break;
                    }

                    if (canGetLegendary)
                    {
                        break;
                    }
                }

                if(canGetLegendary)
                {
                    break;
                }
            }

            foreach (var special in farm.OrderBy(x => x.Key)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{special.Key}: {special.Value}");
            }

            foreach (var junk in junks)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }

        private static bool HasMaterials(string type, Dictionary<string, int> bag)
        {
            return bag[type] >= 250;
        }

        private static void AddFarm(int qnt, string type, Dictionary<string, int> bag)
        {
            if(bag.ContainsKey(type))
            {
                bag[type] += qnt;
            }
            else
            {
                bag.Add(type, qnt);
            }
        }

        private static void AddJunk(int qnt, string type, SortedDictionary<string, int> bag)
        {
            if (bag.ContainsKey(type))
            {
                bag[type] += qnt;
            }
            else
            {
                bag.Add(type, qnt);
            }
        }
    }
}
