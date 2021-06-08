FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Auction/Auction.csproj", "Auction/"]
RUN dotnet restore "Auction/Auction.csproj"
COPY . .
WORKDIR "/src/Auction"
RUN dotnet build "Auction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auction.dll"]
