# Start with the base .NET Core 6 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file(s)
COPY *.csproj .

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build 

# Publish the application
RUN dotnet publish 

# Create a new image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "powerplant-coding-challenge-implementation.dll"]