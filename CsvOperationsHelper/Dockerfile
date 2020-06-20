FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY . CsvOperationsHelper/
WORKDIR /CsvOperationsHelper
RUN dotnet restore CsvOperationsHelper.sln

FROM build AS publish
WORKDIR /CsvOperationsHelper/
RUN dotnet publish CsvOperationsHelper.sln -c Debug -o /app

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
COPY . CsvOperationsHelper/
WORKDIR /app
EXPOSE 8003

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "CsvOperationsHelper.dll"]
