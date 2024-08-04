using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class UserTests
    {
        [Fact]
        public void User_ShouldInheritFromBaseClass()
        {
            var user = new User();
            Assert.IsAssignableFrom<BaseClass>(user);
        }

        [Fact]
        public void User_ShouldHaveNameProperty()
        {
            var user = new User
            {
                Name = "Test User"
            };

            Assert.Equal("Test User", user.Name);
        }
    }
}
