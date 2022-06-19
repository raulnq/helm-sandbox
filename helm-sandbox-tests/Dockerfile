FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["helm-sandbox-tests/helm-sandbox-tests.csproj", "helm-sandbox-tests/"]
RUN dotnet restore "helm-sandbox-tests/helm-sandbox-tests.csproj"
COPY . .
WORKDIR "/src/helm-sandbox-tests"
ENTRYPOINT ["dotnet", "test", "helm-sandbox-tests.csproj","--no-restore"]