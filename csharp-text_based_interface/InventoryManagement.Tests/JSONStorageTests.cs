using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using InventoryLibrary;

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
            // Ensure that the file is empty before checking the storage
            if (File.Exists(FilePath))
            {
                var fileContent = File.ReadAllText(FilePath);
                Console.WriteLine("Loaded JSON:");
                Console.WriteLine(fileContent);
            }

            var allObjects = _storage.All();
            Assert.IsNotNull(allObjects, "The storage's dictionary is null.");
            Assert.IsEmpty(allObjects, "The storage's dictionary is not empty.");
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
            Assert.IsTrue(allObjects.ContainsKey(expectedKey), "The item was not added correctly.");

            // Verify the item's name
            var storedItem = allObjects[expectedKey] as Item;
            Assert.IsNotNull(storedItem, "The item retrieved from storage is null.");
            Assert.AreEqual("Test Item", storedItem.Name, "The stored item does not have the expected name.");
        }
    }
}
