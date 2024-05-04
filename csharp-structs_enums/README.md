# C# - Structs, Enumerations

![Project badge](https://img.shields.io/badge/C%23-Structs_Enumerations-brightgreen)


**By: Carrie Ybay**, Software Engineer at Holberton School

---

## Table of Contents
- [Resources](#resources)
- [Learning Objectives](#learning-objectives)
- [Requirements](#requirements)
- [Task List](#task-list)

---

## Resources
Read or watch:
- [Classes and Structs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/)
- [Using Structs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs)
- [Enumeration types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum)
- [.toString() method](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring?view=net-6.0)
- [How to Override the .ToString() method](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-override-the-tostring-method)
- [struct (C# Reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct)

---

## Learning Objectives
At the end of this project, you are expected to be able to explain to anyone, without the help of Google:

**General**
- What is a struct
- What is a constructor
- What is a field
- What is a property
- What is an enumeration and when to use them
- What does toString do and how to override it

---

## Requirements
**General**
- Allowed editors: Visual Studio Code
- All files will be compiled on Ubuntu 14.04 LTS using dotnet
- A README.md file, at the root of the folder of the project, is mandatory
- All default C# files named Program.cs should be renamed to the name given in each task
- Each C# task requires its own folder and .csproj file. Push all task folders to your GitHub and ensure the task names on the folders are correct
- You do not need to push your obj/ or bin/ folders
- In the following examples, the main.cs files are shown as examples. You can use them to test your functions, but you don’t have to push them to your repo (if you do we won’t take them into account). We will use our own main.cs files at compilation. Our main.cs files might be different from the one shown in the examples

---

## Task List

| Filename                      | Description                                                                                                   |
|-------------------------------|---------------------------------------------------------------------------------------------------------------|
| 0. They're good dogs          | Define a new enum `Rating` with the values `Good`, `Great`, `Excellent`.                                     |
| 1. Chief Puppy Officer        | Based on 0-dog, define a new struct `Dog` with the following members: `name`: type `public string` - `age`: type `public float` - `owner`: type `public string` - `rating`: type `public Rating`.|
| 2. A dog is the only thing... | Based on 1-dog, add a constructor to struct `Dog` that takes parameters.                                    |
| 3. A dog will teach you...    | Based on 2-dog, override the `.ToString()` method to print the `Dog` object’s attributes to stdout.           |

