# EventManagement

Учебный проект на ASP.NET Core Web API, .NET SDK 10.0.
Позволяет создавать, просматривать, полностью обновлять и удалять мероприятия.

Данные хранятся в памяти приложения. После перезапуска все мероприятия удаляются.

## Запуск

Клонируйте репозиторий и переключитесь на ветку проектной работы:

```shell
git clone https://github.com/SerejkaP/net-practicum.git
cd net-practicum
git switch sprint-1
```

Далее команды из корня репозитория:

```shell
dotnet restore EventManagment/EventManagment.csproj
dotnet build EventManagment/EventManagment.csproj --no-restore
dotnet run --project EventManagment/EventManagment.csproj --launch-profile http
```

- Swagger UI: `http://{host}:{port}/swagger/index.html`
- Документ Swagger: `http://{host}:{port}/swagger/v1/swagger.json`

## Эндпоинты

Базовый путь — `/events`.

| Метод | Путь | Успешный ответ | Ошибки |
| --- | --- | --- | --- |
| GET | `/events` | `200 OK`, массив мероприятий | — |
| GET | `/events/{id}` | `200 OK`, мероприятие | `404`, если не найдено |
| POST | `/events` | `201 Created`, мероприятие и заголовок `Location` | `400` при некорректных данных |
| PUT | `/events/{id}` | `204 No Content` | `400` при некорректных данных; `404`, если не найдено |
| DELETE | `/events/{id}` | `204 No Content` | `404`, если не найдено |