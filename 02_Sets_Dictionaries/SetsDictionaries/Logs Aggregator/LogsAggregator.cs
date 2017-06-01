using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Logs_Aggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            var logsCount = int.Parse(Console.ReadLine());

            var users = new SortedDictionary<string, SortedDictionary<string, decimal>>();
            for (int i = 0; i < logsCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');

                var ip = tokens[0];
                var name = tokens[1];
                var dur = int.Parse(tokens[2]);
                
                if(users.ContainsKey(name))
                {
                    var logs = users[name];
                    if(logs.ContainsKey(ip))
                    {
                        logs[ip] += dur;
                    }
                    else
                    {
                        logs.Add(ip, dur);
                    }
                }
                else
                {
                    var logs = new SortedDictionary<string, decimal>();
                    logs.Add(ip, dur);

                    users.Add(name, logs);
                }
            }

            foreach (var user in users)
            {
                var output = "[";
                decimal totalDur = 0;
                var c = 0;

                var distinct = user.Value.Distinct();

                foreach (var log in distinct)
                {
                    var ending = (c == distinct.Count() - 1) ? "" : ", ";

                    output += $"{log.Key}{ending}";
                    totalDur += log.Value;
                    c++;
                }
                output += "]";

                output = output.Insert(0, $"{user.Key}: {totalDur} ");
                Console.WriteLine(output);
            }
        }
    }
}
