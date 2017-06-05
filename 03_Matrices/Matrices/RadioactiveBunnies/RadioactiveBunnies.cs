namespace _08_RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;

    class RadioactiveBunnies
    {
        private static char[,] map;
        private static int player_col, player_row;

        static void Main()
        {
            var mapDimensions = Console.ReadLine().Split(' ');

            var height = int.Parse(mapDimensions[0]);
            var width = int.Parse(mapDimensions[1]);
            map = new char[height, width];

            for (int r = 0; r < height; r++)
            {
                var tiles = Console.ReadLine().ToCharArray();
                for (int c = 0; c < width; c++)
                {
                    var tile = tiles[c];
                    map[r, c] = tile;

                    if(tile == 'P')
                    {
                        player_col = c;
                        player_row = r;
                    }
                }
            }

            var commands = Console.ReadLine().ToCharArray();

            bool escaped = false;
            for (int i = 0; i < commands.Length && escaped == false && playerHit == false; i++)
            {
                var next_r = player_row;
                var next_c = player_col;

                switch (commands[i])
                {
                    case 'R':
                        {
                            next_c++;
                        }
                        break;
                    case 'L':
                        {
                            next_c--;
                        }
                        break;
                    case 'U':
                        {
                            next_r--;
                        }
                        break;
                    case 'D':
                        {
                            next_r++;
                        }
                        break;
                }

                map[player_row, player_col] = '.';

                if (PlayerOutsideMap(next_r, next_c))
                {
                    escaped = true;
                }
                else if (map[player_row, player_col] == 'B')
                {
                    player_row = next_r;
                    player_col = next_c;
                    playerHit = true;
                }
                else
                {
                    player_row = next_r;
                    player_col = next_c;
                    map[player_row, player_col] = 'P';
                }

                BunnySpread();
            }

            if(escaped)
            {
                PrintMap();
                Console.WriteLine($"won: {player_row} {player_col}");
            }
            else if(playerHit)
            {
                PrintMap();
                Console.WriteLine($"dead: {player_row} {player_col}");
            }

        }

        private static void BunnySpread()
        {
            var stack = new Stack<int>();
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if(map[r,c] == 'B')
                    {
                        stack.Push(r);
                        stack.Push(c);

                    }
                }
            }

            while(stack.Count > 0)
            {
                var c = stack.Pop();
                var r = stack.Pop();

                Spread(r, c - 1);
                Spread(r, c + 1);
                Spread(r - 1, c);
                Spread(r + 1, c);
            }
        }

        private static bool playerHit = false;

        private static void Spread(int coord_r, int coord_c)
        {
            if(coord_r >= 0 && coord_r < map.GetLength(0) && coord_c >= 0 && coord_c < map.GetLength(1))
            {
                if(map[coord_r, coord_c] == 'P')
                {
                    playerHit = true;
                }
                map[coord_r, coord_c] = 'B';
            }
        }

        private static void PrintMap()
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    Console.Write(map[r,c]);
                }
                Console.WriteLine();
            }
        }

        private static bool PlayerOutsideMap(int r, int c)
        {
            return r > map.GetLength(0) - 1 ||
                r < 0 ||
                c > map.GetLength(1) - 1 ||
                c < 0;
        }
    }
}
