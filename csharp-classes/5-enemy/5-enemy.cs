﻿using System;


namespace Enemies
{
    /// <summary>public class Zombie that defines a zombie</summary>
    public class Zombie
    {
        /// <summary>
        /// Health of the zombie
        /// </summary>
        private int health;
        private string name = "(No name)";

        /// <summary>
        ///Zombie health
        /// </summary>
        public Zombie()
        {
            health = 0;
        }
        /// <sumary>
        ///public constructor
        ///</sumary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new System.ArgumentException("Health must be greater than or equal to 0");
            }
            health = value;
        }
        /// <sumary>
        ///public method
        ///</sumary>
        public int GetHealth()
        {
            return (health);
        }
        /// <sumary>
        ///public property
        ///</sumary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <sumary>
        ///public method
        ///</sumary>

        public override string ToString()
        {
            return string.Format("Zombie Name: {0} / Total Health: {1}", name, health);
        }
    }
}