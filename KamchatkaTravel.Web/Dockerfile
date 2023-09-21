FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base #базовый образ, который установится в контейнере, нужен для запуска ASP.NET Core -приложения
WORKDIR /app #Эта строка устанавливает рабочий каталог внутри контейнера на /app. Все последующие команды будут выполняться в этом каталоге.
EXPOSE 1710  #Эта строка объявляет порт 1710, на котором будет доступно приложение внутри контейнера. Однако она не открывает этот порт для внешнего доступа.
EXPOSE 44310 #внутри контейнера будут знаты порты 1710 и 44310
#Результат этапа: контейнер с ASP.NET Core окружением и объявленными портами

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build #Здесь начинается новый этап сборки, обозначенный как "build". Используется образ sdk для .NET 7.0 от Microsoft, который предоставляет инструменты для сборки .NET приложений.
WORKDIR /src #Устанавливает рабочий каталог для этапа "build" в /src
COPY ["KamchatkaTravel.Web/KamchatkaTravel.Web.csproj", "KamchatkaTravel.Web/"] #Копирует файл проекта KamchatkaTravel.Web.csproj внутрь контейнера в каталог KamchatkaTravel.Web/.
RUN dotnet restore "KamchatkaTravel.Web/KamchatkaTravel.Web.csproj" #Выполняет команду dotnet restore для восстановления зависимостей проекта.
COPY . . #Копирует все файлы из текущего каталога (где находится Dockerfile) внутрь контейнера.
WORKDIR "/src/KamchatkaTravel.Web" #Устанавливает рабочий каталог для этапа "build" внутри контейнера на /src/KamchatkaTravel.Web.
RUN dotnet build "KamchatkaTravel.Web.csproj" -c Release -o /app/build #Выполняет сборку проекта с конфигурацией "Release" и выводит результаты сборки в /app/build внутри контейнера.
#Результат этапа: скомпилированный код и зависимости

FROM build AS publish #Здесь начинается новый этап, который базируется на этапе "build". Этап называется "publish".
RUN dotnet publish "KamchatkaTravel.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false #Выполняет публикацию приложения с использованием конфигурации "Release" и выводит результаты публикации в /app/publish внутри контейнера. Флаг /p:UseAppHost=false указывает не использовать AppHost (для self-contained развертывания).
#Результат этапа: выполняет публикацию приложения в режиме "Release", создает оптимизированные и готовые для развертывания файлы приложения

FROM base AS final #Завершающий этап, базирующийся на базовом этапе "base".
WORKDIR /app #Устанавливает рабочий каталог для этапа "final" в /app.
COPY --from=publish /app/publish . #Копирует результаты публикации из этапа "publish" в текущий рабочий каталог /app внутри контейнера.
ENTRYPOINT ["dotnet", "KamchatkaTravel.Web.dll"] #Устанавливает точку входа для контейнера. При запуске контейнера будет выполнена команда dotnet KamchatkaTravel.Web.dll, что запустит .NET приложение, представленное файлом KamchatkaTravel.Web.dll.
#Результат этапа: устанавливает точку входа для контейнера, создает окончательный образ контейнера, который содержит готовое для выполнения ASP.NET Core приложение