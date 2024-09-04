#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MiraCohen/MiraCohen.csproj", "MiraCohen/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["DBContext/DBContext.csproj", "DBContext/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "./MiraCohen/./MiraCohen.csproj"
COPY . .
WORKDIR "/src/MiraCohen"
RUN dotnet build "./MiraCohen.csproj" -c $BUILD_CONFIGURATION -o /app/build --force

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MiraCohen.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --force

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiraCohen.dll"]