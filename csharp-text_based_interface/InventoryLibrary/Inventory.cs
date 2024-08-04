using System;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents an inventory record that tracks the quantity of an item for a specific user.
    /// </summary>
    public class Inventory : BaseClass
    {
        /// <summary>
        /// Gets or sets the user identifier associated with the inventory record.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier associated with the inventory record.
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item in the inventory.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class with the specified user identifier, item identifier, and quantity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="quantity">The quantity of the item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="userId"/> or <paramref name="itemId"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="quantity"/> is less than zero.</exception>
        public Inventory(string userId, string itemId, int quantity)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            ItemId = itemId ?? throw new ArgumentNullException(nameof(itemId));
            Quantity = quantity < 0 ? throw new ArgumentOutOfRangeException(nameof(quantity)) : quantity;
        }
    }
}
