FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WEB/WEB.csproj", "WEB/"]
COPY ["App.Application/App.Application.csproj", "App.Application/"]
COPY ["App.Infrastructure/App.Infrastructure.csproj", "App.Infrastructure/"]
COPY ["App.Domain/App.Domain.csproj", "App.Domain/"]
COPY ["App.Shared/App.Shared.csproj", "App.Shared/"]
RUN dotnet restore "WEB/WEB.csproj"
COPY . .
WORKDIR "/src/WEB"
RUN dotnet build "WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WEB.dll"]