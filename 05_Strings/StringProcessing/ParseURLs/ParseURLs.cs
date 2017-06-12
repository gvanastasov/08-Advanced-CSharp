namespace _02_ParseURLs
{
    using System;

    class ParseURLs
    {
        static void Main()
        {
            var url = Console.ReadLine();

            var tokens = url.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if(tokens.Length == 2 && 
                tokens[1].Contains("://") == false &&
                tokens[1].Contains("/"))
            {
                var protocol = tokens[0];

                var serverEnd = tokens[1].IndexOf('/');
                var server = tokens[1].Substring(0, serverEnd);
                var resources = tokens[1].Substring(serverEnd + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
