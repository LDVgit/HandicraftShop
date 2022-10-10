#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CatalogService/HandicraftShop.Catalog.API/HandicraftShop.Catalog.API.csproj", "CatalogService/HandicraftShop.Catalog.API/"]
RUN dotnet restore "CatalogService/HandicraftShop.Catalog.API/HandicraftShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/CatalogService/HandicraftShop.Catalog.API"
RUN dotnet build "HandicraftShop.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HandicraftShop.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HandicraftShop.Catalog.API.dll"]