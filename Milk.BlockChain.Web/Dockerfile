#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Milk.BlockChain.Web/Milk.BlockChain.Web.csproj", "Milk.BlockChain.Web/"]
RUN dotnet restore "Milk.BlockChain.Web/Milk.BlockChain.Web.csproj"
COPY . .
WORKDIR "/src/Milk.BlockChain.Web"
RUN dotnet build "Milk.BlockChain.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Milk.BlockChain.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Milk.BlockChain.Web.dll"]