using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class SlicingFile : TaskBase
    {
        private const string resourcesFolder = "../../../Resources/";
        private const string destinationFolder = "../../../Resources/05_partions";

        public override void Execute()
        {
            Console.CursorVisible = true;

            Console.WriteLine("Press [S] to slice a file, [A] to assemble or [Esc] to return...");

            var keyCommandAccepted = false;
            while (keyCommandAccepted == false)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.S:
                        {
                            keyCommandAccepted = true;
                            SliceGUI();
                        }
                        break;
                    case ConsoleKey.A:
                        {
                            keyCommandAccepted = true;
                            AssembleGUI();
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            keyCommandAccepted = true;
                            Console.CursorVisible = false;
                            return;
                        }
                }
            }

            Console.CursorVisible = false;
        }

        private void AssembleGUI()
        {
            Console.Clear();
            Console.Write("Number of partions: ");
            var partionsCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Partion suffix [name before slice]: ");
            var pp = Console.ReadLine();

            Console.Write("Type: ");
            var type = Console.ReadLine();

            var partions = new List<string>();
            for (int i = 0; i < partionsCount; i++)
            {
                partions.Add($"{destinationFolder}/{pp}.{type}-part-{i}");
            }
            
            Assemble(partions, $"{destinationFolder}/{pp}-assembled.{type}");
        }

        private void SliceGUI()
        {
            Console.Clear();

            Console.Write("Filename [must be inside Resources/ folder]: ");
            var filename = Console.ReadLine();

            Console.Write("Parts: ");
            var partsCount = int.Parse(Console.ReadLine());

            Slice(filename, destinationFolder, partsCount);
        }

        private void Slice(string sourceFile, string destFolder, int parts)
        {
            using (var source = new FileStream($"{resourcesFolder}/{sourceFile}", FileMode.Open))
            {
                long fileLength = source.Length;
                long partionSize = fileLength / parts;

                for (int i = 0; i < parts; i++)
                {
                    using (var dest = new FileStream($"{destFolder}/{sourceFile}-part-{i}", (i == 0) ? FileMode.OpenOrCreate : FileMode.Append))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0 || dest.Length > partionSize)
                            {
                                break;
                            }

                            dest.Write(buffer, 0, readBytes);
                        }
                    }

                    Console.WriteLine("Succesfully created partion: " + i);
                }
            }
        }

        // Somethings messing up with reassembling :( might be the encoding, no time 
        private void Assemble(List<string> files, string destination)
        {
            using (var dest = new FileStream($"{destination}", FileMode.OpenOrCreate))
            {
                foreach (var file in files)
                {
                    using (var source = new FileStream($"{file}", FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            dest.Write(buffer, 0, readBytes);
                        }

                    }
                }
            }
        }
    }
}
