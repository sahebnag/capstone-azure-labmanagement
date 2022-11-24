FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Capstone.LabManagement.csproj", "."]
RUN dotnet restore "./Capstone.LabManagement.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Capstone.LabManagement.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Capstone.LabManagement.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Capstone.LabManagement.dll"]