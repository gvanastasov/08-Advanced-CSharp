namespace _05_ExtractTags
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class ExtractTags
    {
        static void Main()
        {
            var html = new StringBuilder();

            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "END")
                {
                    break;
                }
                else
                {
                    html.AppendLine(cmd);
                }
            }

            var pattern = "<.*?>";
            var regex = new Regex(pattern);

            var matches = regex.Matches(html.ToString());
            foreach (var m in matches)
            {
                Console.WriteLine(m.ToString());
            }

        }
    }
}
