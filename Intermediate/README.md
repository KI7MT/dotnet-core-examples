## Intermediate .NET Core Examples

## How to Run Examples

In order to run the examples, you must [Install .NET Core SDK](https://www.microsoft.com/net/learn/get-started/windows).
After that, you can clone the repository, navigate to the example folders and:

### Build / Run by issuing the following commands

* `dotnet restore`
* `make clean`
* `make pack`
* `make install`

The Run the command displayed after install.

### To Uninstall After Testing

* `make uninstall`

### Run Without Install

* `dotnet run`

## Special Notes

`RandGen` generates passwords or mixed keys for any use. To display the input-help
message, type: `randgen --help` after installing as `dotnet run` will us default
parameters.
