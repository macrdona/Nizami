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

## Classes 

- NavigationMenuViewComponent
    <dl>
        <dd>This class manages the logic for passing a list of categories to the NavigationMenu View Component.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |NavigationMenuViewComponent|IProductRepository|Void|Initializes variable **repository** with a list of all products in the database.|
    |Invoke|None|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("NavigationMenu") in the _IndexLayout.cshtml View. This method then searches for NavigationMenu/Default.cshtml in the view folder, and passes it a list of all distinct product categories.|


- CartSummaryViewComponent
    <dl>
        <dd>This class manages the logic for passing an instance of the Cart Model to the CartSummary View Component.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |CartSummaryViewComponent|Cart|Void|Initializes variable **cart** with an instance of the Cart class.|
    |Invoke|None|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("CartSummary") in the _IndexLayout.cshtml View. This method then searches for CartSummary/Default.cshtml in the view folder, and passes it an instance of the Cart class.|
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
        <dd>This controller hanldes all the actions/requests regarding Accounts.<dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |AccountController|UserManager<'AppUser'>, SignInManager<'AppUser'>|void|Initializes variables **userManager and signInManager** with an instance of the UserManager and SignInManager classes.|
    |Login|String|ViewResult|HTTP GET method that is invoked when the Admin user goes to the URL '/Account/Login'. The method recieves the URL and it returns an instance of the LoginModel class (with ReturnUrl being initialized to the given URL) to the Login.cshtml View Model.|
    |Login|LoginModel|Task<'IActionResult'>|HTTP POST method that is invoked when the Login form is submitted. This method checks that the input provided is valid to the LoginModel, and if valid it checks whether the user exists in the database. If any of the conditions fail, an error message is returned. Else, the user is redirected to the provided URL. 
    |Logout|String|Task<'RedirectResult>|Ends current session, and returns user to the Login Page.|
    |Accounts|None|ViewResult|HTTP GET method that us invoked when user goes to the url '/Account/Accounts/. It returns a list of all existing user managers in the database to the Accounts.cshtml View.|
    |Create|None|ViewResult|HTTP GET that is invoked when user goes to the url '/Account/Create'. This method returns the Create.cshtml View.
    |Create|LoginModel|Task<'IActionResult'>|HTTP POST method that is invoked when the user submits the Sign Up form. This method checks that the input provided is valid with the LoginModel, and if valid it creates an instance of AppUser and checks if there exists an user who has the same credentials. If any of the conditions fail, an error message is returned. Else, the user is redirected to Login.cshtml page.|
    |AddErrors|IdentityResult|Void|This method adds any errors, that are found while trying to delete an user account, to the ModelState object.|
    |Delete|String|Task<'IActionResult'>|HTTP POST that is invoked when the user clicks on the Delete button in the Accounts view. It removes user whose delete button was clicked.|
    |Edit|String|Task<'IActionResult'>|HTTP GET method that allows an users to edit their account info. Need to add View that allows admins to create user accounts.|


- AdminController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding Products.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |AdminController|IProductRepository|Void|Initializes variable **repository** with a list of all products in the database.|
    |ProductList|None|ViewResult|HTTP GET method that is invoked when user goes to the url 'Admin/ProductList', and it returns a list of available products to the Admin/ProductList view.|
    |Edit|Int|ViewResult|HTTP GET method that is invoked when user clicks on the 'Edit' button next to a product. It passes the product information of the product to be edited to the Admin/Edit view.|
    |Edit|Product|IActionResult|HTTP POST method that is invoked when user submits the changes made to a product. If the changes are not validated by the model, the user is provided with an error. Else, the changes are saved in the database and user is returned to the ProductList.cshtml view.|
    |Create|None|ViewResult|HTTP GET method that is invoked when a user clicks on the 'Add Product' button. User is redirected to the Edit.cshtml view, where the Edit GET and POST methods are invoked.|
    |Delete|Int|ViewResult|HTTP POST method that is invoked when user clicks on the 'Delete' button next to a product. If product is found, the product is deleted and user is redirected to the ProductList.cshtml view.|

- CartController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding the Shopping Cart.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |CartController|IProductRepository,Cart|Void|Initializes variables **repository** with a list of all available products in the repository and **cart** with a list of all products currently in the shopping cart.|
    |Cart|String|ViewResult|HTTP GET method that is invoked when the user goes to the URL '/Cart/Cart'. The method recieves the URL and it returns an instance of the CartIndexViewModel class (with ReturnUrl being initialized to the given URL) to the Cart View Model.|
    |AddToCart|Int,String|RedirectResult|HTTP POST method that is invoked when a user clicks on the 'Add Item' button. This method checks if item exists in the database, and if it does it add/updates the item to the cart. It redirects the user to the page defined in returnUrl string.|
    |RemoveFromCart|Int,String|RedirectToActionResult|HTTP POST method that is invoked when the user clicks on the 'Remove' button next to an item in the cart. This method checks if item exists in the database, and if it does it removes the item from the cart. It redirects the user to the page defined in returnUrl string.|

- HomeController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding the Home page.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |Index|String|Page|HTTP GET method which is invoked when the application is launched or when the user is directed to '/Home/Index' url. This method returns to the Index View, a list of products based on provided filters, if any, and returns information for how many pages there should be to display all products.|

- OrderController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding the Orders.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |OrderController|IOrderRepository,Cart|Void|Initializes variables **repository** with a list of all available orders in the repository and **cart** with a list of all products currently in the shopping cart.|
    |List|None|ViewResult|HTTP GET methods which is invoked when the user is directed to the '/Order/List/' url. Returns a list of all orders that have not been shipped to the List View.|
    |MarkShipped|Int|IActionResult|HTTP POST method which is invoked when the user clicks on the 'Ship' button. This method checks that the order exists and if it does, it marks the order to shipped. Redirects user back to the List View.|
    |Checkout|None|ViewResult|HTTP GET method that is invoked when the user clicks ont thec 'Checkout' button on the shopping cart. Return an instance of the Order object to the Checkout View.|
    |Checkout|Orders|IActionResult|HTTP POST method which is invoked when user submits order. Checks if the cart is empty, it so then it send an error to the user. It also checks if order submitted is validated by the Model, if so the orders is processed and user is redirected to Completed View.|
    |Completed|None|ViewResult|HTTP GET method which is invoked when directed to 'Order/Completed' url. This method clears shopping cart and then returns Completed View.|
    
# Views

<dl>
	<dd>MVC views are responsible for displaying content to the user.</dd>
<dl>

## Razor Views / CSHTML Files 

|File Name|Descritpion|
|------------|------------|
|Cart| Displays the name, price, and quantity of the items the user has added to the cart with a remove button for each item. Users can also either got to the checkout page or continuing shopping when pressing either button.|
|Index| Displays the home page with a navbar located at the top that has a search bar, sign up or login option, the shopping cart, and the NIZAMI LOGO. Also displays all product options in the center with an add to cart feature for each product and a filter option located to the left. Displays buttons at the page button at the bottom to move to another page and another navbar for the Home,Features, Pricing, FAQS, and About pages.|
|Privacy| Display the privacy policy for NIZAMI.|
|Checkout| Displays the checkout page check out page where users can enter their name, adress and choose to have the item gift wrapped. Users can the click the complete order button to finish the order.|
|Completed| Displays that the order has been completed.|
|Default(CartSummary)| Specifically displays the cart button and total for the Cart page.|
|Default(NavigationMenu)| Specifically Displays the category button with a dropdown menu on the Index page.|
|_CartLayout|Renders the body section of the Cart|
|_IndexLayout| Renders the body section of the Index/Home page.|
|_ValidationScriptsPartial|scripts for validating user input for the login,signup, and checkout pages.|
|Error| Displays Error when something has gone wrong with loading the page.|
|ProductSummary| Generates the list of products to be displayed in Index/ Home page.|
|_ViewImports| Makes directives available for all files within the View folder.|
|_ViewStart| Will either make the layout (_IndexLayout) for the index page or the cart layout (_CartLayout) for the cart page as the default.|
