FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["helm-sandbox-app/helm-sandbox-app.csproj", "helm-sandbox-app/"]
RUN dotnet restore "helm-sandbox-app/helm-sandbox-app.csproj"
COPY . .
WORKDIR "/src/helm-sandbox-app"
RUN dotnet build "helm-sandbox-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "helm-sandbox-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "helm-sandbox-app.dll"]