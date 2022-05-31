# L3Lab
### Summary:
  The project contains a web API project "L3LabDotNetCore" and a SPA view project "L3LabAngularUI". The database was used the localhost MSSQL Server.
## L3LabDotNetCore
### Summary:
  Web API with ASP.NET Core solution with data access against a MSSQL database using Entity Framework Core and Swagger API integration.
- Program.cs  Services configuration including Swagger and CORS options.
- NoteController.cs CRUD provide controller class.
- AppDBContext.cs DbContext class provides access and managing DB`s data.
- Note.cs Entity representation class.
- NoteDTO.cs Data transfer class that represents Note entity.
- NoteMapper Singletone Note NoteDTO mapper.
## L3LabAngularUI
### Summary:
  Angular project SPA UI representation.
- notes.component.ts/(html) Angular component that represent List of Notes which received from web Api, and **new Note** creation functional.
- note-detail.component.ts/(html) Angular component that represent **edit** and **delete** Note functional.
- messages.component.ts/(html) Angular component that represent basic log message.
- note.service.ts Servise that provide CRUD reqests to webApi.
- message.service.ts Servise that provide basic log messaging.
- note-dto.ts Data transfer class that represents Note entity.
- app-routing.module.ts Handle the navigation between **notes.component** and **note-detail.component**.
