using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class CopyBinaryFile : TaskBase
    {
        private const string imgPath = "../../../Resources/04_arrows.png";
        private const string copyPath = "../../../Resources/04_arrows_copy.png";

        public override void Execute()
        {
            using (var source = new FileStream(imgPath, FileMode.Open))
            {
                using (var dest = new FileStream(copyPath, FileMode.OpenOrCreate))
                {
                    double fileLength = source.Length;
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if(readBytes == 0)
                        {
                            break;
                        }

                        dest.Write(buffer, 0, readBytes);
                        Console.WriteLine("{0:P}", Math.Min(source.Position / fileLength, 1));
                    }
                }
            }
        }
    }
}
