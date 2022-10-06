FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OurChat/OurChat.csproj", "OurChat/"]
RUN dotnet restore "OurChat/OurChat.csproj"
COPY . .
WORKDIR "/src/OurChat"
RUN dotnet build "OurChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OurChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OurChat.dll"]
