# Use .NET 9 SDK for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy and restore
COPY *.csproj .
RUN dotnet restore

# Copy all files and build
COPY . .
RUN dotnet publish -c Release -o out

# Runtime image using .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TransactionAggregationApi.dll"]
