#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeAutomator/HomeAutomator.csproj", "HomeAutomator/"]
COPY ["HomeAutomator.Hue.Bridge/HomeAutomator.Hue.Bridge.csproj", "HomeAutomator.Hue.Bridge/"]
COPY ["HomeAutomator.Hue/HomeAutomator.Hue.csproj", "HomeAutomator.Hue/"]
COPY ["HomeAutomator.Web.Client/HomeAutomator.Web.Client.csproj", "HomeAutomator.Web.Client/"]
COPY ["HomeAutomator.Web.Shared/HomeAutomator.Web.Shared.csproj", "HomeAutomator.Web.Shared/"]
COPY ["HomeAutomator.NfcTags.Persistence/HomeAutomator.NfcTags.Persistence.csproj", "HomeAutomator.NfcTags.Persistence/"]
COPY ["HomeAutomator.NfcTags/HomeAutomator.NfcTags.csproj", "HomeAutomator.NfcTags/"]
COPY ["HomeAutomator.FileStorage/HomeAutomator.FileStorage.csproj", "HomeAutomator.FileStorage/"]
COPY ["HomeAutomator.Hue.Persistence/HomeAutomator.Hue.Persistence.csproj", "HomeAutomator.Hue.Persistence/"]
COPY ["HomeAutomator.Web/HomeAutomator.Web.csproj", "HomeAutomator.Web/"]
COPY ["HomeAutomator.Api/HomeAutomator.Api.csproj", "HomeAutomator.Api/"]
COPY ["HomeAutomator.Settings/HomeAutomator.Settings.csproj", "HomeAutomator.Settings/"]
COPY ["HomeAutomator.Devices/HomeAutomator.Devices.csproj", "HomeAutomator.Devices/"]
COPY ["HomeAutomator.Settings.Persistence/HomeAutomator.Settings.Persistence.csproj", "HomeAutomator.Settings.Persistence/"]
COPY ["HomeAutomator.Devices.Persistence/HomeAutomator.Devices.Persistence.csproj", "HomeAutomator.Devices.Persistence/"]
RUN dotnet restore "HomeAutomator/HomeAutomator.csproj"
COPY . .
WORKDIR "/src/HomeAutomator"
RUN dotnet build "HomeAutomator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeAutomator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeAutomator.dll"]