FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UI/SPY.Admin/SPY.Admin.csproj", "UI/SPY.Admin/"]
RUN dotnet restore "UI/SPY.Admin/SPY.Admin.csproj"
COPY . .
WORKDIR "/src/UI/SPY.Admin"
RUN dotnet build "SPY.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPY.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPY.Admin.dll"]