#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

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