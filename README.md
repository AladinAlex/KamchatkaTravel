# KamchatkaTravel
Решение содержит 2 основных проекта: KamchatkaTravel.Web и KamchatkaTravel.WebDashboard

KamchatkaTravel.Web - это веб-приложение для продажи туров на Камчатку. На данный момент это небольшой сайт, в котором реализован динамический вывод туров, отзывов и часто задаваемых вопросов, а также создание заявок.
В данном проекте мною был написал бек и фронт(razor), а верстку мне сделали, так как я знаю (на тот момнент знал) только основы html, css.
  В планах:
* Перенести реализацию работы с БД с Microsoft SQL на Postgres.
* Реализовать работу с MongoDB для хранения там изображений.
* Дописать unit-тесты.
    4. Продолжать развивать данный проект, путем добавления корзины, личного кабинета, промокодов и тп, попробовать использовать в проекте такие технологии как redis, rabbitMq как минимум.
    5. CI/CD.
    

KamchatkaTravel.WebDashboard - это веб-приложение, админ панель, с помощью которой можно управлять контентом веб-приложения "KamchatkaTravel.Web".
Реализовано управление турами, заявками клиентов, расписанием клиентов: их можно создавать, изменять и скрывать туры. Весь проект я сделал сам.
В планах сделать 1 view для создания и измения одинаковых сущностей, разные были сделаны для ускорения процесса, копипастом.

Оба приложения запущены на хостинге:
KamchatkaTravel.Web: https://landintheocean.ru/
KamchatkaTravel.WebDashboard: https://admin.landintheocean.ru/ (Для просмотра работоспособности можно использовать логин: "guest" и пароль: "guest1")
Так как приложения запущены на хостинге, а в appsettings.json хранится строка подключения к базе, файл appsettings.json был добавлен в .gitignore.

Для каждого приложения писал Dockerfile и запускал их. Также есть Docker Compose для запуска сразу 2-x контейнеров.
