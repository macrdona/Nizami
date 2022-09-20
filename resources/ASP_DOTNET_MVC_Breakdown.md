**ASP.NET MVC** 

Model View Controller(MVC) is a design patter which is used to separate the **User Interface(View)**, the **Data(Model)**, and the **Application Logic(Controller)**. 

- With MVC requests are routed to a Controller that is responsible for working with the Model to perform actions and/or retrieve data.
- After doing some logic, the Controller chooses to return a View to display and provides it with the Model. 
- The View renders the final page, based on the data in the Model.

****

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

**Creating a Web Application (Visual Studio)**

- https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0&tabs=visual-studio

