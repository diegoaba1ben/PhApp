# Usar la imagen oficial de .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usar la imagen oficial de .NET SDK para la fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Crear una capa intermedia para instalar dependencias
FROM build AS dependencies
WORKDIR /src/PhAppGateway

# Instalar dependencias adicionales
RUN apt-get update &&\
    apt-get install -y curl&&\
    rm -rf /var/lib/apt/lists*

# Copiar los archivos del proyecto y restaurar dependencias
COPY ["PhAppGateway/PhAppGateway.csproj", "PhAppGateway/"]
RUN dotnet restore "PhAppGateway/PhAppGateway.csproj"

# Copiar todo el contenido y compilar
COPY . .
WORKDIR "/src/PhAppGateway"
RUN dotnet build "PhAppGateway.csproj" -c Release -o /app/build

# Publicar el proyecto
FROM build AS publish
RUN dotnet publish "PhAppGateway.csproj" -c Release -o /app/publish

# Capa intermedia de seguridad
FROM base AS final
WORKDIR /app

#Copia solo los archivos compilados
COPY --from=publish /app/publish .

# Establece un punto de entrada
ENTRYPOINT ["dotnet", "PhAppGateway.dll"]
