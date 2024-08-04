using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        public Dictionary<string, BaseClass> objects { get; set; }

        // Path to the JSON file
        private string filePath = "storage/inventory_manager.json";

        public JSONStorage()
        {
            objects = new Dictionary<string, BaseClass>();
        }

        // Method to return all objects
        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }

        // Method to add a new object to the dictionary
        public void New(BaseClass obj)
        {
            string key = $"{obj.GetType().Name}.{obj.id}";
            objects[key] = obj;
        }

        // Method to serialize the objects and save them to a JSON file
        public void Save()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            
            // Serialize the objects dictionary to JSON and write to file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            string jsonString = JsonSerializer.Serialize(objects, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Method to load the objects from the JSON file and deserialize them
        public void Load()
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read JSON string from file
                string jsonString = File.ReadAllText(filePath);
                
                // Deserialize JSON string to a dictionary
                objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString);
            }
        }
    }
}
