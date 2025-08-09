# Stage base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Stage build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CRUD-Game-List/CRUD-Game-List.csproj", "CRUD-Game-List/"]
RUN dotnet restore "./CRUD-Game-List/CRUD-Game-List.csproj"
COPY . .
WORKDIR "/src/CRUD-Game-List"
RUN dotnet build "./CRUD-Game-List.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CRUD-Game-List.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage final
FROM base AS final
WORKDIR /app

# Copia a aplicação publicada
COPY --from=publish /app/publish .

# Copia o script wait-for-it.sh
COPY wait-for-it.sh /wait-for-it.sh

# Dá permissão de execução (como root)
USER root
RUN chmod +x /wait-for-it.sh
# Volta pro usuário padrão
USER app

# Aguarda o Postgres antes de rodar a API
ENTRYPOINT ["/wait-for-it.sh", "db", "5432", "--", "dotnet", "CRUD-Game-List.dll"]
