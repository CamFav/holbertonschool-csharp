using NUnit.Framework;
using System;

namespace InventoryLibrary.Tests
{
    [TestFixture]
    public class BaseClassTests
    {
        [Test]
        public void Constructor_DefaultValues_AreSet()
        {
            // Arrange & Act
            var baseClassInstance = new TestBaseClass();

            // Assert
            Assert.IsNotNull(baseClassInstance.Id, "Id should not be null.");
            Assert.AreEqual(default(DateTime), baseClassInstance.DateCreated, "DateCreated should be default value.");
            Assert.AreEqual(default(DateTime), baseClassInstance.DateUpdated, "DateUpdated should be default value.");
        }

        [Test]
        public void Property_SetAndGetId_ReturnsCorrectValue()
        {
            // Arrange
            var baseClassInstance = new TestBaseClass();
            var expectedId = Guid.NewGuid().ToString();

            // Act
            baseClassInstance.Id = expectedId;

            // Assert
            Assert.AreEqual(expectedId, baseClassInstance.Id);
        }

        [Test]
        public void Property_SetAndGetDateCreated_ReturnsCorrectValue()
        {
            // Arrange
            var baseClassInstance = new TestBaseClass();
            var expectedDate = DateTime.UtcNow;

            // Act
            baseClassInstance.DateCreated = expectedDate;

            // Assert
            Assert.AreEqual(expectedDate, baseClassInstance.DateCreated);
        }

        [Test]
        public void Property_SetAndGetDateUpdated_ReturnsCorrectValue()
        {
            // Arrange
            var baseClassInstance = new TestBaseClass();
            var expectedDate = DateTime.UtcNow;

            // Act
            baseClassInstance.DateUpdated = expectedDate;

            // Assert
            Assert.AreEqual(expectedDate, baseClassInstance.DateUpdated);
        }

        [Test]
        public void Equals_TwoInstancesWithSameProperties_ReturnsTrue()
        {
            // Arrange
            var instance1 = new TestBaseClass
            {
                Id = "123",
                DateCreated = new DateTime(2024, 1, 1),
                DateUpdated = new DateTime(2024, 1, 2)
            };

            var instance2 = new TestBaseClass
            {
                Id = "123",
                DateCreated = new DateTime(2024, 1, 1),
                DateUpdated = new DateTime(2024, 1, 2)
            };

            // Act & Assert
            Assert.IsTrue(instance1.Equals(instance2));
        }

        [Test]
        public void Equals_TwoInstancesWithDifferentProperties_ReturnsFalse()
        {
            // Arrange
            var instance1 = new TestBaseClass
            {
                Id = "123",
                DateCreated = new DateTime(2024, 1, 1),
                DateUpdated = new DateTime(2024, 1, 2)
            };

            var instance2 = new TestBaseClass
            {
                Id = "456",
                DateCreated = new DateTime(2024, 1, 3),
                DateUpdated = new DateTime(2024, 1, 4)
            };

            // Act & Assert
            Assert.IsFalse(instance1.Equals(instance2));
        }

        [Test]
        public void Serialization_Deserialization_ProducesSameBaseClass()
        {
            // Arrange
            var baseClassInstance = new TestBaseClass
            {
                Id = "123",
                DateCreated = new DateTime(2024, 1, 1),
                DateUpdated = new DateTime(2024, 1, 2)
            };

            // Act
            var serialized = System.Text.Json.JsonSerializer.Serialize(baseClassInstance);
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<TestBaseClass>(serialized);

            // Assert
            Assert.AreEqual(baseClassInstance.Id, deserialized?.Id);
            Assert.AreEqual(baseClassInstance.DateCreated, deserialized?.DateCreated);
            Assert.AreEqual(baseClassInstance.DateUpdated, deserialized?.DateUpdated);
        }

        // A simple testable subclass of BaseClass for testing purposes
        private class TestBaseClass : BaseClass
        {
            public override bool Equals(object? obj)
            {
                if (obj is TestBaseClass other)
                {
                    return Id == other.Id &&
                           DateCreated == other.DateCreated &&
                           DateUpdated == other.DateUpdated;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, DateCreated, DateUpdated);
            }
        }
    }
}
