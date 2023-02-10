FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SN_MasterData/SocialNetwork.csproj", "SN_MasterData/"]
RUN dotnet restore "SN_MasterData/SocialNetwork.csproj"
COPY ./SN_MasterData ./SN_MasterData
WORKDIR "/src/SN_MasterData"
RUN dotnet build "SocialNetwork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SocialNetwork.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet SocialNetwork.dll