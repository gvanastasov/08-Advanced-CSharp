
namespace _01_ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class ParkingLot
    {
        static void Main()
        {
            var parkingLot = new SortedSet<string>();

            while (true)
            {
                var tokens = Regex.Split(Console.ReadLine(), ", ");

                var cmd = tokens[0];
                if(cmd == "END")
                {
                    break;
                }

                var plateNumber = tokens[1];
                switch (cmd)
                {
                    case "IN":
                        parkingLot.Add(plateNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(plateNumber);
                        break;
                }
            }

            if(parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
