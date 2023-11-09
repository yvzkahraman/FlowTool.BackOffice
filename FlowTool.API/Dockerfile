#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FlowTool.API/FlowTool.API.csproj", "FlowTool.API/"]
RUN dotnet restore "FlowTool.API/FlowTool.API.csproj"
COPY . .
WORKDIR "/src/FlowTool.API"
RUN dotnet build "FlowTool.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlowTool.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlowTool.API.dll"]