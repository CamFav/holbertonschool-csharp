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
    }
}
