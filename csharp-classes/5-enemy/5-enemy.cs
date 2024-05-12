using System;

namespace Enemies
{
    /// <summary>
    /// Represents a zombie enemy.
    /// </summary>
    public class Zombie
    {
        /// <summary>
        /// Represents the health of the zombie.
        /// </summary>
        private int health;
        private string name = "(No name)";

        /// <summary>
        /// Constructor for the Zombie class.
        /// Health set to 0.
        /// </summary>
        public Zombie()
        {
            health = 0;
        }

        public Zombie(int value)
        {
            if (value < 0)
                throw new ArgumentException("Health must be greater than or equal to 0");
            health = value;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int GetHealth()
        {
            return health;
        }

        /// <summary>
        /// String representation of the Zombie object.
        /// </summary>
        /// <returns>A string representing the zombie.</returns>
        public override string ToString()
        {
            return $"Zombie Name: {name} / Total Health: {health}";
        }
    }
}