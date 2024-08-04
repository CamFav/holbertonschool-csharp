using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventoryLibrary;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    /// <summary>
    /// Manages storage of <see cref="BaseClass"/> objects in a JSON file.
    /// </summary>
    public class JSONStorage
    {
        private readonly string _filePath = "storage/inventory_manager.json";
        private readonly JsonSerializerOptions _jsonOptions;

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
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() } // Add custom converters if necessary
            };
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
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            Objects[$"{obj.GetType().Name}.{obj.Id}"] = obj;
        }

        /// <summary>
        /// Serializes and saves all stored objects to a JSON file.
        /// </summary>
        public void Save()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath) ?? string.Empty);
                var json = JsonSerializer.Serialize(Objects, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads and deserializes objects from a JSON file.
        /// </summary>
        public void Load()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var json = File.ReadAllText(_filePath);
                    Objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json, _jsonOptions)
                               ?? new Dictionary<string, BaseClass>();
                }
                else
                {
                    Objects = new Dictionary<string, BaseClass>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error loading data: {ex.Message}");
                Objects = new Dictionary<string, BaseClass>();
            }
        }
    }
}
