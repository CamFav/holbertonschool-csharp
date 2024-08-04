using System;
using System.Collections.Generic;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        private static JSONStorage _storage;

        static void Main(string[] args)
        {
            _storage = new JSONStorage();
            DisplayPrompt();

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrEmpty(input)) continue;

                var commandParts = input.Split(' ', 2);
                var command = commandParts[0];
                var argument = commandParts.Length > 1 ? commandParts[1] : null;

                switch (command)
                {
                    case "classnames":
                        PrintClassNames();
                        break;

                    case "all":
                        if (string.IsNullOrEmpty(argument))
                        {
                            PrintAllObjects();
                        }
                        else
                        {
                            PrintAllObjects(argument);
                        }
                        break;

                    case "create":
                        if (string.IsNullOrEmpty(argument))
                        {
                            Console.WriteLine("Usage: Create <ClassName>");
                        }
                        else
                        {
                            CreateObject(argument);
                        }
                        break;

                    case "show":
                        if (string.IsNullOrEmpty(argument))
                        {
                            Console.WriteLine("Usage: Show <ClassName> <id>");
                        }
                        else
                        {
                            ShowObject(argument);
                        }
                        break;

                    case "update":
                        if (string.IsNullOrEmpty(argument))
                        {
                            Console.WriteLine("Usage: Update <ClassName> <id>");
                        }
                        else
                        {
                            UpdateObject(argument);
                        }
                        break;

                    case "delete":
                        if (string.IsNullOrEmpty(argument))
                        {
                            Console.WriteLine("Usage: Delete <ClassName> <id>");
                        }
                        else
                        {
                            DeleteObject(argument);
                        }
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        break;
                }

                DisplayPrompt();
            }
        }

        private static void DisplayPrompt()
        {
            Console.WriteLine("\nInventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ClassNames: show all ClassNames of objects");
            Console.WriteLine("All: show all objects");
            Console.WriteLine("All <ClassName>: show all objects of a ClassName");
            Console.WriteLine("Create <ClassName>: a new object");
            Console.WriteLine("Show <ClassName> <id>: an object");
            Console.WriteLine("Update <ClassName> <id>: an object");
            Console.WriteLine("Delete <ClassName> <id>: an object");
            Console.WriteLine("Exit: quit the application");
        }

        private static void PrintClassNames()
        {
            var classNames = new HashSet<string>();
            foreach (var obj in _storage.All().Values)
            {
                classNames.Add(obj.GetType().Name);
            }

            if (classNames.Count == 0)
            {
                Console.WriteLine("No objects found.");
            }
            else
            {
                Console.WriteLine("Class Names:");
                foreach (var className in classNames)
                {
                    Console.WriteLine($"- {className}");
                }
            }
        }

        private static void PrintAllObjects()
        {
            if (_storage.All().Count == 0)
            {
                Console.WriteLine("No objects found.");
                return;
            }

            foreach (var obj in _storage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void PrintAllObjects(string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                Console.WriteLine("Invalid class name.");
                return;
            }

            var found = false;
            foreach (var obj in _storage.All())
            {
                if (obj.Key.StartsWith($"{className}."))
                {
                    Console.WriteLine($"{obj.Key}: {obj.Value}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No objects of class {className} found.");
            }
        }

        private static void CreateObject(string className)
        {
            // For simplicity, creating a new Item object. Adjust for other types as needed.
            if (className.Equals("item", StringComparison.OrdinalIgnoreCase))
            {
                var newItem = new Item("New Item", 0.0f);
                _storage.New(newItem);
                _storage.Save();
                Console.WriteLine($"Created new {className} with ID {newItem.Id}.");
            }
            else
            {
                Console.WriteLine($"{className} is not a valid object type.");
            }
        }

        private static void ShowObject(string argument)
        {
            var parts = argument.Split(' ', 2);
            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: Show <ClassName> <id>");
                return;
            }

            var className = parts[0];
            var id = parts[1];
            var key = $"{className}.{id}";

            if (_storage.All().TryGetValue(key, out var obj))
            {
                Console.WriteLine(obj);
            }
            else
            {
                Console.WriteLine($"Object {id} could not be found.");
            }
        }

        private static void UpdateObject(string argument)
        {
            var parts = argument.Split(' ', 2);
            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: Update <ClassName> <id>");
                return;
            }

            var className = parts[0];
            var id = parts[1];
            var key = $"{className}.{id}";

            if (_storage.All().TryGetValue(key, out var obj))
            {
                // For simplicity, assume updating the name of an Item object.
                if (obj is Item item)
                {
                    Console.Write("Enter new name: ");
                    var newName = Console.ReadLine();
                    item.Name = newName;
                    item.DateUpdated = DateTime.UtcNow; // Update the date as well
                    _storage.Save();
                    Console.WriteLine($"Updated {className} with ID {id}.");
                }
                else
                {
                    Console.WriteLine($"Cannot update object of type {className}.");
                }
            }
            else
            {
                Console.WriteLine($"Object {id} could not be found.");
            }
        }

        private static void DeleteObject(string argument)
        {
            var parts = argument.Split(' ', 2);
            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: Delete <ClassName> <id>");
                return;
            }

            var className = parts[0];
            var id = parts[1];
            var key = $"{className}.{id}";

            if (_storage.All().Remove(key))
            {
                _storage.Save();
                Console.WriteLine($"Deleted {className} with ID {id}.");
            }
            else
            {
                Console.WriteLine($"Object {id} could not be found.");
            }
        }
    }
}
