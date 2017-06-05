using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_TheHeiganDance
{
    class TheHeiganDance
    {
        static int playerRow = 7;
        static int playerCol = 7;

        static double playerHP = 18500;
        static double heiganHP = 3000000;
        static string lastSpell = "";

        private static void Main()
        {
            double playerDamage = double.Parse(Console.ReadLine());

            while (true) {
                if (playerHP >= 0) {
                    heiganHP -= playerDamage;
                }
                if (lastSpell == "Cloud") {
                    playerHP -= 3500;
                }
                if (heiganHP <= 0 || playerHP <= 0) {
                    break;
                }

                string[] tokens = Console.ReadLine().Split(' ');
                string currentSpell = tokens[0];

                int targetRow = int.Parse(tokens[1]);
                int targetCol = int.Parse(tokens[2]);

                if (IsInDamageArea(targetRow, targetCol, playerRow, playerCol)) {
                    if (!IsInDamageArea(targetRow, targetCol, playerRow - 1, playerCol) && !IsWall(playerRow - 1)) {
                        playerRow--;
                        lastSpell = "";
                    } else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol + 1) && !IsWall(playerCol + 1)) {
                        playerCol++;
                        lastSpell = "";
                    } else if (!IsInDamageArea(targetRow, targetCol, playerRow + 1, playerCol) && !IsWall(playerRow + 1)) {
                        playerRow++;
                        lastSpell = "";
                    } else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol - 1) && !IsWall(playerCol - 1)) {
                        playerCol--;
                        lastSpell = "";
                    } else {
                        if (currentSpell == ("Cloud")) {
                            playerHP -= 3500;
                            lastSpell = "Cloud";
                        } else if (currentSpell == ("Eruption")) {
                            playerHP -= 6000;
                            lastSpell = "Eruption";
                        }
                    }
                }
            }

            lastSpell = (lastSpell == "Cloud") ? "Plague Cloud" : "Eruption";

            string heiganState = heiganHP <= 0 
                ? "Heigan: Defeated!" 
                : string.Format("Heigan: {0:f2}", heiganHP);

            string playerState = playerHP <= 0 
                ? string.Format("Player: Killed by {0}", lastSpell) 
                : string.Format("Player: {0}", playerHP);

            string playerEndCoordinates = string.Format("Final position: {0}, {1}", playerRow, playerCol);

            Console.WriteLine(heiganState);
            Console.WriteLine(playerState);
            Console.WriteLine(playerEndCoordinates);
    }

    private static bool IsWall(int moveCell) {
        return moveCell < 0 || moveCell >= 15;
    }

    private static bool IsInDamageArea(int targetRow, int targetCol, int moveRow, int moveCol) {
        return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
    }
    }
}
