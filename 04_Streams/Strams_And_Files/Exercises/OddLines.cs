using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class OddLines : TaskBase
    {
        private const string file = "../../../Resources/index.html";

        public override void Execute()
        {
            using (StreamReader reader = new StreamReader(file))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if(lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line[{lineNumber}]: {line}");
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
