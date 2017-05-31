namespace _08_HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class HandsOfcards
    {
        static void Main()
        {
            var players = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                var input = Console.ReadLine().Split(':');

                if(input[0] == "JOKER")
                {
                    break;
                }

                var name = input[0];
                var cards = Regex.Split(input[1].Substring(1, input[1].Length - 1), ", ");

                if(players.ContainsKey(name) == false)
                {
                    players.Add(name, new HashSet<string>());
                }

                players[name].UnionWith(cards);
            }

            foreach (var kvp in players)
            {
                var name = kvp.Key;
                var score = GetScore(kvp.Value);

                Console.WriteLine($"{name}: {score}");
            }
        }

        private static int GetScore(HashSet<string> cards)
        {
            var score = 0;

            foreach (var card in cards)
            {
                var cardPower = 0; 
                switch (card[0])
                {
                    case 'J':
                        cardPower = 11;
                        break;
                    case 'Q':
                        cardPower = 12;
                        break;
                    case 'K':
                        cardPower = 13;
                        break;
                    case 'A':
                        cardPower = 14;
                        break;
                    default:
                        if(card.Length == 2)
                        {
                            cardPower = int.Parse(card[0].ToString());
                        }
                        else
                        {
                            cardPower = int.Parse(card.Substring(0, 2));
                        }
                        break;
                }

                var type = card[card.Length - 1];

                switch (type)
                {
                    case 'S':
                        cardPower *= 4;
                        break;
                    case 'H':
                        cardPower *= 3;
                        break;
                    case 'D':
                        cardPower *= 2;
                        break;
                    case 'C':
                        cardPower *= 1;
                        break;
                }

                score += cardPower;
            }

            return score;
        }
    }
}
