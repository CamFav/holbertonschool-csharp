using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventoryLibrary;


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
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            var json = JsonSerializer.Serialize(Objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Load()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                Objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json) ?? new Dictionary<string, BaseClass>();
            }
            else
            {
                Objects = new Dictionary<string, BaseClass>();
            }
        }
    }
}
