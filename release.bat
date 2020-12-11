@echo off

dotnet build src/Skybrud.Social.GitHub --configuration Release /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=../../releases/nuget