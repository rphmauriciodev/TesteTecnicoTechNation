#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TesteTecnicoTechNation.WebUI/TesteTecnicoTechNation.WebUI.csproj", "TesteTecnicoTechNation.WebUI/"]
COPY ["TesteTecnicoTechNation.Infra.IoC/TesteTecnicoTechNation.Infra.IoC.csproj", "TesteTecnicoTechNation.Infra.IoC/"]
COPY ["TesteTecnicoTechNation.Application/TesteTecnicoTechNation.Application.csproj", "TesteTecnicoTechNation.Application/"]
COPY ["TesteTecnicoTechNation.Domain/TesteTecnicoTechNation.Domain.csproj", "TesteTecnicoTechNation.Domain/"]
COPY ["TesteTecnicoTechNation.Infra.Data/TesteTecnicoTechNation.Infra.Data.csproj", "TesteTecnicoTechNation.Infra.Data/"]
RUN dotnet restore "./TesteTecnicoTechNation.WebUI/TesteTecnicoTechNation.WebUI.csproj"
COPY . .
WORKDIR "/src/TesteTecnicoTechNation.WebUI"
RUN dotnet build "./TesteTecnicoTechNation.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TesteTecnicoTechNation.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteTecnicoTechNation.WebUI.dll"]