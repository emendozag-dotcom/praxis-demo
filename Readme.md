## Net Core Praxis App

- ##### Database setup
  
- Create user and set rights over ATWebApi database.
  
    ```sql
    USE master;
  
  create login ATUser with password = 'ATD3v3l0p3r';
    go
    
    create user  ATUser for LOGIN ATUser;
    GO
    
    USE master;
    
    DENY VIEW ANY DATABASE TO ATUser;
    
    USE master;
    GO
    ALTER AUTHORIZATION ON DATABASE::ATWebApi TO ATUser;
    
    use ATWebApi;
    grant select on DATABASE::ATWebApi to ATUser;
    grant update on DATABASE::ATWebApi to ATUser;
    grant delete on DATABASE::ATWebApi to ATUser;
    grant take ownership on DATABASE::ATWebApi to ATUser;
    grant control on DATABASE::ATWebApi to ATUser;
    ```
    

- ##### DotNet Project

  - Add project with a specific framework

    ```bash
    dotnet new <TEMPLATE> -f <FRAMEWORK> -n <OUTPUT_NAME>
    dotnet new classlib -f netcoreapp3.1 -n AT.IModel
    ```

  - Add nuget package

    ```bash
    dotnet add package <PACKAGE_NAME> -v <VERSION>
    dotnet add package Newtonsoft.Json -v 12.0.1
    ```

  - Add references

    ```bash
    dotnet add reference ..\AT.DataAccess\
    ```

- ##### DotNet Solution

  - List the projects in a solution
    - `dotnet sln todo.sln list`
  - Add a C# project to a solution: 
    - `dotnet sln add todo-app/todo-app.csproj`
  - Remove a C# project from a solution
    - `dotnet sln remove todo-app/todo-app.csproj`
  - Add multiple C# projects to the root of a solution
    - `dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj --in-root`
  - Add multiple C# projects to a solution
    - `dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj`
  - Remove multiple C# projects from a solution
    - `dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj`

- ##### DotNet Entity Framework

  - Install EF Tools globally

    ```bash
    dotnet tool install --global dotnet-ef
    ```

  - Update EF Tools globally

    ```bash
    dotnet tool update --global dotnet-ef
    ```

  - EF Packages - [Choose your DB provider...](https://docs.microsoft.com/en-us/ef/core/providers/)

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```

  - EF Commands

    ```bash
    dotnet ef migrations add InitialDatabaseSetup -p ..\AT.DataAccess\AT.DataAccess.csproj
    dotnet ef database update
    ```

  - Add Migration

    ```bash
    dotnet ef migrations add <MigrationName>
    ```

  - Update target database

    ```bash
    dotnet ef database update
    ```

  - Remove last Migration

    ```bash
    dotnet ef migrations remove
    dotnet ef migrations remove --project ..\AT.DataAccess\
    ```

  - Generate SQL script from Migrations

    ```bash
    dotnet ef migrations script
    ```

  - Reversing A Migration

    ```bash
    dotnet ef database update <MigrationName>
    ```

- ##### DotNet - Test

  - Run the tests in the project in the current directory
    - `dotnet test`
  - Run the tests in the `test1` project
    - `dotnet test ~/projects/test1/test1.csproj`
  - Run the tests in the project in the current directory, and generate a test results file in the trx format
    - `dotnet test --logger trx` 
  - Run the tests in the project in the current directory, and log with detailed verbosity to the console
    - `dotnet test --logger "console;verbosity=detailed"` 
  - Run the tests in the project in the current directory, and report tests that were in progress when the test host crashed
    - `dotnet test --blame	` 

