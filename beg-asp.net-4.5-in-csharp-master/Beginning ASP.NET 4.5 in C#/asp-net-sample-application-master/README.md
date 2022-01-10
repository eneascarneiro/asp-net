# asp-net-sample-application
Sample application built in Asp.net and C# 

## Introduction
This is a sample application build in asp.net using c# for learning purpose, It has 2 application in this solution. First is web service and the other is 
web application. The Web application consume the web services from server side, added as a reference.

### Details
Its employee management app, which includes login to the panel, Addition of new employee, View the details of employee, Perform actions 
like edit, delete, searching based on fields, uploading user avatar.
#### Expose following urls:
* http://localhost:56464/login.aspx
* http://localhost:56464/Home.aspx
* http://localhost:56464/Manage.aspx
* http://localhost:55817/EmpWS.asmx

### Used topics
* Bootstrap3 for UI
* Web service interaction(.asmx) to process data.
* It uses MSSQL server to store employee details in table and store procedure for creating employee.
* It uses controls like, GridView, Textbox, Labels, DropDown, FileUpload, DataTemplate, Validation controls.
* It uses session to maintain login status.
* It has data sorting, pagination, inline editing.
 
### Steps to run the program
* Clone the repo
* Create the database, table and the store procedure mentioned in https://github.com/bishwanathjha/asp-net-sample-application/blob/master/SQLQuery1.sql
file. Change the `connectionString` in WebService Web.config file and same in WebApplication web.config file. Run command steps by steps.
* Build the WebService project
* Update the reference in WebApplication
* Build the WebApplication and run the project, By default login page will open
* Use the login details as username=a@a.com and password is a@a.com
* There you go!

Let me know if you have any issue or problem facing.
