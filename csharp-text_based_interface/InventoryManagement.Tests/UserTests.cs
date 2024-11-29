using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            var user = new User("John Doe", "john.doe@example.com");

            Assert.AreEqual("John Doe", user.Name);
            Assert.AreEqual("john.doe@example.com", user.Email);
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new User(null!, "email@example.com"));
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenEmailIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new User("John Doe", null!));
        }

        [Test]
        public void Constructor_ThrowsArgumentException_WhenEmailIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new User("John Doe", "invalid-email"));
        }

        [Test]
        public void Constructor_ThrowsArgumentException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new User(string.Empty, "email@example.com"));
        }

        [Test]
        public void User_Equality_SameProperties_AreEqual()
        {
            var user1 = new User("Jane Doe", "jane.doe@example.com");
            var user2 = new User("Jane Doe", "jane.doe@example.com");

            Assert.AreEqual(user1, user2);
        }

        [Test]
        public void User_Equality_DifferentProperties_AreNotEqual()
        {
            var user1 = new User("Jane Doe", "jane.doe@example.com");
            var user2 = new User("John Doe", "john.doe@example.com");

            Assert.AreNotEqual(user1, user2);
        }

        // Removed invalid update tests; properties are read-only
    }
}
