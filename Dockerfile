FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./SettingsService.Api/SettingsService.Api.csproj ./SettingsService.Api/
COPY ./SettingsService.Application/SettingsService.Application.csproj ./SettingsService.Application/
COPY ./SettingsService.Infrastructure/SettingsService.Infrastructure.csproj ./SettingsService.Infrastructure/
COPY ./SettingsService.Domain/SettingsService.Domain.csproj ./SettingsService.Domain/

RUN dotnet restore "SettingsService.Api/SettingsService.Api.csproj"

COPY . .
WORKDIR "/src/SettingsService.Api"
RUN dotnet publish "SettingsService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080

ENTRYPOINT ["dotnet", "SettingsService.Api.dll"]