FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore CsvOperationsHelper.sln
RUN dotnet publish CsvOperationsHelper.sln -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CsvOperationsHelper.dll"]