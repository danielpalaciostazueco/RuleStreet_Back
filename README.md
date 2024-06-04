# Readme

## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

## Setup database
Connect to database and run manually the script of init-db.sql
(PRO OPTIONs:
- https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database)
- https://www.softwaredeveloper.blog/initialize-mssql-in-docker-container

## Save database
docker commit & docker push

## Migraciones: 
dotnet ef migrations add InitialCreate -p ./Data/RuleStreet.Data.csproj -s ./Api/RuleStreet.Api.csproj 
dotnet ef database update -p ./Data/RuleStreet.Data.csproj -s ./Api/RuleStreet.Api.csproj
dotnet ef database drop -p ./Data/RuleStreet.Data.csproj -s ./Api/RuleStreet.Api.csproj

## Instalar
dotnet tool install --global dotnet-ef --version 7.0

## Drop Tables 
DROP TABLE Ciudadano;
DROP TABLE Policia;
DROP TABLE Multa;
DROP TABLE CodigoPenal;
DROP TABLE Vehiculo;
DROP TABLE Auditoria;
DROP TABLE Permiso;
DROP TABLE Rango;
DROP TABLE RangoPermiso;
DROP TABLE Denuncia;
DROP TABLE Nota;
DROP TABLE Usuario;
DROP TABLE Ayuntamiento;
DROP TABLE Evento;
