﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShowTime/ShowTime/ShowTime.csproj", "ShowTime/ShowTime/"]
COPY ["ShowTime/ShowTime.Client/ShowTime.Client.csproj", "ShowTime/ShowTime.Client/"]
RUN dotnet restore "ShowTime/ShowTime/ShowTime.csproj"
COPY . .
WORKDIR "/src/ShowTime/ShowTime"
RUN dotnet build "./ShowTime.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShowTime.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShowTime.dll"]
