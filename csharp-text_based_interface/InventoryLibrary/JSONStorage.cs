using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryLibrary
{
    /// <summary>
    /// Manages storage of objects in JSON format.
    /// </summary>
    public class JSONStorage
    {
        private const string FilePath = "storage/inventory_manager.json";
        private readonly Dictionary<string, BaseClass> objects = new();

        /// <summary>
        /// Gets all objects.
        /// </summary>
        public Dictionary<string, BaseClass> All() => new Dictionary<string, BaseClass>(objects);

        /// <summary>
        /// Adds a new object to the storage.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void New(BaseClass obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            var key = $"{obj.GetType().Name}.{obj.Id}";
            objects[key] = obj;
        }

        /// <summary>
        /// Saves all objects to a JSON file.
        /// </summary>
        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            var json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        /// <summary>
        /// Loads objects from the JSON file.
        /// </summary>
        public void Load()
        {
            if (!File.Exists(FilePath)) return;

            var json = File.ReadAllText(FilePath);
            objects.Clear();
            var loadedObjects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json);
            foreach (var kvp in loadedObjects)
            {
                objects[kvp.Key] = kvp.Value;
            }
        }
    }
}
