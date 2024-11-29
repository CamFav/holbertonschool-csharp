using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; } = "Inventory";

        public string UserId { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }

        public Inventory(string userId, string itemId, int quantity = 1)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            ItemId = itemId ?? throw new ArgumentNullException(nameof(itemId));
            Quantity = quantity > 0 ? quantity : 1;
        }

        public override string ToString()
        {
            return $"Inventory [UserId={UserId}, ItemId={ItemId}, Quantity={Quantity}, DateCreated={DateCreated}, DateUpdated={DateUpdated}]";
        }

    }
}
