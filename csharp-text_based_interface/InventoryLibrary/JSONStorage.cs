using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    /// <summary>
    /// Storage Class using JSON for persisting objects.
    /// </summary>
    public class JSONStorage
    {
        // Dictionary to store objects with keys as <ClassName>.<id>
        public Dictionary<string, BaseClass> objects { get; set; }

        // Path to the JSON file where data will be stored
        private string filePath = "storage/inventory_manager.json";

        /// <summary>
        /// Initializes a new instance of JSONStorage.
        /// </summary>
        public JSONStorage()
        {
            objects = new Dictionary<string, BaseClass>();
        }

        /// <summary>
        /// Method to return all objects in the storage.
        /// </summary>
        /// <returns>Dictionary of objects.</returns>
        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }

        /// <summary>
        /// Method to add a new object to the dictionary.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public void New(BaseClass obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Generate a key based on the object's type and id
            string key = $"{obj.GetType().Name}.{obj.id}";
            objects[key] = obj;
        }

        /// <summary>
        /// Method to serialize the objects and save them to a JSON file.
        /// </summary>
        public void Save()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Serialize the objects dictionary to JSON and write to file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() } // Handle enums, if any
            };
            string jsonString = JsonSerializer.Serialize(objects, options);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Method to load the objects from the JSON file and deserialize them.
        /// </summary>
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
            else
            {
                // Initialize objects as an empty dictionary if file does not exist
                objects = new Dictionary<string, BaseClass>();
            }
        }
    }
}
