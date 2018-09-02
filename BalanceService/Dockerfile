FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 62183
EXPOSE 44301

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY BalanceService/BalanceService.csproj BalanceService/
RUN dotnet restore BalanceService/BalanceService.csproj
COPY . .
WORKDIR /src/BalanceService
RUN dotnet build BalanceService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BalanceService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BalanceService.dll"]
