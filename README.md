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
- Pagination

## Setup/Installation Requirements

- .NET6 or greater is required for set up.
- To establish locally, [download the repository](https://github.com/henry-oberholtzer/digital-hair-salon/archive/refs/heads/main.zip) to your computer.
- Open the folder with your terminal and run `dotnet restore` to gather necessary resources.
- In the production direction, `/HairSalon` run `$ touch appsettings.json`
- In `appsettings.json`, enter the following, replacing `USERNAME` and `PASSWORD` to match the settings of your local MySQL server.
  
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=henry_oberholtzer;uid=USERNAME;pwd=PASSWORD;"
    }
}
```
- A local instance of MySQL (8.0.0 or greater) and MySQLWorkbench (optional) is required to be set up and running to use the project, for information on installing and configuring MySQL, [please see the official documentation.](https://dev.mysql.com/doc/mysql-installation-excerpt/8.3/en/)
- If you have MySQLWorkbench installed, to add the schema, open the local database instance and navigate to the Administration tab on the left. Select 'Database Import/Restore' and the bubble 'Import from Self-Contained Filed' and navigate to the provided SQL file in the root of the project directory.
- Select 'New' under 'Default Schema to be Imported To' and then select 'Start Import'. After the import has finished, navigate back to the terminal.
- To start the projet, in the production directory, run the command `dotnet run` on your terminal.

## Known Bugs

- Grammatical errors for "1 Clients" in Stylists/Index.cshtml
- Other bugs are left as an exercise to the reader

## License

(c) 2024 [Henry Oberholtzer](https://www.henryoberholtzer.com/)

Original code licensed under the [GNU GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html#license), other code bases and libraries as stated.
