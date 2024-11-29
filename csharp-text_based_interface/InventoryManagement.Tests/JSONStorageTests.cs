using NUnit.Framework;
using InventoryLibrary;
using System;
using System.IO;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class JSONStorageTests
    {
        private const string FilePath = "storage/inventory_manager.json";
        private JSONStorage _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new JSONStorage();

            // Clear the JSON file to ensure a fresh start for each test
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "{}");
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Optionally clean up the file
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }

        [Test]
        public void JSONStorage_ShouldInitializeWithEmptyDictionary()
        {
            var allObjects = _storage.All();
            Assert.IsNotNull(allObjects, "The storage's dictionary is null.");
            Assert.IsEmpty(allObjects ?? new Dictionary<string, BaseClass>(), "The storage's dictionary is not empty.");
        }

        [Test]
        public void JSONStorage_ShouldAddNewObject()
        {
            var item = new Item("Test Item", 0.0f);
            _storage.New(item);
            _storage.Save();  // Save the new item

            // Reload the storage to ensure data is loaded from file
            _storage.Load();
            
            var allObjects = _storage.All();
            var expectedKey = $"Item.{item.Id}";

            // Check if the item is stored with the correct key
            Assert.IsTrue(allObjects?.ContainsKey(expectedKey) == true, "The item was not added correctly.");

            // Verify the item's name
            var storedItem = allObjects?[expectedKey] as Item;
            Assert.IsNotNull(storedItem, "The item retrieved from storage is null.");
            Assert.AreEqual("Test Item", storedItem.Name, "The stored item does not have the expected name.");
        }

        [Test]
        public void JSONStorage_Load_EmptyFile_InitializesStorage()
        {
            // Ensure the file is empty before the test
            _storage.Save();  // Create/clear the file

            _storage.Load();  // Load from the empty file

            var allObjects = _storage.All();
            Assert.IsNotNull(allObjects);
            Assert.IsEmpty(allObjects ?? new Dictionary<string, BaseClass>());
        }

        [Test]
        public void JSONStorage_SaveAndLoad_ConsistentData()
        {
            var item = new Item("Consistent Item", 19.99f);

            _storage.New(item);
            _storage.Save();

            // Create a new storage instance to simulate reloading
            var newStorage = new JSONStorage();
            newStorage.Load();

            var allObjects = newStorage.All();
            var itemKey = $"Item.{item.Id}";

            Assert.IsTrue(allObjects.ContainsKey(itemKey));
            var storedItem = allObjects[itemKey] as Item;

            Assert.IsNotNull(storedItem);
            Assert.AreEqual(item.Name, storedItem.Name);
            Assert.AreEqual(item.Price, storedItem.Price);
        }

        [Test]
        public void JSONStorage_DeleteObject_RemovesObject()
        {
            var item = new Item("Deletable Item", 25.99f);

            _storage.New(item);
            _storage.Save();

            // Remove and save
            var allObjects = _storage.All();
            if (allObjects != null)
            {
                allObjects.Remove($"Item.{item.Id}");
                _storage.Save();
            }

            // Reload storage
            _storage.Load();

            allObjects = _storage.All();
            Assert.IsFalse(allObjects?.ContainsKey($"Item.{item.Id}") == true);
        }
    }
}
