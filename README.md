# .NET Core Examples

- [Overview](#overview)
- [Usability](#usability)
- [System Requirements](#system-requirements)
- [Installation Using Makefiles](#installation-using-makefiles)
- [Introductory Logic, Conditions, Loops](#introductory-logic-conditions-loops)
- [Intermediate Structures, Methods and Functions](#intermediate-structures-methods-and-functions)
- [Advanced Structures, Methods, and Classes](#advanced-structures-methods-and-classes)
- [Redis Leaderboard Stable For Testing Purposes](#redis-leaderboard-stable-for-testing-purposes)
- [WSL Neo4J Stable For Testing Purposes](#wsl-neo4j-stable-for-testing-purposes) 

## Overview

The [dotnet-core-examples](https://github.com/KI7MT/dotnet-core-examples) repository contains samples that you can use to test various aspects of
[NET Core | ASP Net Core](http://dotnet.github.io). Each section `(folder)`
contains one or more applications that should run on any number of operating
systems, each having their own `Makefile` to facilitate: `clean`, `pack`,
`install` and `uninstall`. Most applications can run with a simple command: `dotnet run`. All the samples have been tested as [.Net Global Tools](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools).

The code for each application is Verbose, meaning, shortcuts and advanced
concatenations have been kept to a minimum to allow for easier readability.
Code comments are also brief, but should suffice for most readers.

The majority of the programs are a single file `(Program.cs)`, easy to use,
and can be compiled on any operating system capable of running
[.Net Core SDK](https://www.microsoft.com/net/learn/get-started/windows).

All of the examples are layed out in sections `(Folder Hierarchy)`.
While the `Database, WebMVC, and WebAPI` sections are not listed as [Advanced](#advanced),
the examples represent many challenging aspects of [OOP](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming) including `Dependency Injection`, `Models`, `Controllers`, `Views`, and `Database
Integration`.

## Usability

At the time of this writing, all example applications were tested on:

* Oracle Linux 7 an 8
* Windows 11 Pro 23H2 22631.3007
* [Windows Subsystem Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/about)
* Linux Native [Ubuntu 22.04](http://releases.ubuntu.com/22.04/)
* If the [.Net Core SDK](#system-requirments) can run on a particular system, so should the examples.

## System Requirements

* Supported Operating Systems: `Windows`, `Linux`, `MacOS`
* [Net Core SDK v8.0](https://dotnet.microsoft.com/download)
* [VS Code Editor](https://code.visualstudio.com/) is optional but preferred
* Dual Core CPU Minimum
* At Least 1GB RAM
* 1 to 2 GB of Free disk space (if running all apps, less if not)

>NOTE: All tools in this repository have been updated with `Makefiles` that
support installing each application as a [.Net Global Tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools).
This allows for global access to the application from anywhere within the user
space. File install locations are as follows:

```shell
# Windows
C:\Users\%username%\.dotnet\tools

# Linux | MacOS
/home/$USER/.dotnet/tools
```

## Installation Using Makefiles

Each application has its own `Makefile` with the commands to build, install,
uninstall and run the application except where noted. For Windows, the file name is
`make.cmd`. For Linux, the file name is `Makefile` without extension. In both
cases, the invocation command is the same: `make <target>`.

```shell
# Install: In the directory you want to test, type the following:

# Windows
.\make.cmd clean
.\make.cmd pack
.\make.cmd install

# Linux | MacOSX
make
make install

# After install, type the name of the package you installed to execute it.
# Example: To start LBService, type:

LBService

# Upon successful installation, the appropriate application name will be
# displayed with instructions to run it.


# Uninstall: Windows
.\make.cmd uninstall
.\make.cmd clean

# Uninstall: Linux MacOS
make uninstall
make clean
```


## Introductory Logic, Conditions, Loops

`Basic Functions` employ things such as [Arrays](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/),
[for-loops](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for),
[while-loops](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while),
and [if-else](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else)
statements. All functions are contained within the standard `(Program.cs)`
file. Typically, no other classes are involved apart basic from
[using statements](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement).

| Application |Type|Description
| :---        |:---|:---
|[ComputeArray](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/arrays)|Array|Compute average using an array.
|[SimpleArray](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/arrays)|Array|Sum 10 entries from user
|[TargetValue](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/arrays)|Array|Find target value in array
|[DoubleTriangle](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Print a diamond using loops
|[RightTriangle](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Print Right-Triangle using loops
|[RocketLaunch](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Simple count-down counter
|[SingleTree](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Prints a tree using loops
|[StackDifferent](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Stack Different Numbers Across
|[StackSame](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/for-loops)|for-loop|Stack Same Numbers Across
|[BasicMath](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Sum, Difference, Quotient, Product, and Average
|[CorrectChange](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Use Modulus to calculate correct change
|[EndsWell](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine the suffix, for a given integer (1-100)
|[EndsWellExtend](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine the suffix, for a given integer (1-1000)
|[FeetToYards](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|User Input feet => convert to yards
|[GradeDetermination](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine letter grade from three input values
|[LeaguesToNm](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|User Input Leagues => convert to Nautical Miles
|[MiddleValue](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine the middle value of three integers
|[MilesPerTank](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Calculate Miles per Tank of Fuel
|[NetPayCalc](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Calculate Net Pay by taking out fixed tax rates
|[PerfectFit](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine various apsects of Squares and Rectangles
|[PositiveDifference](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine the Absolute Value (Positive Difference)
|[SaintIves](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Simple compounding math statements
|[SmallestOfFive](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/if-else)|if-else|Determine the smallest of five numbers
|[AccountBalancer](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|While loop Account Balancer
|[AverageNumbers](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Average a series of Even and Odd numbers
|[Cubed](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|calculate cubed values
|[Happy](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|While (true) loop
|[HighLowRedux](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Simple High-Low Game
|[IncrementBy](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Loop that increments by x
|[LargestNumber](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Loop entry, print largest number
|[PaymentPlan](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Loop payment plan comparison, no user input
|[PowerOff](https://github.com/KI7MT/dotnet-core-examples/tree/master/Introductory/while-loops)|while-loops|Loop that calculates powers of 10 for x < <= 10


## Intermediate Structures, Methods and Functions

`Intermediate` employs things such as [structures](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/struct),
and [methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)
outside of the [main method](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/hello-world-your-first-program)
or `(Program.cs`) file.

| Application |Type|Description
| :---        |:---|:---
|[AreaOfCircle](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/methods)|methods|Use methods to calc the Area of a Circle
|[AreaOfTriangle](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/methods)|methods|Use methods to calc the Area of a Triangle
|[CalculatePay](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/methods)|methods|Use methods to calculate Gross Pay
|[InchesToCentimeters](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/methods)|methods|Use methods to Convert In. to Cn.
|[VolumeOfCylinder](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/methods)|methods|Use methods to calc the Volume of a Cylinder
|[JobListing](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/struct)|struct|Use struct to generate job postings
|[MSLListing](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate/struct)|struct|Use struct to add to listings array and MLS IDs
|[RandGen](https://github.com/KI7MT/dotnet-core-examples/tree/master/Intermediate)|struct|Advanced Password generator with user input options

## Advanced Structures Methods and Classes

`Advanced` applications are a combination of both [Basic](#introductory-logic-conditions-loops)
and [Intermediate](#intermediate-structures-methods-and-functions) functions. They may also use instantiation
of classes, interfaces, abstracts, or more advanced
[Object Oriented Programming (OOP)](https://en.wikipedia.org/wiki/Object-oriented_programming)
techniques.

| Application |Type|Description
| :---        |:---|:---
|[EmployeeCommissionV1](https://github.com/KI7MT/dotnet-core-examples/tree/master/Advanced) |various |Calculate commission for one or more employee's
|[EmployeeCommissionV2](https://github.com/KI7MT/dotnet-core-examples/tree/master/Advanced) |various |Uses: Struct, Array of Struct, if-else, loops and methods
|[TikTakToe](https://github.com/KI7MT/dotnet-core-examples/tree/master/Advanced)|various|Game: uses 2D Arrays, if-else, loops, methods, and colors

## Redis Leaderboard Stable For Testing Purposes

This application is functional for it's intended purpose, e.g. `Testing`. However, it should not be considered production worthy.

| Application |Database |DB Setup|Status|Description
| :---        |:---|:---|:---    |:---
|[RedisLeaderboard](https://github.com/KI7MT/dotnet-core-examples/tree/master/Database)|Redis|[See Docs](https://github.com/KI7MT/jtsdk-dotnet-core/wiki/Install-Redis)|Stable|Ham Radio Contest Leaderboard Example


## WSL Neo4J Stable For Testing Purposes

This application is functional for it's intended purpose, e.g. `Testing`. However, none should not be considered production worthy.

|Application  |Database |DB Setup|Status|Description
| :---        |:---|:---|:---    |:---
|[WslNeo4J](https://github.com/KI7MT/dotnet-core-examples/tree/master/Database)|Neo4J|TDB|Devel|Movie DB queries using Console App and Neo4j
