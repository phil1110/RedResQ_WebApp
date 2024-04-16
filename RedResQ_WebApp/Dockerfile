#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RedResQ_WebApp/RedResQ_WebApp.csproj", "RedResQ_WebApp/"]
COPY ["RedResQ_WebApp.Lib/RedResQ_WebApp.Lib.csproj", "RedResQ_WebApp.Lib/"]
RUN dotnet restore "./RedResQ_WebApp/RedResQ_WebApp.csproj"
COPY . .
WORKDIR "/src/RedResQ_WebApp"
RUN dotnet build "./RedResQ_WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RedResQ_WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedResQ_WebApp.dll"]