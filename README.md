## Bocasay Exam Solution
- Frontend form fields to be 2 simple text fields e.g. first name, last name.
- Backend to receive posted data as an object and save posted object to simple file in json format. 
### About Project
Built with Clean Architecture with .NET Core 5. Includes both WebAPI and Web Blazor projects and WebAPI.UnitTest project.
### Solution Architecture Structure
![](https://i.imgur.com/rQL7zYK.png)
### Built with
-   Back-end: ASP.NET Core 5.0 WebAPI
-   Front-end: ASP.NET Core 5.0 Blazor
### Prerequisites
- Make sure you are running on the latest .NET 5 SDK (SDK 5.0 and above only).
- Visual Studio 2019 (v16.8+)
### Features Included
- CQRS with MediatR
- Fluent Validation
- UnitTest with xUnitTest and Moq
### Setup & Configurations
- Set both WebAPI and WebApp as Starup Projects 
- WebAPI: For the path folder of save posted object to simple file in json format please refer to this section of appsettings.json
``` appsettings.json
"AppConfiguration": {
    "FolderJsonPath": "Files\\Persons"
}
```

- WebApp Client: Temporary use EndPointConfig.cs to configurate the API's endpoint for web app client.
``` EndPointConfig.cs
public const string BaseAPIAddress = "https://localhost:44325";
public const string PersonEndPointPost = "/api/person";
```
