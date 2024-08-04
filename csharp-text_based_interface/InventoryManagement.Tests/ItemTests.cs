using NUnit.Framework;
using InventoryLibrary;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            var name = "Sample Item";
            var price = 29.99f;

            var item = new Item(name, price);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(price, item.Price);
            Assert.IsEmpty(item.Tags);
            Assert.IsNull(item.Description);
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Item(null!, 19.99f));
        }

        [Test]
        public void Property_SetDescription_SetsCorrectly()
        {
            var item = new Item("Another Item", 49.99f);
            var description = "Test description.";

            item.Description = description;

            Assert.AreEqual(description, item.Description);
        }

        [Test]
        public void Property_AddTags_SetsTagsCorrectly()
        {
            var item = new Item("Tagged Item", 9.99f);
            var tags = new List<string> { "Tag1", "Tag2" };

            item.Tags.AddRange(tags);

            CollectionAssert.AreEqual(tags, item.Tags);
        }

        [Test]
        public void JSONStorage_ShouldAddNewObject()
        {
            var storage = new JSONStorage();
            var item = new Item("Test Item", 0.0f);

            storage.New(item);
            storage.Save();  // Ensure data is written to file

            // Reload the storage to ensure data is loaded from file
            storage.Load();

            var allObjects = storage.All();
            var itemKey = $"Item.{item.Id}";  // Use the item's ID for the key

            // Verify that the item is stored correctly
            Assert.IsTrue(allObjects.ContainsKey(itemKey), $"The item with key {itemKey} was not added correctly.");
        }


    }
}
