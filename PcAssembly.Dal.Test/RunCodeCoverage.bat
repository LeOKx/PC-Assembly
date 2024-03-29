﻿@echo off
SET dotnet="C:/Program Files/dotnet/dotnet.exe"
SET opencover=%USERPROFILE%\.nuget\packages\OpenCover\4.7.1221\tools\OpenCover.Console.exe
SET reportgenerator=%USERPROFILE%\.nuget\packages\reportgenerator\5.1.4\tools\net6.0\ReportGenerator.exe

SET targetargs="test"
REM Important!!! If you see no result, check filter for your application namespace
SET filter="+[*]PcAssembly.* -[*.Test]* -[xunit.*]* -[FluentValidation]*"
SET coveragefile=Coverage.xml
SET coveragedir=Coverage

REM Run code coverage analysis
"%opencover%"  -register:user -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -skipautoprops -hideskipped:All -oldstyle 

REM Generate the report
"%reportgenerator%" -targetdir:%coveragedir% -reporttypes:Html;Badges -reports:%coveragefile% -verbosity:Error

REM Open the report
start "report" "%coveragedir%\index.htm"