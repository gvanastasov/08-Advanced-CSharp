namespace _06_CountSubstringOccurencces
{
    using System;

    class CountStringOccurences
    {
        static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();

            var count = 0;
            var idx = text.IndexOf(word);
            while (idx != -1)
            {
                count++;
                idx = text.IndexOf(word, idx + 1);
            }
            Console.WriteLine(count);
        }
    }
}
