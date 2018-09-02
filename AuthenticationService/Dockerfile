FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 62183
EXPOSE 44301

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY AuthenticationService/AuthenticationService.csproj AuthenticationService/
RUN dotnet restore AuthenticationService/AuthenticationService.csproj
COPY . .
WORKDIR /src/AuthenticationService
RUN dotnet build AuthenticationService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AuthenticationService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AuthenticationService.dll"]
