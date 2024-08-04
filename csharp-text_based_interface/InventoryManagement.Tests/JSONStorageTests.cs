using System.Collections.Generic;
using NUnit.Framework;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class JSONStorageTests
    {
        [Test]
        public void JSONStorage_ShouldInitializeWithEmptyDictionary()
        {
            var storage = new JSONStorage();
            var allObjects = storage.All();
            Assert.IsNotNull(allObjects);
            Assert.IsEmpty(allObjects);
        }

        [Test]
        public void JSONStorage_ShouldAddNewObject()
        {
            var storage = new JSONStorage();
            var item = new Item("Test Item", 0.0f); 

            storage.New(item);

            var allObjects = storage.All();
            Assert.IsTrue(allObjects.ContainsKey("Item.item1"));
        }
    }
}
