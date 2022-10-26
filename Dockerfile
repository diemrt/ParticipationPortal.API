FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ParticipationPortal.API/ParticipationPortal.API.csproj", "ParticipationPortal.API/"]
RUN dotnet restore "Avocado.API/Avocado.API.csproj"
COPY . .
WORKDIR "/src/Avocado.API"
RUN dotnet build "Avocado.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Avocado.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Avocado.API.dll"]
#Heroku config
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Avocado.API.dll