using NUnit.Framework;
using InventoryLibrary;
using System;


namespace InventoryManagement.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            Assert.AreEqual(user.Id, inventory.UserId);
            Assert.AreEqual(item.Id, inventory.ItemId);
            Assert.AreEqual(5, inventory.Quantity);
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenUserIdIsNull()
        {
            var item = new Item("Sample Item", 29.99f);

            Assert.Throws<ArgumentNullException>(() => new Inventory(null!, item.Id, 5));
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenItemIdIsNull()
        {
            var user = new User("John Doe", "john.doe@example.com");

            Assert.Throws<ArgumentNullException>(() => new Inventory(user.Id, null!, 5));
        }

        [Test]
        public void Constructor_ThrowsArgumentOutOfRangeException_WhenQuantityIsNegative()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Inventory(user.Id, item.Id, -1));
        }
    }
}
