using System;

namespace InventoryLibrary
{
    public class Inventory : BaseClass
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }

        public Inventory(string userId, string itemId, int quantity)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            ItemId = itemId ?? throw new ArgumentNullException(nameof(itemId));
            Quantity = quantity < 0 ? throw new ArgumentOutOfRangeException(nameof(quantity)) : quantity;
        }
    }
}
