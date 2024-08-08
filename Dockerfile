ARG TARGETARCH=arm64
ARG BUILDARCH=amd64

FROM --platform=linux/$TARGETARCH mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 10201

FROM --platform=linux/$BUILDARCH mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HangfireExporter/HangfireExporter.csproj", "."]
RUN dotnet restore "./HangfireExporter.csproj"
COPY ./HangfireExporter .
WORKDIR "/src/."
RUN dotnet build "./HangfireExporter.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG TARGETARCH
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HangfireExporter.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangfireExporter.dll"]