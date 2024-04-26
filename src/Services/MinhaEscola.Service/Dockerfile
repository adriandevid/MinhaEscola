FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY ./ .

RUN cd src/MinhaEscola.Service.Web && dotnet restore MinhaEscola.Service.Web.csproj && dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "./MinhaEscola.Service.Web.dll"]