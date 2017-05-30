namespace TruckTour
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var pumpsCount = int.Parse(Console.ReadLine());

            var fuelDifferences = new Queue<long>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');

                var petrol = long.Parse(tokens[0]);
                var distance = long.Parse(tokens[1]);

                fuelDifferences.Enqueue(petrol - distance);
            }

            // loop through all stations, starting from the first
            for (int idx = 0; idx < pumpsCount; idx++)
            {
                // try to do a full circle
                long tanker = 0;
                bool passed = true;
                for (int i = 0; i < pumpsCount; i++)
                {
                    if(tanker < 0)
                    {
                        passed = false;
                    }
                    tanker += fuelDifferences.Peek();
                    fuelDifferences.Enqueue(fuelDifferences.Dequeue());
                }

                if(passed)
                {
                    Console.WriteLine(idx);
                    break;
                }

                fuelDifferences.Enqueue(fuelDifferences.Dequeue());
            }
        }
    }
}
