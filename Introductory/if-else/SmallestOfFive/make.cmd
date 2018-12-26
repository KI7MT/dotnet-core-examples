::-----------------------------------------------------------------------------::
:: Name .........: make.cmd
:: Project ......: dotnet-core-examples : SmallestOfFive
:: Description ..: Make file to manage SmallestOfFive Globally
:: Project URL ..: https://github.com/ki7mt/dotnet-core-examples
::
:: Author .......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
:: Copyright ....: Copyright (C) 2018 Greg Beam, KI7MT
:: License ......: GPL-3
::
:: make.cmd is free software: you can redistribute it and/or modify it
:: under the terms of the GNU General Public License as published by the Free
:: Software Foundation either version 3 of the License, or (at your option) any
:: later version. 
::
:: make.cmd is distributed in the hope that it will be useful, but WITHOUT
:: ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
:: FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
:: details.
::
:: You should have received a copy of the GNU General Public License
:: along with this program.  If not, see <http://www.gnu.org/licenses/>.
::-----------------------------------------------------------------------------::
@ECHO OFF

:: Applicaiton Name
set app_name=SmallestOfFive
set app_ver=1.0.0

:: Get Command line Options %1
IF /I [%1]==[clean] ( GOTO _CLEAN )
IF /I [%1]==[pack] ( GOTO _PACK )
IF /I [%1]==[install] ( GOTO _INSTALL )
IF /I [%1]==[uninstall] ( GOTO _UNINSTALL )
IF /I [%1]==[help] ( GOTO _HELP )
GOTO HELP

:: Clean the source tree
:_CLEAN
CLS
ECHO ----------------------------------------
ECHO  Clean Solution %app_name%
ECHO ----------------------------------------
ECHO.
dotnet clean --configuration Release --verbosity normal
GOTO EOF

:: Run dotnet Pack to build Nuget package
:_PACK
CLS
ECHO ----------------------------------------
ECHO  Packaging %app_name%
ECHO ----------------------------------------
ECHO.
ECHO Creating Package: %app_name%
dotnet pack --configuration Release --force --verbosity minimal
ECHO.
ECHO Finished
GOTO EOF

:: Install RandGen to the --global dotnet applicaiton directory
:_INSTALL
CLS
ECHO ----------------------------------------
ECHO  Installing %app_name%
ECHO ----------------------------------------
ECHO.
ECHO Installing Package: %app_name%
dotnet tool install --global --add-source ./nupkg %app_name%
ECHO.
ECHO Finished
GOTO EOF

:: Uninstall RandGen from the --global dotnet applicaiton directory
:_UNINSTALL
CLS
ECHO --------------------------------------------
ECHO  Installing %app_name%
ECHO --------------------------------------------
ECHO.
dotnet tool uninstall -g %app_name%
ECHO.

:: Finished installation
ECHO   Finished
GOTO EOF

:: ----------------------------------------------------------------------------
::  HELP MESSAGE
:: ----------------------------------------------------------------------------
:_HELP
CLS
ECHO ----------------------------------------
ECHO  %app_name% Make Help
ECHO ----------------------------------------
ECHO.
ECHO  The build script takes one option^:
ECHO.
ECHO    clean      :  clean the build tree
ECHO    pack       :  build source tree
ECHO    install    :  install the application
ECHO    uninstall  :  uninstall the application
ECHO.
ECHO    Example: 
ECHO      make clean
ECHO      make pack
ECHO      make install
ECHO.
GOTO EOF

:EOF
EXIT /b 0
