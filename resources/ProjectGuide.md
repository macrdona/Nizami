# **ASP.NET MVC** 

Model View Controller(MVC) is a design patter which is used to separate the **User Interface(View)**, the **Data(Model)**, and the **Application Logic(Controller)**. 

- With MVC requests are routed to a Controller that is responsible for working with the Model to perform actions and/or retrieve data.
- After doing some logic, the Controller chooses to return a View to display and provides it with the Model. 
- The View renders the final page, based on the data in the Model.

**Models & Data**

- You are able to create Model Classes and bind them to a database. Data binding is **the process that couples two data sources together and synchronizes them**. With data binding, a change to an element in a data set automatically updates in the bound data set.

- Code Sample

  ```c#
  public class Person
  {
      public int PersonId { get; set; }
  
      [Required]
      [MinLength(2)]
      public string Name { get; set; }
  
      [Phone]
      public string PhoneNumber { get; set; }
  
      [EmailAddress]
      public string Email { get; set; }
  }
  ```

- Validation Attributes
  - [Required] and [MinLength(2)]
  - Validation attributes let you specify validation rules for model properties.

**Controllers**

- Creating a controller allows you to route requests to controller actions. Data from the request path, query string, and request body are automatically bound to method parameters. 
- Code Sample

```c#
public class PeopleController : Controller
{
    private readonly AddressBookContext _context;

    public PeopleController(AddressBookContext context)
    {
        _context = context;
    }

    // GET: /people
    public async Task Index()
    {
        return View(await _context.People.ToListAsync());
    }

    // GET: /people/details/5
    public async Task Details(int id)
    {
        var person = await _context.People.Find(id);

        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }
}
```

- Example 
  - If a page has a button to get user details and when pressed it makes a request for the user's details. If that request is binded to the Details function, then the Details function is invoked and the user's id is automatically assigned to variable id.

**Creating an MVC Web Application (Visual Studio)**

- https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0&tabs=visual-studio
- https://ibjects.medium.com/learning-asp-net-core-3-1-mvc-from-scratch-b6f3a5cc45b4
- https://www.c-sharpcorner.com/article/creating-user-registration-form-in-asp-net-core-mvc-web-application/

# **Git and GitHub**

To download Git, go to this page https://git-scm.com/download/win

Once downloaded you can search on the windows search bar: "Git Bash" and it will open up a command line. Git Bash works with Linux commands, if you need some sort of reference I recommend looking at this sheet: https://www.guru99.com/linux-commands-cheat-sheet.html

Git, which is a system for managing repositories, also has its own special commands. Here is a sheet with commonly used commands: https://education.github.com/git-cheat-sheet-education.pdf. The commands you will care for the most part are: add, status, commit, clone, branch, and rm. I recommend watching a video on Git to learn how to use it appropriately. Here is one: https://www.youtube.com/watch?v=SWYqp7iY_Tc&t=1s

Here is the workflow for using Git: https://www.codecademy.com/learn/learn-git/modules/learn-git-git-teamwork-u. This is very important for avoiding errors, and this is something we will need to eventually learn when we start working in an industry setting. Let us do our best following this workflow. 

Now GitHub. It is essentially the same thing. GitHub is a user interface addition to Git which allows us to store our files on a remote repository. You may think of a repository as a folder containing all other files and folders. GitHub also allows us to collaborate, as we can share files with each other by uploading them to GitHub and then downloading them individually on each of our computers. 

# **Learning Resources**

**W3Schools**

Link to W3Schools: https://www.w3schools.com/

This website is pretty good for any looking at syntax from many popular programming languages. We will mainly be focusing on HTML, CSS, C#, and ASP.NET(or ASP)

**Microsoft Learn**

Link to Microsoft Learn: https://docs.microsoft.com/en-us/learn/?source=learn

This page has many resources and tutorials on many topics, so it is pretty useful. Microsoft created .NET and C# so they will definitely have a lot of information on both. 

**web.dev**

Link: https://web.dev/

I believe this will aid us in the development of our project. This page contains some articles and examples on how to make our website better in terms of functionality and design. 

**Codeply**

Link: https://www.codeply.com/

This website is useful for practicing HTML, CSS, JS and Bootstrap. You are able to use existing templates or create new ones and test the code in an online environment.

# **Databases** 

**SQL Express Database**

Install SQL Server using this link: https://go.microsoft.com/fwlink/?LinkID=866658

Install Microsoft SQL Server Management: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Connect c# program to database and query database: https://learn.microsoft.com/en-us/azure/azure-sql/database/connect-query-dotnet-core?view=azuresql

```
Setup Database 
1. Download SQL Server
	- Save a copy of your connection string, instance name, sql admin
	- to run server in command line: sqlcmd -S DESKTOP-BH62ETS\SQLEXPRESS -E
2. Download Microsoft SQL Server Management
	- Login as admin 
	- Setup Database
	- Setup Login(Under Security>Login)
		- Assign Database to Login
	- Setup User (Under Databases>Nizami>Security>Users)

To solve error: A connection was successfully established with the server, but then an error occurred during the pre-login handshake. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.) (Microsoft SQL Server, Error: 233)
Solution: Server (Right Click) -> Properties -> Security -> Server Authentication -> SQL Server and Windows Authentication Mode.
				
				
```

# **Data Generator**

Link: https://www.mockaroo.com/

- Product Table settings
  - ProductID(Number)
  - Name(Product(Grocery))
  - Descriptions(Paragraphs)
  - Price(Number)
  - Category(Department(Retail))
  - Image(Dummy Image URL)


# **Extra Resources**

Bootstrap Cheat-Sheet: https://bootstrap-cheatsheet.themeselection.com/, https://mdbootstrap.com/docs/standard/forms/search/

Frontend: https://www.developerdrive.com/18-learning-resources-for-front-end-developers/

A little bit of everything: https://dev.to/aycanogut/front-end-resources-1jk2#css-websites

ASP.NET Tutorial : https://docs.microsoft.com/en-us/learn/paths/aspnet-core-web-app/

.NET tutorial: https://docs.microsoft.com/en-us/learn/paths/build-dotnet-applications-csharp/

ASP.NET MVC: https://dotnet.microsoft.com/en-us/apps/aspnet/mvc

Fake Store API: fakestoreapi.com

Create a database in Visual Studio: https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16,
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-6.0&tabs=visual-studio#sql-server-express-localdb

