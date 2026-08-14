# AssignmentService

AssignmentService är en microservice för att hantera uppgifter i LMS-projektet.

Tjänsten är byggd med ASP.NET Core Web API och använder Entity Framework Core för datalagring.

## Funktioner

- Hämta alla uppgifter
- Hämta en specifik uppgift
- Hämta uppgifter för en viss kurs
- Skapa uppgift
- Uppdatera uppgift
- Ta bort uppgift
- Swagger/OpenAPI-dokumentation

## Teknik

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swagger / OpenAPI

## Databas

Lokalt används SQL Server LocalDB.

Databasnamn:

`LmsAssignmentDb`

AssignmentService ansvarar själv för sin data.

`CourseId` lagras som ett vanligt ID och det finns ingen direkt databasrelation till CourseService.

## API

Viktiga endpoints:

- `GET /api/Assignments`
- `GET /api/Assignments/{id}`
- `GET /api/Assignments/course/{courseId}`
- `POST /api/Assignments`
- `PUT /api/Assignments/{id}`
- `DELETE /api/Assignments/{id}`

GET-endpoints är öppna för läsning.

POST, PUT och DELETE skyddas med API-nyckel via headern:

`X-API-Key`

API-nyckeln lagras lokalt med User Secrets och ska inte sparas i repositoryt.

## Swagger

När tjänsten körs lokalt finns Swagger på:

`http://localhost:5122/swagger`

## Köra projektet lokalt

1. Klona repositoryt.
2. Öppna projektet i Visual Studio.
3. Kontrollera connection string i `appsettings.json`.
4. Lägg till API-nyckeln med User Secrets.
5. Kör databasmigrationerna vid behov:

`Update-Database`

6. Starta projektet.

AssignmentService kör lokalt på:

`http://localhost:5122`

## Frontend

Next.js-frontenden kör lokalt på:

`http://localhost:3000`

CORS är konfigurerat så att frontenden kan hämta uppgiftsdata från AssignmentService.