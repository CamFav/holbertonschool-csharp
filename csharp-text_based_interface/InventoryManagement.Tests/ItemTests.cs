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
            Assert.AreEqual(DateTime.UtcNow.Date, item.DateCreated.Date);
            Assert.AreEqual(DateTime.UtcNow.Date, item.DateUpdated.Date);
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
        public void Property_SetDescription_HandlesNull()
        {
            var item = new Item("Another Item", 49.99f);
            item.Description = null;

            Assert.IsNull(item.Description);
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
        public void Property_InitializedTags_IsEmpty()
        {
            var item = new Item("Empty Tags Item", 15.99f);

            Assert.IsEmpty(item.Tags);
        }
    }
}
