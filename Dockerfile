# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
# Base image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copy and restore project
COPY ["WebapiProject/WebapiProject.csproj", "WebapiProject/"]
RUN dotnet restore "WebapiProject/WebapiProject.csproj"
# Copy everything and build
COPY . .
WORKDIR "/src/WebapiProject"
RUN dotnet build "WebapiProject.csproj" -c Release -o /app/build
RUN dotnet publish "WebapiProject.csproj" -c Release -o /app/publish
# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebapiProject.dll"]
