# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copy csproj and restore any dependencies (via NuGet)
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port 80 and define the entry point
EXPOSE 80
ENTRYPOINT ["dotnet", "YourApp.dll"]
