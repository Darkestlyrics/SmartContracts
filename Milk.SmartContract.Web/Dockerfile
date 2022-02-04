#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Milk.SmartContract.Web/Milk.SmartContract.Web.csproj", "Milk.SmartContract.Web/"]
RUN dotnet restore "Milk.SmartContract.Web/Milk.SmartContract.Web.csproj"
COPY . .
WORKDIR "/src/Milk.SmartContract.Web"
RUN dotnet build "Milk.SmartContract.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Milk.SmartContract.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Milk.SmartContract.Web.dll"]