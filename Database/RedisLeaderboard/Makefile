# Makefile for Linux
# 
# Prerequsists : Microsoft Net Core SDK

PROGRAM	:=	RedisLeaderboard
VERSION	:=	1.0.0
AUTHOR	:=	Greg Beam, KI7MT
LICENSE	:=	GPLv3
BUGS	:=	https://github.com/KI7MT/dotnet-core-examples/issues
WEB	:=	https://groups.io/g/dotnet-core-examples

# application list
APPLIST	:=	LBLibrary LBService LBClient
COMMAND	:=	dotnet tool install --global --add-source

# targets
all: restore pack

clean:
	@clear ||:
	@echo '---------------------------------------------'
	@echo "Cleaning $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	@for a in ${APPLIST} ; do \
	echo "Cleaning $$a" ;\
	dotnet clean $$a --verbosity minimal ;\
	done

restore:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Restoring $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	dotnet restore
	@echo ''

pack:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Building $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	@for a in $(APPLIST) ; do \
	echo "Creating Nuget Package for $$a" ; \
	dotnet pack $$a ; \
	echo '' ; \
	done

install:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Installing $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	@for a in $(APPLIST) ; do \
	echo "Installing package: $$a" ; \
	dotnet tool install --global --add-source $$a/nupkg $$a ; \
	 echo '' ; \
	done

uninstall:
	@echo ''
	@echo '---------------------------------------------'
	@echo "Uninstalling $(PROGRAM) v$(VERSION)"
	@echo '---------------------------------------------'
	@echo ''
	@for a in $(APPLIST) ; do \
	echo "Removing package: $$a" ; \
	dotnet tool uninstall -g $$a ; \
	echo '' ; \
	done
