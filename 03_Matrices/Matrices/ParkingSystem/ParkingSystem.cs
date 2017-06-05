using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ParkingSystem
{
    class ParkingSystem
    {
        static void Main()
        {
            var dim = Console.ReadLine().Split(' ');

            var rows = int.Parse(dim[0]);
            var cols = int.Parse(dim[1]);

            // rows -> taken places
            var parkingLot = new List<HashSet<int>>();

            for (int i = 0; i < rows; i++)
            {
                parkingLot.Add(new HashSet<int>());
            }

            var carMoves = new Queue<string>();

            while (true)
            {
                var cmd = Console.ReadLine();

                if(cmd == "stop")
                {
                    break;
                }

                var tokens = cmd.Split(' ').Select(int.Parse).ToArray();

                var entryRow = tokens[0];
                var target_r = tokens[1];
                var target_c = tokens[2];

                var moves = 1;

                var car_r = entryRow;
                var car_c = 0;

                while (car_r != target_r)
                {
                    var moveDir = Math.Sign(target_r - entryRow);
                    //Console.WriteLine($"Movinging in rows: {moveDir}");
                    car_r += 1 * moveDir;
                    moves++;
                }


                if(parkingLot[target_r].Contains(target_c) == false)
                {
                    //Console.WriteLine("Spot was free");
                    while (car_c != target_c)
                    {
                        //Console.WriteLine($"Movinging in cols");

                        car_c++;
                        moves++;
                    }

                    parkingLot[target_r].Add(car_c);
                    //Console.WriteLine($"Moves: {moves}");

                    carMoves.Enqueue(moves.ToString());
                }
                else
                {
                    var rowSpots = new Queue<bool>();

                    var checkLeft = true;
                    var leftIdx = target_c - 1;
                    var rightIdx = target_c + 1;

                    int? spotIdx = null;

                    while (leftIdx >= 1 || rightIdx <= cols)
                    {
                        if(checkLeft)
                        {
                            var isFree = leftIdx >= 1 && parkingLot[target_r].Contains(leftIdx) == false;
                            if(isFree)
                            {
                                //Console.WriteLine($"found free to the left: {leftIdx}");
                                spotIdx = leftIdx;
                                break;
                            }
                            leftIdx--;
                        }
                        else
                        {
                            var isFree = rightIdx < cols
                                && parkingLot[target_r].Contains(rightIdx) == false;
                            if(isFree)
                            {
                                //Console.WriteLine($"found free to the right: {rightIdx}");
                                spotIdx = rightIdx;
                                break;
                            }
                            rightIdx++;
                        }

                        checkLeft = !checkLeft;
                    }

                    if (spotIdx.HasValue)
                    {
                        var moveDir = Math.Sign(spotIdx.Value - car_c);
                        while (car_c != spotIdx)
                        {
                            //Console.WriteLine($"Movinging in cols");

                            car_c += 1 * moveDir;
                            moves++;
                        }

                        parkingLot[car_r].Add(spotIdx.Value);

                        carMoves.Enqueue(moves.ToString());

                        //Console.WriteLine($"Car parked at: {car_r}, {spotIdx.Value}");
                        //Console.WriteLine($"Moves: {moves}");
                    }
                    else
                    {
                        carMoves.Enqueue($"Row {car_r} full");
                    }
                }

                //foreach (var r in parkingLot)
                //{
                //    foreach (var l in r)
                //    {
                //        Console.Write(l);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine();
            }

            while(carMoves.Count > 0)
            {
                Console.WriteLine(carMoves.Dequeue());
            }
        }
    }
}
