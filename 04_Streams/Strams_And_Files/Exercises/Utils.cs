namespace Exercises
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Tasks;

    public static class Utils
    {
        public static string SplitCamelCase(string source)
        {
            return string.Join(" ", Regex.Split(source, @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
        }

        public static void RegenerateIpsum(string path)
        {
            using (var reader = new StreamReader(Constants.lp_default))
            {
                using (var writer = new StreamWriter(path))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public static IEnumerable<Type> GetDerivedTasks()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(TaskBase)));
        }
    }
}
