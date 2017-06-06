using Exercises;
using Exercises.Tasks;
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
            InitMenu();

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
                Console.Write($"{Environment.NewLine}[Error] - {e.Message}");
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

        private static void InitMenu()
        {
            // todo: need to write attributes, for proper
            // UI ordering, so for now manually adding them

            //foreach (var taskType in Utils.GetDerivedTasks())
            //{
            //    tasks.Add(Activator.CreateInstance(taskType) as TaskBase);
            //}

            tasks.Add(new OddLines());
            tasks.Add(new LineNumbers());
            tasks.Add(new WordCount());
            tasks.Add(new CopyBinaryFile());
            tasks.Add(new SlicingFile());

            Console.CursorVisible = false;
            RenderMenu();
        }

        private static void UpdateMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            RenderMenu();
        }
    }
}
