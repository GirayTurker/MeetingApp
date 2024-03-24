# Meeting APP

This is the README file for the **Meeting APP* project.

## Table of Contents

- [API Description](#api)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Launch Settings](#launch-settings)
- [Angular](#client)
- [Environment](#environment)

## API 

This project consists of two parts: a .NET web API application and an Angular front-end (Client) application. The .NET web application is built using .NET 8.0 and utilizes various packages for functionality including authentication, database design, and token management. The Angular client application is generated with Angular CLI version 17.3.1.

## Requirements

To run the .NET web application, you need to have the following:

- [.NET SDK](https://dotnet.microsoft.com/download) version 8.0 or later installed on your machine.
- [SQLite](https://www.sqlite.org/download.html) (optional, depending on your database requirements)

To run the Angular client application, you need to have the following:

- [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/) installed on your machine.

## Installation

1. Clone this repository to your local machine.
2. Ensure you have the required .NET SDK and Node.js installed.
3. Navigate to the respective project directories (`/Server` for .NET web application, `/Client` for Angular client application).
4. For the .NET web application:
   - Run `dotnet build` to build the project.
   - Run `dotnet run` to start the application.
5. For the Angular client application:
   - Run `npm install` to install dependencies.
   - Run `ng serve` for a dev server.
   - Navigate to `http://localhost:4200/`.

## Usage

Once the applications are running, you can access them through your web browser at the specified URLs. Make sure to follow any additional setup or configuration steps if mentioned in the project documentation.

## Launch Settings

Launch settings control how the .NET project is run and debugged. Below are the launch settings for the .NET project:

```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:19996",
      "sslPort": 44379
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5000;https://localhost:5001",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```



## Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.1.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Environment

VsCode 
[Download](https://code.visualstudio.com/download")

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

      
