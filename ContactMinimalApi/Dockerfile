#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ContactMinimalApi/ContactMinimalApi.csproj", "ContactMinimalApi/"]
RUN dotnet restore "ContactMinimalApi/ContactMinimalApi.csproj"
COPY . .
WORKDIR "/src/ContactMinimalApi"
RUN dotnet build "ContactMinimalApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactMinimalApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactMinimalApi.dll"]