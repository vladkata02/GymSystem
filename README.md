README for Angular .NET Core GymSystem

This project is a gym management system built using Angular, .NET Core, Node.js, and SQL Server. The project uses the latest version of Angular (currently 15.0.0) and has the following dependencies:

"@angular/animations": "^15.0.0"
"@angular/cdk": "^15.0.2"
"@angular/common": "^15.0.0"
"@angular/compiler": "^15.0.0"
"@angular/core": "^15.0.0"
"@angular/forms": "^15.0.0"
"@angular/material": "^15.0.2"
"@angular/platform-browser": "^15.0.0"
"@angular/platform-browser-dynamic": "^15.0.0"
"@angular/router": "^15.0.0"
"@ng-bootstrap/ng-bootstrap": "^14.0.0"
"bootstrap": "^5.2.3"
"bootstrap-icons": "^1.10.2"
"moment": "^2.29.4"
"prettier": "^2.8.1"
"rxjs": "~7.5.0"
"tslib": "^2.3.0"
"zone.js": "~0.12.0"

The project also has the following dev dependencies:

"@angular-devkit/build-angular": "^15.0.3"
"@angular/cli": "~15.0.3"
"@angular/compiler-cli": "^15.0.0"
"@types/jasmine": "~4.3.0"
"jasmine-core": "~4.5.0"
"karma": "~6.4.0"
"karma-chrome-launcher": "~3.1.0"
"karma-coverage": "~2.2.0"
"karma-jasmine": "~5.1.0"
"karma-jasmine-html-reporter": "~2.0.0"
"typescript": "~4.8.2"

Requirements

    Visual Studio 2022
    SQL Server
    Node.js
    Angular CLI (15.0.0)
    An IDE for front-end development

Setup

    Add your connection strings:
        In \GymSystem\GymSytem.DBUpdater\Program.cs line 9, in the ""
        In GymSytem.API, add the following to user secrets:

{
  "ConnectionStrings": {
    "DefaultConnectionString": "Your Connection String"
  }
}

    Open the repository in Visual Studio 2022 and start GymSystem.DBUpdater as the startup project. After the update scripts have been executed, you should have a GymSystem database in your server.
    Finally, start GymSystem.API as the startup project.
    To start the application, run npm install in the terminal. To build the
