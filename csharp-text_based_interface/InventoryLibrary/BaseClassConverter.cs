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
            "Item" => JsonSerializer.Deserialize<Item>(root.GetRawText(), options) as BaseClass,
            "Inventory" => JsonSerializer.Deserialize<Inventory>(root.GetRawText(), options) as BaseClass,
            "User" => JsonSerializer.Deserialize<User>(root.GetRawText(), options) as BaseClass,
            _ => throw new NotSupportedException($"Type '{type}' is not supported.")
        } ?? throw new JsonException("Deserialization resulted in a null object.");
    }
}


        public override void Write(Utf8JsonWriter writer, BaseClass value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("Type", value.GetType().Name);

            var json = JsonSerializer.Serialize(value, value.GetType(), options);

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
