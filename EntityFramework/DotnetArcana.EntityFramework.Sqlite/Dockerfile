#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EntityFramework/DotnetArcana.EntityFramework.Sqlite/DotnetArcana.EntityFramework.Sqlite.csproj", "EntityFramework/DotnetArcana.EntityFramework.Sqlite/"]
RUN dotnet restore "./EntityFramework/DotnetArcana.EntityFramework.Sqlite/DotnetArcana.EntityFramework.Sqlite.csproj"
COPY . .
WORKDIR "/src/EntityFramework/DotnetArcana.EntityFramework.Sqlite"
RUN dotnet build "./DotnetArcana.EntityFramework.Sqlite.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetArcana.EntityFramework.Sqlite.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetArcana.EntityFramework.Sqlite.dll"]