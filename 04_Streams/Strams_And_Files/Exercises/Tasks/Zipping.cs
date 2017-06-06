using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class Zipping : TaskBase
    {
        private static string filePath = "../../../Resources/05_tex.jpg";
        private static string destFolder = "../../../Resources/06_zip/";

        public override void Execute()
        {
            Console.CursorVisible = true;

            Console.WriteLine("Press [Z] to zip a file, [U] to unzip or [Esc] to return...");

            var keyCommandAccepted = false;
            while (keyCommandAccepted == false)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        {
                            keyCommandAccepted = true;
                            Compress(filePath, $"{destFolder}tex-zipped.gz");
                            Console.WriteLine("Succesfully zipped");
                        }
                        break;
                    case ConsoleKey.U:
                        {
                            keyCommandAccepted = true;
                            Decompress($"{destFolder}tex-zipped.gz", $"{destFolder}tex-unzipped.jpg");
                            Console.WriteLine("Succesfully unzipped");
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

        private void Decompress(string zip, string dest)
        {
            using (var inputStream = new FileStream(zip, FileMode.Open))
            {
                using (var compressionStream = new GZipStream(inputStream, CompressionMode.Decompress, false))
                {
                    using (var outputStream = new FileStream(dest, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressionStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            outputStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private void Compress(string src, string dest)
        {
            using (var inputStream = new FileStream(src, FileMode.Open))
            {
                using (var outputStream = new FileStream(dest, FileMode.Create))
                {
                    using (var compressionStream = new GZipStream(outputStream, CompressionMode.Compress, false))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = inputStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            compressionStream.Write(buffer, 0, readBytes);
                        }
                        Console.WriteLine($"Wohooo you just saved: {inputStream.Length - outputStream.Length} bytes");
                    }
                }
            }
        }
    }
}
