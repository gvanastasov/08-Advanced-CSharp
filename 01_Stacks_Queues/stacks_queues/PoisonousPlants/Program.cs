using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousPlants
{
    class Program
    {
        static void Main()
        {
            var plantsCount = int.Parse(Console.ReadLine());
            var plantsData = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            plantsData.Reverse();


            var plants = new Queue<int?>();
            foreach (var pData in plantsData)
            {
                plants.Enqueue(pData);
            }

            var day = 1;
            while (true)
            {
                var before = plants.Where(p => p.HasValue).Count();

                // kill plants
                for (int i = 0; i < plants.Count; i++)
                {
                    var plant = plants.Dequeue();
                    var left = plants.Peek();

                    if(plant <= left)
                    {
                        plants.Enqueue(plant);
                    }
                    else
                    {
                        plants.Enqueue(null);
                    }
                }

                var after = plants.Where(p => p.HasValue).Count();

                Console.WriteLine("Before: " + before + " Survived: " + after);

                if (before == after) // no plants died
                {
                    Console.WriteLine(day);
                    break;
                }
                else
                {
                    day++;
                }
            }
        }
    }
}
