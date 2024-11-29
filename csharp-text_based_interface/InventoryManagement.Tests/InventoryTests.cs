using NUnit.Framework;
using InventoryLibrary;
using System;
using System.Text.Json;


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

        [Test]
        public void Property_UserId_Getter_ReturnsCorrectValue()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            Assert.AreEqual(user.Id, inventory.UserId);
        }

        [Test]
        public void Property_ItemId_Getter_ReturnsCorrectValue()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            Assert.AreEqual(item.Id, inventory.ItemId);
        }

        [Test]
        public void Property_Quantity_Getter_ReturnsCorrectValue()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            Assert.AreEqual(5, inventory.Quantity);
        }

        [Test]
        public void Property_Quantity_Setter_UpdatesValue()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            inventory.Quantity = 10;
            Assert.AreEqual(10, inventory.Quantity);
        }

        [Test]
        public void UpdateQuantity_ThrowsArgumentOutOfRangeException_WhenNewQuantityIsNegative()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            Assert.Throws<ArgumentOutOfRangeException>(() => inventory.Quantity = -10);
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            var expected = $"Inventory [UserId={user.Id}, ItemId={item.Id}, Quantity=5]";
            Assert.AreEqual(expected, inventory.ToString());
        }

        // Assuming Inventory class has an appropriate Equals override
        [Test]
        public void Equals_ReturnsTrue_ForIdenticalInventories()
        {
            var user1 = new User("John Doe", "john.doe@example.com");
            var user2 = new User("John Doe", "john.doe@example.com");
            var item1 = new Item("Sample Item", 29.99f);
            var item2 = new Item("Sample Item", 29.99f);

            var inventory1 = new Inventory(user1.Id, item1.Id, 5);
            var inventory2 = new Inventory(user2.Id, item2.Id, 5);

            Assert.IsTrue(inventory1.Equals(inventory2));
        }

        [Test]
        public void Equals_ReturnsFalse_ForDifferentInventories()
        {
            var user1 = new User("John Doe", "john.doe@example.com");
            var user2 = new User("Jane Doe", "jane.doe@example.com");
            var item1 = new Item("Sample Item", 29.99f);
            var item2 = new Item("Another Item", 39.99f);

            var inventory1 = new Inventory(user1.Id, item1.Id, 5);
            var inventory2 = new Inventory(user2.Id, item2.Id, 10);

            Assert.IsFalse(inventory1.Equals(inventory2));
        }

        // Assuming Inventory class has appropriate serialization/deserialization methods
        [Test]
        public void Serialization_Deserialization_ProducesSameInventory()
        {
            var user = new User("John Doe", "john.doe@example.com");
            var item = new Item("Sample Item", 29.99f);
            var inventory = new Inventory(user.Id, item.Id, 5);

            var serialized = JsonSerializer.Serialize(inventory);
            var deserialized = JsonSerializer.Deserialize<Inventory>(serialized);

            Assert.AreEqual(inventory, deserialized);
        }
    }
}
