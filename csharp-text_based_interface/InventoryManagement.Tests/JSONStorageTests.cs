using System.Collections.Generic;
using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class JSONStorageTests
    {
        [Fact]
        public void JSONStorage_ShouldInitializeWithEmptyDictionary()
        {
            var storage = new JSONStorage();
            var allObjects = storage.All();
            Assert.NotNull(allObjects);
            Assert.Empty(allObjects);
        }

        [Fact]
        public void JSONStorage_ShouldAddNewObject()
        {
            var storage = new JSONStorage();
            var item = new Item { Id = "item1", Name = "Test Item" };
            storage.New(item);

            var allObjects = storage.All();
            Assert.Contains("Item.item1", allObjects.Keys);
        }
    }
}
