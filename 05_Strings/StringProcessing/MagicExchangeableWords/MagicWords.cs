namespace _13_MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;

    class MagicWords
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(new string[] { " ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

            var str1 = tokens[0].Trim().ToCharArray();
            var str2 = tokens[1].Trim().ToCharArray();

            var max = Math.Max(str1.Length, str2.Length);

            var mapKvp = new Dictionary<char, char>();
            var exchangable = false;

            for (int i = 0; i < max; i++)
            {
                if (i < str1.Length)
                {
                    if (i < str2.Length)
                    {
                        exchangable = TryMapping(mapKvp, str1[i], str2[i]);
                    }
                    else
                    {
                        exchangable = mapKvp.ContainsKey(str1[i]);

                        //exchangable = TryLookup(mapKvp, str1[i]);
                    }
                }
                else
                {
                    exchangable = mapKvp.ContainsValue(str2[i]);

                    //exchangable = TryLookup(mapKvp, str2[i]);
                }
            }

            Console.WriteLine(exchangable.ToString().ToLower());
        }

        private static bool TryLookup(Dictionary<char, char> mapKvp, char c)
        {
            if(mapKvp.ContainsKey(c) == false)
            {
                return false;
            }
            return true;
        }

        private static bool TryMapping(Dictionary<char, char> mapKvp, char c1, char c2)
        {
            if(mapKvp.ContainsKey(c1) == false)
            {
                mapKvp.Add(c1, c2);
                return true;
            }
            else
            {
                if(mapKvp[c1] == c2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
