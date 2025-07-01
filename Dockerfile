FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY ProyectAntivirusBackend.sln ./
COPY ProyectAntivirusBackend/*.csproj ProyectAntivirusBackend/
RUN dotnet restore ProyectAntivirusBackend/ProyectAntivirusBackend.csproj

COPY ProyectAntivirusBackend/ ProyectAntivirusBackend/
WORKDIR /app/ProyectAntivirusBackend
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /out .

EXPOSE 8080
EXPOSE 443

ENTRYPOINT ["dotnet", "ProyectAntivirusBackend.dll"]
