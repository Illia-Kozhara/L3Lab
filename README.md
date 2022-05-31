# L3Lab
### Summary:
  The project contains a web API project "L3LabDotNetCore" and a SPA view project "L3LabAngularUI". The database was used the localhost MSSQL Server.
## L3LabDotNetCore
### Summary:
  Web API with ASP.NET Core solution with data access against a MSSQL database using Entity Framework Core and Swagger API integration.
- Program.cs  Services configuration including Swagger and CORS options. CORS making requests to a different domain ("https://localhost:4200") to all method types.
- NoteController.cs CRUD provide controller class.
- AppDBContext.cs DbContext class provides access and managing DB`s data. To change path to SQL Server path, mannage "DefaultLocalHost" property in appsettings.json configuration file.
- Note.cs Entity representation class. Used to configure migration and managing to transfer data to database.
- NoteDTO.cs Data transfer class that represents Note entity. It is adopted object can be more convenient for clients or hide properties that clients are not supposed to view.
- NoteMapper Singletone Note NoteDTO mapper. Map the view model object (NoteDTO) to the domain (Note) model object, then we would manually do for each property.
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
## UI representation
### notes-component:
![image](https://user-images.githubusercontent.com/61427706/171133068-3e723eed-85af-4905-9ed6-e3bdb9b50b13.png)
 - The list of notes was received by HTTP Get().
 - A new note has been added by clicking the "Add note" button. The new note content obtained from the Note Text input component. The list of notes is automatically updated after adding a new note.
 - Note detail component was loaded when you clicked any item in the list.
### note-detail-component:
![image](https://user-images.githubusercontent.com/61427706/171133225-d06d4568-9c05-46b1-8f8f-6710e3ca524d.png)
 - The information of note was received by HTTP Get(Id). Id value component received from chosen notes list position.
 - Forms elements automatically filled from Note component that has been received.
 - “Edit” button update Note content by choosing text from “Content” Input (HTTP Update). The active state will be returned to the Notes component.
 - “Delete” button delete Note content by Id (HTTP Update(Id)). The active state will be returned to the Notes component.
### Swagger:
 ![image](https://user-images.githubusercontent.com/61427706/171130753-307b2754-29f2-439e-a34c-1d5d7c5e4425.png)
