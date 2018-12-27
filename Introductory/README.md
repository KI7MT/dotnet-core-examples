# Introductory .NET Core Examples

## Installation Using Makefiles

Each application has its own `Makefile` with the commands to build, install,
uninstall and run the application except where noted. For Windows, the file name is
`make.cmd`. For Linux, the file name is `Makefile` without extension. In both
cases, the invocation command is the same: `make <target>`.

```shell
# Install: In the directory you want to test, type the following:

# Windows
make clean
make pack
make install

# Linux | MacOSX
make
make install

# After install, type the name of the package you installed to execute it.
# Example: To start LBService, type:

LBService

# Upon successful installation, the appropriate application name will be
# displayed with instructions to run it.


# Uninstall: Windows, Linux and MacOS
make uninstall
```

## Run Without Install

* `dotnet run`