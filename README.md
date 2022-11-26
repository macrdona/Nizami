# **Nizami**

## **Git Collaboration Workflow**

What is git fetch vs pull?
Git Fetch is the command that tells the local repository that there are changes available in the remote repository without bringing the changes into the local repository. Git Pull on the other hand brings the copy of the remote directory changes into the local repository.

A common Git collaboration workflow is:

    1. Fetch and merge changes from the remote. (You can also run 'git pull' which git pull = git fetch + git merge) 
    2. Create a branch to work on a new project feature
    3. Develop the feature on a branch and commit the work
    4. Fetch and merge from the remote again (in case new commits were made)(You can also run 'git pull' which git pull = git fetch + git merge) 
    5. Push branch up to the remote for review

Steps 1 and 4 are a safeguard against merge conflicts, which occur when two branches contain file changes that cannot be merged with the git merge command.

After pulling the files from the Git repository make sure:
    1. That the datbase connection string is correct.
    2. If there are any updates to the database queries, run the queries to keep the database up-to-date.

## **Project Description**

The purpose of this project is to create an e-commerce website using the .NET Framework, which follows the Model-View-Controller(MVC) architecture. NOTE: This project was created for a college course, and it is not meant to be used for commercial purposes. 

Nizami is an e-commerce website where users can browse through various products and apply filters to search for specific products. Users can create accounts, use a shopping cart to keep track of the products they want, and submit orders to be shipped to customers. This project was built following the model-view-controller architecture. It involves handling http requests, routing url values, and modifying data from a database, etc... Application of security to prevent users from accessing certain pages without authentication and authorization.

## **Frameworks/Software**

This is a list of the various software and languages used to create the website.

- .NET (Version 3.1), C#
- HTML5, CSS, JavaScript, Bootstrap (Version 5.1)
- Visual Studio 2022, Microsoft SQL Server Management Studio 18, SQL Server 2019
- Git & GitHub

## **Project Setup**

1. Download & Install 
    - Visual Studio 2022(https://visualstudio.microsoft.com/vs/)
    - SQL Server(https://go.microsoft.com/fwlink/?LinkID=866658)
            - Save a copy of your connection string, instance name, sql admin
            - to run server in command line: sqlcmd -S [Server Name] -E
    - SQl Management Studio(https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)[OPTIONAL]
        - Login with SQL Server Admin User
        - Setup Database
        - Setup SQL Server User(Under Security>Login)
            - Assign Database to SQL Server User
        - Setup Database User (Under Databases>[Database Name]>Security>Users)

2. Connect SQL Server to Visual Studio[Optional but suggested]
    - Go to Tools > Connect To Database... Fill out the information and Test Connection.

3. Edit connection string 
    - Open the appsettings.json file, and change the connection string with your own. 

4. Create Tables
    - Go to Tools>NuGet Package Manager>Package Manager Console
    - Run the following commands:
        - EntityFrameworkCore\Add-Migration Identity
            - Entity Framework Core can generate the schema for the database using the model classes through a feature called migrations. Entity Framework will try to idenify any models which the Database might be dependant on, and will add them to the migrations. 
	    - EntityFrameworkCore\Update-Database

5. Run Queries
    - NOTE: Since you are setting up a local database server, you will need to run the queries to populate your database with products to be displayed. 
    - Execute queries on Products_Query file
    - Execute the following query. You are creating a default order with this query.
        ```
        insert into Orders(OrderID,Shipped,Name,Line1,Line2,Line3,City,State,Zip,Country,GiftWrap) values(0,1,'','','','','','',0,'',0)
        ```

6. Create Test Users
    - Create two users through the applications interface(Create Account Form). 
    - In the database change one of the users' UserID to 1. This will make the user an admin user and allow them access to admin pages. 
    
