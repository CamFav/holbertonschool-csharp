using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents an item with a name, description, price, and associated tags.
    /// </summary>
    public class Item : BaseClass
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the list of tags associated with the item.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class with the specified name and price.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="price">The price of the item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
        public Item(string name, float price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Tags = new List<string>();
        }
    }
}
