// Based on 0-dog, define a new struct Dog with the following members:
// - name, type: public string
// - age, type: public float
// - owner, type: public string
// - rating, type public Rating
using System;

struct Dog
{
    public string name;
    public float age;
    public string owner;
    public Rating rating;
}

enum Rating { Good, Great, Excellent };
