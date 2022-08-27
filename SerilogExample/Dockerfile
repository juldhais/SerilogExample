FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SerilogExample/SerilogExample.csproj", "SerilogExample/"]
RUN dotnet restore "SerilogExample/SerilogExample.csproj"
COPY . .
WORKDIR "/src/SerilogExample"
RUN dotnet build "SerilogExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerilogExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerilogExample.dll"]
