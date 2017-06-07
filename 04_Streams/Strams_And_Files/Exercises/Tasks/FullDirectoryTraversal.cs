namespace Exercises.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal : TaskBase
    {
        private const string dest = "../../../Resources/08_files.txt";

        public override void Execute()
        {
            while (true)
            {
                var path = Console.ReadLine();

                DirectoryInfo d = new DirectoryInfo(Path.GetFullPath(path));

                if (d.Exists)
                {
                    DirectoryTraversal(d);
                    break;
                }
                else
                {
                    Console.WriteLine("Directory does [Not Exist]...");
                }
            }
        }

        private void DirectoryTraversal(DirectoryInfo root)
        {
            var files = new List<FileInfo>();
            GetFilesRecursively(root, files);

            var groupedFiles = files.GroupBy(
                    f => f.Extension,
                    f => $"--{f.Name}{f.Extension} - {f.Length / 1024}kb",
                    (key, g) => new { Extension = key, Files = g.ToList() }
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

        private void GetFilesRecursively(DirectoryInfo dir, List<FileInfo> files)
        {
            files.AddRange(dir.GetFiles());

            foreach (var subdir in dir.GetDirectories())
            {
                GetFilesRecursively(subdir, files);
            }
        }
    }
}
