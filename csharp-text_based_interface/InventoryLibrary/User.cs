using System;

namespace InventoryLibrary
{
    public class User : BaseClass
    {
        public string Name { get; }
        public string Email { get; }

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email address.", nameof(email));

            Name = name;
            Email = email;
        }

        public override bool Equals(object obj)
{
    if (obj is Inventory other)
    {
        return Id == other.Id &&
               UserId == other.UserId &&
               ItemId == other.ItemId &&
               Quantity == other.Quantity &&
               DateCreated == other.DateCreated &&
               DateUpdated == other.DateUpdated;
    }
    return false;
}


        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email);
        }
    }
}
