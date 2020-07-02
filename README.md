# BookStore_BrainQuest
Assesement task for BrainQuest.

## Description
A client has a book store and he requires an inventory with following categories:
  * **Author:** A mandatory category with the assumption that each book has an author. Some readers are fans of certain writers, so having the records of writers will bring on more visitors.
  * **Books:** with the records of their authors, pages, ISBN number with standard ISBN-13, and price. Release date is optional.
  * **Book Sales** has the books and the quantity they were sold in. This category requires minimum data i.e. Book ID and quantity. Date the was sold will automatically be entered by the system. 

He is also able to read, write, modify or delete any of the records.


## Technologies / Tools used
This project is built in Dotnet Core 3.1 using C# programming language and SQL Server for data stoage. Apart from it, following tools/technologies have been added too:
* **SQL Database** is used to store the data.
* **Entity Framework Core** for easy data reading and manipulation and for clean code.
* **Fluent API** for data validations
* **Swagger UI** for visual rendering of API documents
* **Serilog** for error logging.
* **AutoMapper**
* **Dependency Injection** is also being used to totally seperate the functionalities of individual CRUD operations. If a person doesnt want to have any of the CRUD operation, he can simply avoid it by omitting the respective interface.

## Installation Guide
I have tried to make the installation process as easy as possible. Please follow the below instructions:

### Database
Database schema along with a test data is saved in Bookstore.sql file. Open the file and execute it in your local system.

### WebAPI
1: Download the BookStoreAPI project.
2. Open it in Visual Studio.
3. Before building the project, open BookStoreContext.cs file in Models folder. Search "optionsBuilder.UseSqlServer" in the file. Replace the connection string with your database connection string.
4. Build the application and run it.

5. To see the error log, in case if any occures, then instead of runnig "IIS Server", run the project in "BookStoreAPI".
