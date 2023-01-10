FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /build

# Copy everything
COPY . ./
# Restore as distinct layers then build and publish a release
RUN dotnet restore && dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /build/out .
ENTRYPOINT ["dotnet", "CloudflareDDNS.dll"]
