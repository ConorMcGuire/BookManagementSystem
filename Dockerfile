FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["BookManagementSystem.csproj", "./"]
RUN dotnet restore "BookManagementSystem.csproj"

COPY . .
RUN dotnet build "BookManagementSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookManagementSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookManagementSystem.dll"]
