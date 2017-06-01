namespace _09_UserLogs
{
    using System;
    using System.Collections.Generic;

    class UserLogs
    {
        static void Main()
        {
            var logs = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var cmd = Console.ReadLine();

                if (cmd == "end")
                {
                    break;
                }

                var tokens = cmd.Split(' ');
                var ip = tokens[0].Substring(3);
                var username = tokens[2].Substring(5);

                if(logs.ContainsKey(username))
                {
                    var user = logs[username];
                    if (user.ContainsKey(ip))
                    {
                        user[ip]++;
                    }
                    else
                    {
                        user.Add(ip, 1);
                    }
                }
                else
                {
                    var ips = new Dictionary<string, int>();
                    ips.Add(ip, 1);
                    logs.Add(username, ips);
                }
            }

            foreach (var kvp in logs)
            {
                Console.WriteLine($"{kvp.Key}: ");

                var c = 0;
                foreach (var ip in kvp.Value)
                {
                    var strEnding = (c == kvp.Value.Count-1) ? "." : ", ";
                    Console.Write($"{ip.Key} => {ip.Value}{strEnding}");
                    c++;
                }
                Console.WriteLine();
            }
        }
    }
}
