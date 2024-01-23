FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["WebApiDEMO.csproj", "./"]
RUN dotnet restore "WebApiDEMO.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebApiDEMO.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WebApiDEMO.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiDEMO.dll"]
