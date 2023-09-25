FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1710
EXPOSE 44310

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KamchatkaTravel.Web/KamchatkaTravel.Web.csproj", "KamchatkaTravel.Web/"]
COPY ["KamchatkaTravel.Application/KamchatkaTravel.Application.csproj", "KamchatkaTravel.Application/"]
COPY ["KamchatkaTravel.Application.Contracts/KamchatkaTravel.Application.Contracts.csproj", "KamchatkaTravel.Application.Contracts/"]
COPY ["KamchatkaTravel.Domain.Shared/KamchatkaTravel.Domain.Shared.csproj", "KamchatkaTravel.Domain.Shared/"]
COPY ["KamchatkaTravel.Identity/KamchatkaTravel.Identity.csproj", "KamchatkaTravel.Identity/"]
COPY ["KamchatkaTravel.Domain/KamchatkaTravel.Domain.csproj", "KamchatkaTravel.Domain/"]
COPY ["KamchatkaTravel.EntityFrameworkCore/KamchatkaTravel.EntityFrameworkCore.csproj", "KamchatkaTravel.EntityFrameworkCore/"]
RUN dotnet restore "KamchatkaTravel.Web/KamchatkaTravel.Web.csproj"
COPY . .
WORKDIR "/src/KamchatkaTravel.Web"
RUN dotnet build "KamchatkaTravel.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KamchatkaTravel.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KamchatkaTravel.Web.dll"]