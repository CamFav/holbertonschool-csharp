using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        private readonly string _filePath = "storage/inventory_manager.json";
        public Dictionary<string, BaseClass> Objects { get; private set; }

        public JSONStorage()
        {
            Objects = new Dictionary<string, BaseClass>();
            Load();
        }

        public Dictionary<string, BaseClass> All()
        {
            return Objects;
        }

        public void New(BaseClass obj)
        {
            Objects[$"{obj.GetType().Name}.{obj.Id}"] = obj;
        }

        public void Save()
        {
            var directoryPath = Path.GetDirectoryName(_filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(Objects, options);
            File.WriteAllText(_filePath, json);
        }

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
