# .NET Core Examples

**Basic, Intermediate, and Advanced .NET Core Application Examples**

This repository contains examples that you can use to test out [.NET Core](http://dotnet.github.io) with.
Each section (folder) contains one or more applications that should run on any
number of operating systems. The repository serves two primary purposes:

1. A code-snippet store for my reference
2. Code examples for aspiring [dotnet-core](https://github.com/dotnet/core)
developers that want something more than just "Hello World" to play with.

All of the examples are either labs, dev-book problems, or common application
needs I've run across. While the problem source may differ, I wrote all of the solutions as presented in the repository. As time allows, more advanced topics will be added; employment of packages such as:

* [Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore)
* [Service Stack Redis](https://github.com/ServiceStack/ServiceStack.Redis)
* [Neo4J Driver](https://github.com/neo4j/neo4j-dotnet-driver)
* [Marten and PostgreSQL](https://www.nuget.org/packages/Marten/2.3.0)
* [ASP.NET Core MVC](https://github.com/aspnet/Mvc)

## Required Tools
All of the applications were written, and tested, using [VS Code](https://code.visualstudio.com/). However, virtually any quality text editor paired with Windows CMD shell / Powershell / Unix Shell will be more than adequate to
run the examples.

## Cross Platform Testing
All the example applications were tested on Window-10 Native Version 1709 Build
16299.125 or later, [Windows Subsystem Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/about), and Linux Native 
([Ubuntu Desktop 16.04 LTS)](https://www.ubuntu.com/download/desktop) installations.

## Classification

Each section (folder) has a simplistic classification (from a new developer standpoint). Professional and experienced  [OOP Developers](https://en.wikipedia.org/wiki/Object-oriented_programming) should consider the examples intro-level. New Developers, or those switching over to 
[OOP Development](https://en.wikipedia.org/wiki/Object-oriented_programming) could
think of them in terms of:

* Introductory - basic applications that any entry level programmer can grasp.
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
[.Net Core SDK](https://www.microsoft.com/net/learn/get-started/windows). Unless otherwise indicated, no reference nor application class libraries are used. As and when more advanced topics are added, this will obviously need to change and be reflected as such in the documentation.

## How to Run Examples

In order to run the examples, you must [install .NET Core](https://www.microsoft.com/net/learn/get-started/windows).
After that, you can clone the repository, navigate to the example folders and:

* Build / Run by issuing the following commands
	* `dotnet restore`
	* `dotnet run`

## Intro Example List

* [arrays](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intro.arrays) - examples of using arrays to perform calculations.

* [for-loops](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intro.for-loops) - various implementations of using for-loops to
draw shapes, perform countdowns, and determine values.

* [if-else](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intro.if-else) - several entry level if-else statement examples.

* [while-loops](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intro.while-loops) - simple high-low game, account balance, payment plan, and calculators.

## Intermediate Example List

* [Intermediate.Employee.Commission](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate.Employee.Commission) - Similar to advanced, but only uses If,
If-Else and for-loops for construction.

* [methods](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate.methods) - several simple calculators
that use methods external to the main method for computation.

* [structs](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate.structs) - simple MLS and Job listings applications that use
structs.

## Advanced Example List

* [Advanced.Employee.Commission](https://github.com/KI7MT/dotnet-core-examples/tree/master/Advanced.Employee.Commission) - Calculates one ore more Employees commission,
saves to an array of structures, then prints a summary.

* [TicTacToe](https://github.com/KI7MT/dotnet-core-examples/tree/master/Advanced.TicTacToe) - Console game Tic-Tac-Toe that uses more advanced
features such as 2D arrays, and external methods.
