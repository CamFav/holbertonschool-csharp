using System;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents an inventory record linking a user and an item.
    /// </summary>
    public class Inventory : BaseClass
    {
        /// <summary>
        /// Gets or sets the user ID linked to the inventory record.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the item ID linked to the inventory record.
        /// </summary>
        public string ItemId { get; set; }

        private int quantity;

        /// <summary>
        /// Gets or sets the quantity of the item in inventory.
        /// </summary>
        public int Quantity
        {
            get => quantity;
            set => quantity = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be less than zero.");
        }
    }
}
