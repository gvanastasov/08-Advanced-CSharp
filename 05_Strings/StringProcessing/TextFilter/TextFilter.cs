namespace _09_TextFilter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class TextFilter
    {
        static void Main()
        {
            var words = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();
            var filteredText = new StringBuilder(text.Length);

            foreach (var word in words)
            {
                var idx = text.IndexOf(word);
                var indeces = new Queue<int>();
                while (idx != -1)
                {
                    indeces.Enqueue(idx);
                    idx = text.IndexOf(word, idx + word.Length);
                }

                for (int i = 0; i < text.Length; i++)
                {
                    if(indeces.Count > 0 && i >= indeces.Peek())
                    {
                        filteredText.Append('*');
                        if(i == indeces.Peek() + word.Length - 1)
                        {
                            indeces.Dequeue();
                        }
                    }
                    else
                    {
                        filteredText.Append(text[i]);
                    }
                }

                text = filteredText.ToString();
                filteredText.Clear();
            }
            Console.WriteLine(text);
        }
    }
}
