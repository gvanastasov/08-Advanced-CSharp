namespace _11_Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Palindromes
    {
        static void Main()
        {
            var text = Console.ReadLine().Split(new string[] { " ", ",", "?", "!", ".", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            var palindromes = new SortedSet<string>();
            foreach (var word in text)
            {
                if(IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", palindromes));
        }

        private static bool IsPalindrome(string word)
        {
            int rightIndex = word.Length - 1;
            int leftIndex = 0;
            while (rightIndex >= leftIndex)
            {
                if (word[rightIndex] != word[leftIndex])
                {
                    return false;
                }
                rightIndex--;
                leftIndex++;
            }
            return true;
        }
    }
}
