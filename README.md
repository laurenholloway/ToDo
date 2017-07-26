<a name="Top"></a>
# To Do List Project: Tips
## Table of Contents
- [Changing Links in the Navbar](#links)
- [Automatically Setting Current Date for Creation Date of a List](#creation)
- [Creating a Partial View for Overdue Tasks](#partial)
<hr />

<a name="links"></a>

## Changing Links in the Navbar

The process of creating links in the navbar is different in MVC than how we created links in our straight-up HTML/CSS lesson.
- Navigate to the Layout view in the Shared Views folder
- Locate the portion of the navbar that has the 3 list items for the link
- When using Razor ActionLinks, there are 3 comma-separated parts of the ActionLink
  - First: The name of the link - How do you want the link to appear to users on the page?
  - Second: The name of the action (method in the controller that returns the view) - This is also the name of the view itself
  - Third: The name of the controller to which the action belongs - Same as the name of the view folder
Below, we changed our navigation links to Tasks (to take us to the Tasks Index view), Create Task (to take us to the Tasks Create view), and Lists (to take us to the Lists Index view).
```CSharp
<div class="navbar-collapse collapse">
    <ul class="nav navbar-nav">
        <li>@Html.ActionLink("Tasks", "Index", "Tasks")</li>
        <li>@Html.ActionLink("Create Task", "Create", "Tasks")</li>
        <li>@Html.ActionLink("Lists", "Index", "Lists")</li>
    </ul>
</div>
```
[Top](#Top)


<a name="creation"></a>
## Automatically Setting Current Date for the Creation Date of a List
As developers, we want to ensure we are providing the best user experience as possible for our applications. In this case, when a user creates a new To Do List, their is form field for the creation date. We do not wan the user to have to type in the creation date because the creation date will always be today. Instead, we can handle this piece for the user by removing the form field and automatically setting the creation date to the current date.

### Step 1: Remove the form field from the view
- Navigate to the Create page for List inside the Views folder
- Locate the section of the HTML/Razor that is responsible for the form field for the creation date
- You can start by just commenting out the section (as seen below) to ensure you've captured the right code
  - You can comment like so: `@*  *@`
```CSharp
@*<div class="form-group">
    @Html.LabelFor(model => model.Date, htmlAttributes: new { @class = "control-label col-md-2" })
    <div class="col-md-10">
        @Html.EditorFor(model => model.Date, new { htmlAttributes = new { @class = "form-control" } })
        @Html.ValidationMessageFor(model => model.Date, "", new { @class = "text-danger" })
    </div>
</div>*@
```
### Step 2: Set the creation date to the current date
- Navigate to the List Controller
- Find the Create method (note that there are 2)
  - The first Create method returns the view (which is the page with the form the user sees to create a new list)
  - The second Create method is the method that is doing the work of taking what the user typed into the form and saving it in the database.
- In the code snippet below, you can see we used the `list` instance given to us in the Create method parameters, and are using our `Date` property to set the date to `DateTime.Now`
```CSharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "ListID,Title,Date")] List list)
{
    if (ModelState.IsValid)
    {
        //See the line below
        list.Date = DateTime.Now;
        
        db.Lists.Add(list);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(list);
}
```
[Top](#Top)

## Creating a Partial View
Coming Soon...
