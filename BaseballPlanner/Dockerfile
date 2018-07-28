FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY BaseballPlanner/ClubGrid.csproj BaseballPlanner/
COPY ClubGrid.Interface/ClubGrid.Interface.csproj ClubGrid.Interface/
RUN dotnet restore BaseballPlanner/ClubGrid.csproj
COPY . .
WORKDIR /src/BaseballPlanner
RUN dotnet build ClubGrid.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ClubGrid.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClubGrid.dll"]
