﻿using System;


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
        public int health;

        /// <summary>
        /// Represents the health of the zombie.
        /// </summary>
        public Zombie()
        {
            health = 0;
        }
        /// <summary>
        /// Constructor for the Zombie class.
        /// Health set to 0.
        /// </summary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new System.ArgumentException("Health must be greater than or equal to 0");
            }
            health = value;
        }
        /// <summary>
        /// Gets the health of the zombie.
        /// </summary>
        public int GetHealth()
        {
            return (health);
        }
        /// <sumary>
        /// Property
        ///</sumary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}