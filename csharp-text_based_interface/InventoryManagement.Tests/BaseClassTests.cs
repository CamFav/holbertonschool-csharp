using System;
using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class BaseClassTests
    {
        [Fact]
        public void BaseClass_ShouldHaveDefaultValues()
        {
            // Arrange
            var baseObject = new BaseClass();

            // Assert
            Assert.False(string.IsNullOrEmpty(baseObject.Id)); // Check if Id is not null or empty
            Assert.NotEqual(DateTime.MinValue, baseObject.DateCreated); // Check if DateCreated is set to a value other than the default DateTime
            Assert.NotEqual(DateTime.MinValue, baseObject.DateUpdated); // Check if DateUpdated is set to a value other than the default DateTime
        }
    }
}
