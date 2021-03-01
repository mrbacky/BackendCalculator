#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CalcApi/CalcApi.csproj", "CalcApi/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore --disable-parallel "CalcApi/CalcApi.csproj"
COPY . .
WORKDIR "/src/CalcApi"
RUN dotnet build "CalcApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalcApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalcApi.dll"]