using Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Startup
    {
        private static int selection = 0;
        private static List<TaskBase> tasks = new List<TaskBase>();

        static void Main()
        {
            tasks.Add(new OddLines());
            tasks.Add(new OddLines());
            tasks.Add(new OddLines());

            Console.CursorVisible = false;

            RenderMenu();
            while (true)
            {
                ParseInput();
            }
        }

        private static void ParseInput()
        {
            var lastSelection = selection;
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        selection = (selection == 0)
                            ? selection = tasks.Count - 1
                            : selection - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        selection = (selection == tasks.Count - 1)
                            ? selection = 0
                            : selection + 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        ExecuteTask();
                    }
                    return;
                case ConsoleKey.Escape:
                    {
                        Environment.Exit(0);
                    }
                    return;
            }

            if(selection != lastSelection)
            {
                UpdateMenu();
            }
        }

        private static void ExecuteTask()
        {
            try
            {
                tasks[selection].Execute();
                Console.Write($"{Environment.NewLine}[Successfully] executed task");
            }
            catch(Exception e)
            {
                Console.Write($"{Environment.NewLine}[Error] - {e.GetType()}");
            }
            finally
            {
                Console.Write($", press [Any] key to return...{Environment.NewLine}");
            }

            Console.ReadKey();
            UpdateMenu();
        }

        private static void RenderMenu()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];

                Console.BackgroundColor = (selection == i)
                    ? ConsoleColor.White
                    : ConsoleColor.Black;

                Console.WriteLine($"{i+1}. {task.DisplayName}");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPress [enter] to execute or [esc] to terminate the program.");
        }

        private static void UpdateMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            RenderMenu();
        }
    }
}
