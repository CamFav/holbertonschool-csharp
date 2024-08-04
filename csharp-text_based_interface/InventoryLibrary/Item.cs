using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public List<string> Tags { get; set; }

        public Item(string name, float price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Tags = new List<string>();
        }
    }
}
