FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Students.Api.dll"]