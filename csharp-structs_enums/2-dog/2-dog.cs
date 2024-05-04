// Based on 1-dog, add a constructor to struct Dog that takes parameters.
using System;

struct Dog
{
    public string name;
    public float age;
    public string owner;
    public Rating rating;

    public Dog(string dogName, float dogAge, string dogOwner, Rating dogRating)
    {
        name = dogName;
        age = dogAge;
        owner = dogOwner;
        rating = dogRating;
    }
}

enum Rating { Good, Great, Excellent };
