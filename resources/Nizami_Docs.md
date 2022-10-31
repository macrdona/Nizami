# Table of Contents

1. Project Description
2. Model View Controller(MVC)
3. Application Breakdown
    - Components
    - Controllers
    - Infrastructure
    - Models
    - Views


# Components 

<dl>
    <dd>View components are classes that provide action-style logic to support partial views, which means complex content to be embedded in views while allowing the C# code that supports it to be easily maintained.</dd>
</dl>

### Classes 

- NavigationMenuViewComponent
    <dl>
        <dd>This class manages the logic for passing a list of categories to the NavigationMenu View Component.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |NavigationMenuViewComponent|IProductRepository|void|Initializes variable **repository** with a list of all products in the database.|
    |Invoke|none|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("NavigationMenu") in the _IndexLayout.cshtml View. This method then searches for NavigationMenu/Default.cshtml in the view folder, and passes it a list of all distinct categories.|
    |||||


- CartSummaryViewComponent
    <dl>
        <dd>This class manages the logic for passing an instance of the Cart Model to the CartSummary View Component.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |CartSummaryViewComponent|Cart|void|Initializes variable **cart** with an instance of the Cart class.|
    |Invoke|none|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("CartSummary") in the _IndexLayout.cshtml View. This method then searches for CartSummary/Default.cshtml in the view folder, and passes it an instance of the Cart class.|
    |||||

## Notes
```
The runtime searches for the view in the following paths:

- /Views/{Controller Name}/Components/{View Component Name}/{View Name}
- /Views/Shared/Components/{View Component Name}/{View Name}
- /Pages/Shared/Components/{View Component Name}/{View Name}

The search path applies to projects using controllers + views and Razor Pages.

The default view name for a view component is Default, which means view files will typically be named Default.cshtml. A different view name can be specified when creating the view component result or when calling the View method.
```

# Infrastructure

<dl>
    <dd>The Infrastructure folder is where we put classes that deliver the plumbing for an application but that is not related to the application’s domain</dd>
</dl>

# Controllers

<dl>
    <dd>MVC controllers are responsible for responding to requests made against an ASP.NET MVC website.</dd>
</dl>

## Classes

- AccountController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding Accounts.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |AccountController|UserManager<'AppUser'>, SignInManager<'AppUser'>|void|Initializes variables **userManager and signInManager** with an instance of the UserManager and SignInManager classes.|
    |||||

- AdminController
- CartController
- HomeController
- OrderController