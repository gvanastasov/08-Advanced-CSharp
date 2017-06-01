namespace _10_PopularContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PopularContent
    {
        static void Main()
        {
            var countries = new Dictionary<string, Dictionary<string, decimal>>();
            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "report")
                {
                    break;
                }

                var tokens = cmd.Split('|');

                var city = tokens[0];
                var country = tokens[1];
                var population = decimal.Parse(tokens[2]);

                if(countries.ContainsKey(country))
                {
                    countries[country].Add(city, population);
                }
                else
                {
                    var cities = new Dictionary<string, decimal>();
                    cities.Add(city, population);

                    countries.Add(country, cities);
                }
            }

            foreach (var country in countries.OrderByDescending(c => c.Value.Values.Sum()))
            {
                var output = "";
                decimal totalPopulation = 0;

                foreach (var city in country.Value.OrderByDescending(c => c.Value))
                {
                    output += $"\n=>{city.Key}: {city.Value}";
                    totalPopulation += city.Value;
                }

                output = output.Insert(0, $"{country.Key} (total population: {totalPopulation})");
                Console.WriteLine(output);
            }
        }
    }
}
