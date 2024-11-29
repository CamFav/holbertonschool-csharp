using System;


namespace InventoryLibrary
{
    /// <summary>
    /// Represents a base class for entities with an identifier and timestamp information.
    /// </summary>
    public abstract class BaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClass"/> class with a new identifier and current timestamps.
        /// </summary>
        public BaseClass()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = default(DateTime);
            DateUpdated = DateTime.Now;
        }
    }
}
