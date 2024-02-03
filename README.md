# Digital Hair Salon

A web application for tracking stylists and their clients, built with C# and Razor Pages, using the MVC structur and a MySQL database, with the EFCore framework.

By Henry Oberholtzer

## Technologies Used

- C#
- MySQL
- EFCore
- Razor Pages

## User Stories
- User should be able to see a list of all stylists
- User should be able to see the details about a stylist and all the clients that belong to them.
- User should be able to add more stylists to the system when necessary
- When adding clients, they should only be possible to add when stylists have been created in the system, and must be assigned to a specific stylist.

## Technical requirements
- Two or more controllers are used
- Successful usage of GET and POST routes
- MVC routes follow RESTful conventions

## Stretch Goal Features
- Styling
- Stylists and clients are sortable by Date Added, Name, or # of clients / visits
- Server side data validation
- Pagination

## Setup/Installation Requirements

- .NET6 or greater is required for set up.
- To establish locally, [download the repository](https://github.com/henry-oberholtzer/digital-hair-salon/archive/refs/heads/main.zip) to your computer.
- Open the folder with your terminal and run `dotnet restore` to gather necessary resources.
- To run the application, within the solution folder, run the command `dotnet run` after the restore.
- A local instance of MySQL is required to be set up and running to use the project.
- You will need to estalish a copy of the database on your own machine, by importing the `henry_oberholtzer.sql` scheme into your server.
- In the production direction, `/ProjectName` run `$ touch appsettings.json`
- In `appsettings.json`, enter the following, replacing `USERNAME` and `PASSWORD` to match the settings of your local MySQL server.
  
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=henry_oberholtzer;uid=USERNAME;pwd=PASSWORD;"
    }
}
```

- To start the projet, in the production directory, run the command `dotnet run`.

## Known Bugs

- Grammatical errors for "1 Clients" in Stylists/Index.cshtml
- Other bugs are left as an exercise to the reader

## License

(c) 2024 [Henry Oberholtzer](https://www.henryoberholtzer.com/)

Original code licensed under the [GNU GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html#license), other code bases and libraries as stated.
