using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>
    /// Manages the storage of <see cref="BaseClass"/> objects in a JSON file.
    /// </summary>
    public class JSONStorage
    {
        private readonly string _filePath = "storage/inventory_manager.json";

        /// <summary>
        /// Gets the dictionary of stored objects, keyed by their type and identifier.
        /// </summary>
        public Dictionary<string, BaseClass> Objects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONStorage"/> class and loads existing data.
        /// </summary>
        public JSONStorage()
        {
            Objects = new Dictionary<string, BaseClass>();
            Load();
        }

        /// <summary>
        /// Retrieves all stored objects.
        /// </summary>
        /// <returns>A dictionary of all stored objects.</returns>
        public Dictionary<string, BaseClass> All()
        {
            return Objects;
        }

        /// <summary>
        /// Adds a new object to the storage.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void New(BaseClass obj)
        {
            Objects[$"{obj.GetType().Name}.{obj.Id}"] = obj;
        }

        /// <summary>
        /// Saves all stored objects to the JSON file.
        /// </summary>
        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(Objects, options);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Loads objects from the JSON file.
        /// </summary>
        public void Load()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };
                Objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json, options) ?? new Dictionary<string, BaseClass>();
            }
            else
            {
                Objects = new Dictionary<string, BaseClass>();
            }
        }
    }
}
