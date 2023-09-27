FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OfferOasisBackend/OfferOasisBackend.csproj", "OfferOasisBackend/"]
RUN dotnet restore "OfferOasisBackend/OfferOasisBackend.csproj"
COPY . .
WORKDIR "/src/OfferOasisBackend"
RUN dotnet build "OfferOasisBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OfferOasisBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OfferOasisBackend.dll"]
