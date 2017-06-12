using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ParseTags
{
    class ParseTags
    {
        private static string openTag = "<upcase>";
        private static string closeTag = "</upcase>";

        static void Main()
        {
            var text = Console.ReadLine();

            var openTagIndex = text.IndexOf(openTag);
            while (openTagIndex != -1)
            {
                var closeTagIndex = text.IndexOf(closeTag);

                if(closeTagIndex == -1)
                {
                    break;
                }

                var tagged = text.Substring(openTagIndex, closeTagIndex - openTagIndex + closeTag.Length);
                var upcase = tagged.Replace(openTag, "").Replace(closeTag, "").ToUpper();

                text = text.Replace(tagged, upcase);

                openTagIndex = text.IndexOf(openTag);
            }

            Console.WriteLine(text);
        }
    }
}
