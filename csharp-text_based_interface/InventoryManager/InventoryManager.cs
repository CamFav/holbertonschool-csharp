using System;
using System.Collections.Generic;
using System.Linq;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        private static JSONStorage _storage = new JSONStorage();

        static void Main(string[] args)
        {
            try
            {
                _storage.Load(); // Load data from JSON on start

                while (true)
                {
                    DisplayMenu();
                    var input = Console.ReadLine();
                    if (input == null) continue;

                    var parts = input.Split(' ', 2);
                    var command = parts[0].ToLower();

                    switch (command)
                    {
                        case "classname":
                            ShowClassNames();
                            break;
                        case "all":
                            if (parts.Length == 1)
                                ShowAllObjects();
                            else
                                ShowAllObjects(parts[1]);
                            break;
                        case "create":
                            if (parts.Length == 1)
                                CreateObject(parts[1]);
                            else
                                Console.WriteLine("Please provide a class name.");
                            break;
                        case "show":
                            if (parts.Length == 2)
                                ShowObject(parts[1]);
                            else
                                Console.WriteLine("Please provide an object ID.");
                            break;
                        case "update":
                            if (parts.Length == 2)
                                UpdateObject(parts[1]);
                            else
                                Console.WriteLine("Please provide an object ID.");
                            break;
                        case "delete":
                            if (parts.Length == 2)
                                DeleteObject(parts[1]);
                            else
                                Console.WriteLine("Please provide an object ID.");
                            break;
                        case "exit":
                            _storage.Save(); // Save data to JSON before exiting
                            return;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ClassNames - show all ClassNames of objects");
            Console.WriteLine("All - show all objects");
            Console.WriteLine("All [ClassName] - show all objects of a ClassName");
            Console.WriteLine("Create [ClassName] - create a new object");
            Console.WriteLine("Show [ClassName] [id] - show an object");
            Console.WriteLine("Update [ClassName] [id] - update an object");
            Console.WriteLine("Delete [ClassName] [id] - delete an object");
            Console.WriteLine("Exit - quit the application");
            Console.Write("Enter command: ");
        }

        private static void ShowClassNames()
        {
            var classNames = _storage.All().Keys.Select(key => key.Split('.')[0]).Distinct();
            Console.WriteLine("Available classes: " + string.Join(", ", classNames));
        }

        private static void ShowAllObjects()
        {
            foreach (var obj in _storage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void ShowAllObjects(string className)
        {
            var filtered = _storage.All().Where(kvp => kvp.Key.StartsWith(className + ".")).ToList();
            if (filtered.Any())
            {
                foreach (var obj in filtered)
                {
                    Console.WriteLine($"{obj.Key}: {obj.Value}");
                }
            }
            else
            {
                Console.WriteLine($"No objects found for class {className}");
            }
        }

        private static void CreateObject(string className)
        {
            // Handle creation based on className
            Console.WriteLine($"Creating new object of class {className}");
            if (className.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter email: ");
                var email = Console.ReadLine();
                if (name != null && email != null)
                {
                    var newUser = new User(name, email);
                    _storage.New(newUser);
                    _storage.Save();
                }
            }
            else if (className.Equals("item", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter price: ");
                if (float.TryParse(Console.ReadLine(), out var price))
                {
                    var newItem = new Item(name, price);
                    _storage.New(newItem);
                    _storage.Save();
                }
            }
            else if (className.Equals("inventory", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter user ID: ");
                var userId = Console.ReadLine();
                Console.Write("Enter item ID: ");
                var itemId = Console.ReadLine();
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out var quantity))
                {
                    if (quantity < 0) quantity = 1; // enforce minimum quantity
                    var newInventory = new Inventory(userId, itemId, quantity);
                    _storage.New(newInventory);
                    _storage.Save();
                }
            }
            else
            {
                Console.WriteLine($"Class {className} is not recognized.");
            }
        }

        private static void ShowObject(string classNameId)
        {
            if (_storage.All().TryGetValue(classNameId, out var obj))
            {
                Console.WriteLine($"{classNameId}: {obj}");
            }
            else
            {
                Console.WriteLine($"Object {classNameId} could not be found");
            }
        }

        private static void UpdateObject(string classNameId)
        {
            // Implementation of object update based on classNameId
            Console.WriteLine($"Updating object with ID {classNameId}");
            // Example:
            // var obj = _storage.All()[classNameId];
            // Update properties
            // _storage.Save();
        }

        private static void DeleteObject(string classNameId)
        {
            if (_storage.All().Remove(classNameId))
            {
                Console.WriteLine($"Deleted object {classNameId}");
                _storage.Save();
            }
            else
            {
                Console.WriteLine($"Object {classNameId} could not be found");
            }
        }
    }
}
