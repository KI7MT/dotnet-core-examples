# .NET Core Examples

**Basic, Intermediate, and Advanced Single File .NET Core Application Examples**

This directory contains examples that you can use to test out [.NET Core](http://dotnet.github.io) with.
Each section contains one or more applications. As time allows, more advanced topics will be added; employment of packages such as:

* [Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore)
* [Service Stack Redis](https://github.com/ServiceStack/ServiceStack.Redis)
* [Neo4J Driver](https://github.com/neo4j/neo4j-dotnet-driver)
* [Marten and PostgreSQL](https://www.nuget.org/packages/Marten/2.3.0)

Each application can be described as follows:

* **Introductory** - basic applications that any entry level programmer can grasp.
* **Intermediate** - employs things such as structures, and methods from outside
of the main method.
* **Advanced** - are applications that use a combination of both Introduction and
Intermediate. They may also use instance classes, interfaces, extend classes, 
or more advanced [Object Oriented Programming (OOP)](https://en.wikipedia.org/wiki/Object-oriented_programming)
techniques.

The code for each application is Verbose, meaning, shortcuts and advanced
concatenations have been kept to a minimum to allow for easier readability.
Code comments are also brief, but should suffice for most readers.

The majority of the programs are a single file (Program.cs), easy to use,
and can be compiled on any operating system capable of running the 
[.Net Core SDK](http://dotnet.github.io/getting-started/). Unless otherwise
indicated, no references nor application class libraries are used. As and when
more advanced topics are added, this will obviously need to change change and be
reflected as such in the documentation.

## How to Run Examples

In order to run the examples, you must [install .NET Core](http://dotnet.github.io/getting-started/).
After that, you can clone the repository, navigate to the example folders and:

* Build / Run by issuing the following commands
	* `dotnet restore`
	* `dotnet run`

## Example List

* **Advanced.Employee.Commission** - Calculates one ore more Employees commission,
saves to an array of structures, then prints a summary.
* **Advanced.TicTacToe** - Console game Tic-Tac-Toe that uses more advanced
features such as 2D arrays, and external methods.
* **Intermediate.Employee.Commission** - Similar to advanced, but only uses If,
If-Else and for-loops for construction.
* **Intermediate.methods** - several simple calculators
that use methods external to the main method for computation.
* **Intermediate.structs** - simple MLS and Job listings applications that use
structs.
* **Intro.arrays** - examples of using arrays to perform calculations.
* **Intro.for-loops** - various implementations of using for-loops to
draw shapes, perform countdowns, and determine values.
* **Intro.if-else** - several entry level if-else statement examples.
* **Inteo.while-loops** - simple high-low game, account balance, payment plan, and calculators.

