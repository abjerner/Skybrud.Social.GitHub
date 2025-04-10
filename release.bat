@echo off

dotnet build src/Skybrud.Social.GitHub --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget