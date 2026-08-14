# AssignmentService

AssignmentService är den del av LMS-projektet som sköter uppgifter.

Projektet är byggt med ASP.NET Core Web API och använder Entity Framework Core för att spara data.

## Funktioner

* Visa alla uppgifter
* Visa en specifik uppgift
* Visa uppgifter för en viss kurs
* Skapa en uppgift
* Ändra en uppgift
* Ta bort en uppgift

## Teknik

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server LocalDB
* Swagger

## Databas

Lokalt används databasen:

`LmsAssignmentDb`

Varje uppgift har ett `CourseId` som visar vilken kurs den hör till.

## API

De viktigaste endpointsen är:

* `GET /api/Assignments`
* `GET /api/Assignments/{id}`
* `GET /api/Assignments/course/{courseId}`
* `POST /api/Assignments`
* `PUT /api/Assignments/{id}`
* `DELETE /api/Assignments/{id}`

GET-anropen är öppna.

POST, PUT och DELETE skyddas med en API-nyckel.

API-nyckeln sparas med User Secrets och ligger inte i GitHub.

## Swagger

Swagger finns lokalt på:

`http://localhost:5122/swagger`

## Starta projektet

1. Öppna projektet i Visual Studio.
2. Kontrollera att databasen är skapad.
3. Lägg in API-nyckeln i User Secrets.
4. Starta AssignmentService.

Tjänsten kör lokalt på:

`http://localhost:5122`

Next.js-frontenden kör på:

`http://localhost:3000`
