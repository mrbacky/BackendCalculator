#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY CalcApi/bin/Release/net5.0/publish App/
WORKDIR /App

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_HTTPS_PORT=https://+:5001
ENTRYPOINT ["dotnet", "CalcApi.dll"]