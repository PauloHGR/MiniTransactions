#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApplication/MiniTransaction.WebApi.csproj", "WebApplication/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "WebApplication/MiniTransaction.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApplication"
RUN dotnet build "MiniTransaction.WebApi.csproj" -c Release -o /app/build

#FROM build AS migrations
#RUN dotnet tool install --version 7.0.19 --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
#ENTRYPOINT dotnet-ef database update --project src/Infrastructure/ --startup-project src/WebApplication

FROM build AS publish
RUN dotnet publish "MiniTransaction.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniTransaction.WebApi.dll"]