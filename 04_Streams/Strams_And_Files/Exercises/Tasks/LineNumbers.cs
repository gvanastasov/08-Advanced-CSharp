using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class LineNumbers : TaskBase
    {
        private const string file = "../../../Resources/lp_02.txt";

        public override void Execute()
        {
            using (var reader = new StreamReader(Constants.lp_default))
            {
                using (var writer = new StreamWriter(file))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 0;

                    while (line != null)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            writer.WriteLine();
                        }
                        else
                        {
                            lineNumber++;
                            writer.WriteLine($"{lineNumber}. {line}");
                        }

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
