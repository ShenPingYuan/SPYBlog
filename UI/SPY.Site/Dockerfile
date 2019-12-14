FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UI/SPY.Site/SPY.Site.csproj", "UI/SPY.Site/"]
RUN dotnet restore "UI/SPY.Site/SPY.Site.csproj"
COPY . .
WORKDIR "/src/UI/SPY.Site"
RUN dotnet build "SPY.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPY.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPY.Site.dll"]