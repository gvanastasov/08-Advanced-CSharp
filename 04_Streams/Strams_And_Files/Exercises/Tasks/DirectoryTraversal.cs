using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class DirectoryTraversal : TaskBase
    {
        private const string dest = "../../../Resources/07_files.txt";

        public override void Execute()
        {
            while (true)
            {
                var path = Console.ReadLine();

                DirectoryInfo d = new DirectoryInfo(Path.GetFullPath(path));

                if(d.Exists)
                {
                    LogFiles(d);
                    break;
                }
                else
                {
                    Console.WriteLine("Directory does [Not Exist]...");
                }
            }
        }

        private void LogFiles(DirectoryInfo d)
        {
            var groupedFiles = d.GetFiles().GroupBy(
                    f => f.Extension,
                    f => $"--{f.Name}{f.Extension} - {f.Length / 1024}kb",
                    (key, g) => new { Extension = key, Files = g.ToList()}
                ).OrderByDescending(g => g.Files.Count);

            using (var writer = new StreamWriter(dest))
            {
                foreach (var kvp in groupedFiles)
                {
                    writer.WriteLine($"{kvp.Extension}");
                    foreach (var fileInfoString in kvp.Files)
                    {
                        writer.WriteLine(fileInfoString);
                    }
                }
            }
        }
    }
}
