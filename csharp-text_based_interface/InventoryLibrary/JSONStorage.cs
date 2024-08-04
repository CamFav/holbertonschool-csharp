using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Storage class for managing objects using JSON serialization.
/// </summary>
public class JSONStorage
{
    /// <summary>
    /// Dictionary to store objects with keys as <ClassName>.<id> and values as dynamic objects.
    /// </summary>
    public Dictionary<string, dynamic> objects { get; set; } = new Dictionary<string, dynamic>();

    /// <summary>
    /// Returns the dictionary of all objects stored.
    /// </summary>
    /// <returns>A dictionary where keys are <ClassName>.<id> and values are the objects.</returns>
    public Dictionary<string, dynamic> All() {
        return objects;
    }

    /// <summary>
    /// Adds a new object to the dictionary.
    /// </summary>
    /// <param name="obj">The object to be added.</param>
    public void New(BaseClass obj) {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        // Create a key based on the object's type and id
        string key = $"{obj.GetType().Name}.{obj.id}";
        objects[key] = obj;
    }

    /// <summary>
    /// Serializes all objects in the dictionary and saves them to a JSON file.
    /// </summary>
    public void Save() {
        // Serialize the objects dictionary to JSON
        string jsonString = JsonSerializer.Serialize(objects);

        // Ensure the directory exists
        Directory.CreateDirectory("storage");

        // Write JSON string to the file
        File.WriteAllText("storage/inventory_manager.json", jsonString);
    }

    /// <summary>
    /// Loads objects from the JSON file and deserializes them.
    /// </summary>
    public void Load() {
        if (Directory.Exists("storage") && File.Exists("storage/inventory_manager.json")) {
            // Read JSON string from the file
            string jsonString = File.ReadAllText("storage/inventory_manager.json");

            // Deserialize JSON string into a temporary dictionary
            Dictionary<string, dynamic> tmp = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonString);

            // Dictionary to store deserialized objects
            Dictionary<string, dynamic> objs = new Dictionary<string, dynamic>();

            foreach (var key in tmp.Keys) {
                // Deserialize each object and add to the dictionary
                objs[key] = nestedDeserialize(tmp[key].ToString());
            }

            objects = objs;
        }
    }

    /// <summary>
    /// Deserializes a JSON string into a specific object type.
    /// </summary>
    /// <param name="obj">The JSON string representing the object.</param>
    /// <returns>The deserialized object.</returns>
    private dynamic nestedDeserialize(string obj) {
        // Deserialize the JSON string into a dictionary
        Dictionary<string, string> tmp = JsonSerializer.Deserialize<Dictionary<string, string>>(obj);

        // Deserialize based on the type stored in the dictionary
        if (tmp["type"] == "User")
            return JsonSerializer.Deserialize<User>(obj);
        else if (tmp["type"] == "Item")
            return JsonSerializer.Deserialize<Item>(obj);
        else if (tmp["type"] == "Inventory")
            return JsonSerializer.Deserialize<Inventory>(obj);
        else
            return JsonSerializer.Deserialize<BaseClass>(obj);
    }

    /// <summary>
    /// Updates an object's property value and saves changes.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="key">The key identifying the object in the dictionary.</param>
    /// <param name="paramName">The property name to be updated.</param>
    /// <param name="val">The new value to set for the property.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    public bool updateObj<T>(string key, string paramName, dynamic val) {
        if (!objects.ContainsKey(key))
            return false;

        // Remove the existing object
        var obj = objects[key];
        objects.Remove(key);

        // Serialize and update the object
        var jsonString = JsonSerializer.Serialize(obj);
        var objDict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

        if (objDict.ContainsKey(paramName)) {
            objDict[paramName] = val.ToString();
            jsonString = JsonSerializer.Serialize(objDict);
            obj = JsonSerializer.Deserialize<T>(jsonString);

            // Add the updated object back to the dictionary
            New(obj);
            Save();
            return true;
        }

        return false;
    }
}
