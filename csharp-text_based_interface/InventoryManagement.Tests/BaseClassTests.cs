using System;

namespace InventoryLibrary
{
    public abstract class BaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier for the class.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date when the class instance was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date when the class instance was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
