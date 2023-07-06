#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

RUN adduser -u 5679 --disabled-password --gecos "" amorphie-mocksuser && chown -R amorphie-mocksuser:amorphie-mocksuser /app
USER amorphie-mocksuser


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["./amorphie.mocks/amorphie.mocks.csproj", "."]
RUN dotnet restore "./amorphie.mocks.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./amorphie.mocks/amorphie.mocks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./amorphie.mocks/amorphie.mocks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "amorphie.mocks.dll"]
