FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Docker_demo/Docker_demo.csproj", "Docker_demo/"]
RUN dotnet restore "Docker_demo/Docker_demo.csproj"
COPY . .
WORKDIR "/src/Docker_demo"
RUN dotnet build "Docker_demo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Docker_demo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Docker_demo.dll"]
