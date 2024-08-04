using System;
using System.Linq;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        private static readonly JSONStorage Storage = new();

        static void Main(string[] args)
        {
            Storage.Load();
            while (true)
            {
                PrintCommands();
                var command = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(command)) continue;
                
                var parts = command.Split(' ', 2);
                var action = parts[0].ToLower();

                switch (action)
                {
                    case "exit":
                        return;
                    case "classnames":
                        PrintClassNames();
                        break;
                    case "all":
                        PrintAll(parts.ElementAtOrDefault(1));
                        break;
                    case "create":
                        Create(parts.ElementAtOrDefault(1));
                        break;
                    case "show":
                        Show(parts.ElementAtOrDefault(1));
                        break;
                    case "update":
                        Update(parts.ElementAtOrDefault(1));
                        break;
                    case "delete":
                        Delete(parts.ElementAtOrDefault(1));
                        break;
                    default:
                        Console.WriteLine($"{action} is not a valid command.");
                        break;
                }
            }
        }

        private static void PrintCommands()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ClassNames - show all ClassNames of objects");
            Console.WriteLine("All - show all objects");
            Console.WriteLine("All [ClassName] - show all objects of a ClassName");
            Console.WriteLine("Create [ClassName] - create and save a new object of ClassName");
            Console.WriteLine("Show [ClassName object_id] - show the details of an object");
            Console.WriteLine("Update [ClassName object_id] - update the properties of an object");
            Console.WriteLine("Delete [ClassName object_id] - delete an object");
            Console.WriteLine("Exit - quit the application");
        }

        private static void PrintClassNames()
        {
            var classNames = Storage.All().Keys.Select(k => k.Split('.')[0]).Distinct();
            Console.WriteLine("Class Names:");
            foreach (var name in classNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void PrintAll(string className)
        {
            var objects = Storage.All();
            if (string.IsNullOrWhiteSpace(className))
            {
                foreach (var kvp in objects)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                var filtered = objects.Where(kvp => kvp.Key.StartsWith(className)).ToList();
                foreach (var kvp in filtered)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }

        private static void Create(string className)
        {
            // Implement object creation logic here
        }

        private static void Show(string classNameAndId)
        {
            // Implement object display logic here
        }

        private static void Update(string classNameAndId)
        {
            // Implement object update logic here
        }

        private static void Delete(string classNameAndId)
        {
            // Implement object deletion logic here
        }
    }
}
