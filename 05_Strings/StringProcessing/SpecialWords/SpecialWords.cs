namespace _04_SpecialWords
{
    using System;
    using System.Collections.Generic;

    class SpecialWords
    {
        static void Main()
        {
            var words = Console.ReadLine().Split(new string[] { "(", ")", "[", "]", "<", ">", ",", "-", "!", "?", " " }, StringSplitOptions.None);
            var text = Console.ReadLine();

            var wordCountKvp = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var idx = text.IndexOf(word);
                var count = 0;

                while (idx != -1)
                {
                    count++;
                    idx = text.IndexOf(word, idx + word.Length);
                }

                Console.WriteLine($"{word} - {count}");
            }
        }
    }
}
