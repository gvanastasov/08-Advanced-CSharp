using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tasks
{
    public class WordCount : TaskBase
    {
        private const string wordsFile = "../../../Resources/03_words.txt";
        private const string textFile = "../../../Resources/03_text.txt";
        private const string resultFile = "../../../Resources/03_result.txt";

        public override void Execute()
        {
            var wordsCountKvp = new Dictionary<string, int>();

            using (var reader = new StreamReader(wordsFile))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    wordsCountKvp.Add(line, 0);
                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader(textFile))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    foreach (var word in wordsCountKvp.Keys.ToArray())
                    {
                        if(line.ToLower().Contains(word))
                        {
                            wordsCountKvp[word]++;
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            using (var writer = new StreamWriter(resultFile))
            {
                foreach (var kvp in wordsCountKvp.OrderByDescending(c => c.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
