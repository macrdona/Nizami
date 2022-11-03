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
    |NavigationMenuViewComponent|IProductRepository **repo**|Void|Initializes global variable **repository** with an instance of IProductRepository, which is a repository for all the products in the database.|
    |Invoke|None|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("NavigationMenu") in the **_IndexLayout** View. This method calls the **Default** view and initializes the model with a list of all distinct product categories.|


- CartSummaryViewComponent
    <dl>
        <dd>This class manages the logic for passing an instance of the Cart Model to the CartSummary View Component.</dd>
    </dl>

    |Method|Parameters|Return|Description|
    |-----------|-----------|-----------|-----------|
    |CartSummaryViewComponent|Cart **cartService**|Void|Initializes global variable **cart** with an instance of the Cart class.|
    |Invoke|None|IViewComponentResult|This method is invoked by @await Component.InvokeAsync("CartSummary") in the **_IndexLayout** View. This method calls the **Default** view and initializes the model with an instance of the Cart class.|

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

<dl>
    <dt>NOTE</dt>
    <dd>The column Parameter Modification especifies the location where the Parameter(s) of a function are being assigned/modified when they are invoked. You can search for these modifications by going to the especified file, hit Ctrl+f, and search for the given code.</dd>
</dl>

## Classes

- AccountController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding Accounts.<dd>
    </dl>

    |Method|Parameters|Return|Method Type|Description|Parameter Modification|
    |-----------|-----------|-----------|-----------|-----------|-----------|
    |AccountController|UserManager<'AppUser'> **userMgr**, SignInManager<'AppUser'> **signInMgr**|void|Constructor|Initializes variables **userManager and signInManager** with an instance of the UserManager and SignInManager classes. These two instances manage user Login requests.|None|
    |AdminLogin|String **returnUrl**|ViewResult|HTTP GET|This method is invoked when the admin user clicks on the 'Admin Login' button in the AdminLogin page. When the method is invoked a URL is passed to the parameter **returnUrl**. This method then calls the AdminLogin view and it initializes the model to an instance of the LoginModel class (with ReturnUrl being initialized to **returnUrl***).|**File:** Index View => **Code:** AccountMod1|
    |AdminLogin|LoginModel **loginModel**|Task<'IActionResult'>|HTTP POST| This method is invoked when the login form is submitted. This method checks that the input provided is valid with the LoginModel, and if valid it checks whether the user exists in the database. It also checks if their userId is equal to 1, which is only assigned to admins. If any of the conditions fail, an error message is returned. Else, the user is redirected to the provided URL.|None|
    |Logout|String **returnUrl**|Task<'RedirectResult>|None|Ends current session, and returns user to the Index View page.|None|
    |Accounts|None|ViewResult|HTTP GET|This method is invoked when Admin users clicks on View Users button in the Admin page(NEED TO ADD BUTTON AND ADMIN VIEW IN ADMIN FOLDER). This method calls the Accounts View and initializes the model to a list of all existing users in the AspNetUsers table.|None|
    |AddErrors|IdentityResult|Void|None|This method adds any errors, that are found while trying to delete an user account, to the ModelState object.|None|
    |Delete|String **id**|Task<'IActionResult'>|HTTP POST| This method is invoked when the admin clicks on a user's Delete button in the Accounts view. It removes user whose delete button was clicked.|**File:** Account View => **Code:** AccountMod2|
    |Edit|String **id**|Task<'IActionResult'>|HTTP GET|This method is invoked when admin clicks on a user's Edit button in the Accounts view. This method allows an admin to edit an user's account info.|**File:** Account View => **Code:** AccountMod3|
    |UserSignUp|String **returnUrl**|View Result|HTTP GET|This method is invoked when a user clicks on the Sign Up button in the Index view. When the method is invoked a URL is passed to the parameter **returnUrl**. This method then calls the UserSignUp view and it initializes the model to an instance of the LoginModel class (with ReturnUrl being initialized to **returnUrl**).|**File:** Index View => **Code:** AccountMod4|
    |UserSignUp|LoginModel **model**|Task<'IActionResult'>|HTTP POST|This method is invoked when the user submits the sign up form. This method checks in the user input is valid with the model. If is not valid, the user is given an error. Else, it creates the user's account with the provided input and assigns the user with a userId 0 to represent a standard user(not an admin) and it redirects the user to the PostLogin view.|None|
    |UserLogin|String **returnUrl**|View Result|HTTP GET|This method is invoked when a user clicks on the Login button in the Index view. When the method is invoked a URL is passed to the parameter **returnUrl**. This method then calls the UserLogin view and it initializes the model to an instance of the LoginModel class (with ReturnUrl being initialized to **returnUrl**).|**File:** Index View => **Code:** AccountMod5|
    |UserSignUp|LoginModel **model**|Task<'IActionResult'>|HTTP POST|This method is invoked when the user submits the login form. This method checks that user exists and that their userid is 0(non-admin user), if the conditions result to true then the user is allowed to log in and is redirected to the PostLogin view. Else, user is given an error.|None|


- AdminController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding Products.</dd>
    </dl>

    |Method|Parameters|Return|Method Type|Description|Parameter Modification|
    |-----------|-----------|-----------|-----------|-----------|-----------|
    |AdminController|IProductRepository **repo**|Void|None|Initializes global variable **repository** with a list of all products in the database.|None|
    |ProductList|None|ViewResult|HTTP GET|This method is invoked when admin user logs in through AdminLogin page. This method calls the ProductList view, and it intializes the model with a list of available products to the.|None|
    |Edit|Int **productId**|ViewResult|HTTP GET|This method that is invoked when user clicks on the 'Edit' button next to a product. This method calls the Edit view and it initializes the model with the information of the procut to be edited.|None|
    |Edit|Product **product**|IActionResult|HTTP POST|This method is invoked when user submits the changes made to a product. If the changes are not validated by the model, the user is provided with an error. Else, the changes are saved in the Product table and the admin is redirected to the ProductList view.|**File:** ProductList View => **Code:** AdminMod1|
    |Create|None|ViewResult|HTTP GET| This method is invoked when a user clicks on the 'Add Product' button. User is redirected to the Edit view, where the Edit GET and POST methods are invoked.|None|
    |Delete|Int **productId**|ViewResult|HTTP POST|This method that is invoked when user clicks on the 'Delete' button next to a product. If product is found, the product is deleted and admin is redirected to ProductList view.|**File:** ProductList View => **Code:** AdminMod2|

- CartController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding the Shopping Cart.</dd>
    </dl>

    |Method|Parameters|Return|Method type|Description|Parameter Modification|
    |-----------|-----------|-----------|-----------|-----------|-----------|
    |CartController|IProductRepository,Cart|Void|None|Initializes variables **repository** with a list of all available products in the repository and **cart** with a list of all products currently in the shopping cart.|None|
    |Cart|String|ViewResult **returnUrl**|HTTP GET|This method is invoked when the user clicks on the cart icon. The method recieves a Url as a parameter. This method calls the Cart view and it initializes the model to an instance of the CartIndexViewModel (with ReturnUrl being initialized to **returnUrl**).|**File:** PostLogin View => **Code:** CartMod1|
    |AddToCart|Int **productId**,String **returnUrl**|RedirectResult|HTTP POST|This method is invoked when a user clicks on the 'Add Item' button. This method checks if item exists in the database, and if it does it add/updates the item to the cart. It redirects the user to the page defined in **returnUrl** string.|**File:** ProductSummary/PostLogin View => **Code:** CartMod3|
    |RemoveFromCart|Int **productId**,String **returnUrl**|RedirectToActionResult|HTTP POST| This method is invoked when the user clicks on the 'Remove' button next to an item in the cart. This method checks if item exists in the database, and if it does it removes the item from the cart. It redirects the user to the page defined in returnUrl string.|**File:** Cart View => **Code:** CartMod2|

- HomeController
    <dl>
        <dd>This controller hanldes all the actions/requests regarding the Home page.</dd>
    </dl>

    |Method|Parameters|Return|Method Type|Description|Parameter Modification|
    |-----------|-----------|-----------|-----------|-----------|-----------|
    |Index|String **category**, Int **sort**, Int **page**|ViewResult|HTTP GET| This method is invoked when the application is launched or when the user is directed to '/Home/Index' url. This method returns to the Index View, and initializes the model to a list of products based on provided filters, if any, and returns information for how many pages there should be to display all products.|**File:** PostLogin, NavigationMenu/Default View => **Code:** HomeMod1(category), HomeMod2(sort), HomeMod3(page)|
    |PostLogin|String **category**, Int **sort**, Int **page**|ViewResult|HTTP GET| This method is invoked when the user logs in or when the user is directed to '/Home/PostLogin' url. This method returns to the Index View, and initializes the model to a list of products based on provided filters, if any, and returns information for how many pages there should be to display all products.|**File:** PostLogin, NavigationMenu/Default View => **Code:** HomeMod1(category), HomeMod2(sort), HomeMod3(page)|

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
    |Completed|None|ViewResult|HTTP GET method which is invoked when the user submits an order succesfully. This method clears shopping cart and then returns Completed View.|
    
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
