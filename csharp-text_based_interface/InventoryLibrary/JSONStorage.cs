using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    /// <summary>
    /// Handles storage of objects in a JSON file.
    /// </summary>
    public class JSONStorage
    {
        private readonly string _filePath = "storage/inventory_manager.json";

        /// <summary>
        /// Gets all stored objects.
        /// </summary>
        public Dictionary<string, BaseClass> Objects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONStorage"/> class.
        /// </summary>
        public JSONStorage()
        {
            Objects = new Dictionary<string, BaseClass>();
            Load(); // Load the existing data (if any) from the JSON file
        }

        /// <summary>
        /// Retrieves all stored objects.
        /// </summary>
        /// <returns>A dictionary of stored objects with their keys.</returns>
        public Dictionary<string, BaseClass> All()
        {
            return Objects;
        }

        /// <summary>
        /// Adds a new object to storage.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public void New(BaseClass obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            string key = $"{obj.GetType().Name}.{obj.Id}";
            Objects[key] = obj;
        }

        /// <summary>
        /// Saves the current state of the storage to a JSON file.
        /// </summary>
        public void Save()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath) ?? string.Empty);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(), new BaseClassConverter() }
            };

            var json = JsonSerializer.Serialize(Objects, options);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Loads the state of the storage from a JSON file.
        /// </summary>
        public void Load()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    var json = File.ReadAllText(_filePath);
                    Console.WriteLine("Loaded JSON:");
                    Console.WriteLine(json);

                    var options = new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter(), new BaseClassConverter() }
                    };

                    Objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json, options) ?? new Dictionary<string, BaseClass>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error parsing JSON:");
                    Console.WriteLine(ex.Message);
                    Objects = new Dictionary<string, BaseClass>();
                }
            }
            else
            {
                // If the file does not exist, initialize with an empty dictionary
                Objects = new Dictionary<string, BaseClass>();
            }
        }
    }
}
