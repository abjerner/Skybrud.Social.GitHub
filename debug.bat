@echo off
dotnet build src/Skybrud.Social.GitHub --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget