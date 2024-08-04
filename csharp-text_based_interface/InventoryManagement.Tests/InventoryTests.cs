using System;
using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void Inventory_ShouldInheritFromBaseClass()
        {
            var inventory = new Inventory();
            Assert.IsAssignableFrom<BaseClass>(inventory);
        }

        [Fact]
        public void Inventory_ShouldNotAllowNegativeQuantity()
        {
            var inventory = new Inventory();
            Assert.Throws<ArgumentOutOfRangeException>(() => inventory.Quantity = -1);
        }
    }
}
