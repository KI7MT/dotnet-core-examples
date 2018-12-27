# Makefile for Linux
#
# Prerequsists : Microsoft Net Core SDK

PROGRAM	:=	EmployeeCommissionV2
VERSION	:=	1.0.0
AUTHOR	:=	Greg Beam, KI7MT
LICENSE	:=	GPLv3
BUGS	:=	https://github.com/KI7MT/jtsdk-dotnet-core/issues
WEB	:=	https://groups.io/g/JTSDK

# application list
COMMAND	:=	dotnet tool install --global --add-source

# targets
all: restore pack

clean:
	@clear ||:
	@echo '---------------------------------------------'
	@echo "Cleaning $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	dotnet clean --verbosity normal
	@echo ''

restore:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Restoring $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	dotnet restore
	@echo ''

pack:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Packaging $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	dotnet pack
	@echo ''

install:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Installing $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	$(COMMAND) ./nupkg ${PROGRAM}
	@echo

uninstall:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Uninstalling $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	dotnet tool uninstall -g ${PROGRAM}
	@echo ''
