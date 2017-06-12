namespace _01_StidentsResults
{
    using System;
    using System.Linq;
    using System.Text;

    class StudentsResults
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var tokens = input.Split('-');

                var name = tokens[0].TrimEnd();
                var scores = tokens[1].Trim().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                sb.AppendLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                    name, scores[0], scores[1], scores[2], scores.Average()));
            }

            Console.WriteLine(sb);
        }
    }
}
