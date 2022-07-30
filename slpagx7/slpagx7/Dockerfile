#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["slpagx7/slpagx7.csproj", "slpagx7/"]
RUN dotnet restore "slpagx7/slpagx7.csproj"
COPY . .
WORKDIR "/src/slpagx7"
RUN dotnet build "slpagx7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "slpagx7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "slpagx7.dll"]