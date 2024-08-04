using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class BaseClassConverter : JsonConverter<BaseClass>
    {
        public override BaseClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
    {
        var root = doc.RootElement;

        if (!root.TryGetProperty("Type", out var typeProp) || typeProp.ValueKind != JsonValueKind.String)
        {
            throw new JsonException("Missing or invalid 'Type' property.");
        }

        string type = typeProp.GetString() ?? throw new JsonException("Type property cannot be null.");

        return type switch
        {
            "Item" => JsonSerializer.Deserialize<Item>(root.GetRawText(), options),
            "Inventory" => JsonSerializer.Deserialize<Inventory>(root.GetRawText(), options),
            "User" => JsonSerializer.Deserialize<User>(root.GetRawText(), options),
            _ => throw new NotSupportedException($"Type '{type}' is not supported.")
        };
    }
}


        public override void Write(Utf8JsonWriter writer, BaseClass value, JsonSerializerOptions options)
        {
            // Write the object as a JSON object with a 'Type' property
            writer.WriteStartObject();
            writer.WriteString("Type", value.GetType().Name);

            // Serialize the specific object without additional wrapping
            var json = JsonSerializer.Serialize(value, value.GetType(), options);

            // Parse the serialized JSON and write the raw value to avoid extra braces
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                foreach (var property in doc.RootElement.EnumerateObject())
                {
                    property.WriteTo(writer);
                }
            }

            writer.WriteEndObject();
        }
    }
}
