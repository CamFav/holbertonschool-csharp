using System;
using System.Collections.Generic;
using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Item_ShouldInheritFromBaseClass()
        {
            var item = new Item();
            Assert.IsAssignableFrom<BaseClass>(item);
        }

        [Fact]
        public void Item_ShouldInitializeWithDefaultValues()
        {
            var item = new Item
            {
                Name = "Test Item",
                Description = "Test Description",
                Price = 9.99f,
                Tags = new List<string> { "Tag1", "Tag2" }
            };

            Assert.Equal("Test Item", item.Name);
            Assert.Equal("Test Description", item.Description);
            Assert.Equal(9.99f, item.Price);
            Assert.Equal(2, item.Tags.Count);
        }
    }
}
