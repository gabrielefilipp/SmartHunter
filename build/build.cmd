@echo off

dotnet build ..\ -c release

REM publish command for self contained .exe
REM dotnet publish ..\ -r win-x64 -c release
