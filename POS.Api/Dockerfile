#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://*:8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["POS.Api/POS.Api.csproj", "POS.Api/"]
COPY ["POS.Application/POS.Application.csproj", "POS.Application/"]
COPY ["POS.Domain/POS.Domain.csproj", "POS.Domain/"]
COPY ["POS.Infrastucture/POS.Infrastucture.csproj", "POS.Infrastucture/"]
COPY ["POS.Utilities/POS.Utilities.csproj", "POS.Utilities/"]
RUN dotnet restore "./POS.Api/./POS.Api.csproj"
COPY . .
WORKDIR "/src/POS.Api"
RUN dotnet build "./POS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./POS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#USER root  # Cambiar al usuario root temporalmente
#RUN ln -fs /usr/share/zoneinfo/America/Lima /etc/localtime 
#RUN dpkg-reconfigure --frontend noninteractive tzdata
#RUN chown app:app /etc/localtime  # Cambiar de nuevo al usuario no privilegiado

#USER app  # Cambiar de nuevo al usuario no privilegiado

ENTRYPOINT ["dotnet", "POS.Api.dll"]