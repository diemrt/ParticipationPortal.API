FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ParticipationPortal.API/ParticipationPortal.API.csproj", "ParticipationPortal.API/"]
RUN dotnet restore "ParticipationPortal.API/ParticipationPortal.API.csproj"
COPY . .
WORKDIR "/src/ParticipationPortal.API"
RUN dotnet build "ParticipationPortal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParticipationPortal.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParticipationPortal.API.dll"]