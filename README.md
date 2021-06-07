# EventsPlanner
An REST API aplcation for reservation seats on meetings/events.
To reserve user need to put name and email. 
With this API you can :
- create a meeting
- add user to meeting
- delete meeting
- show all meetings
- show coming meetings

Meeting information includes name, date time and description.

User's Name and Email are validated.

Only 25 people can participant meeting.

There are defined custom exeptions.

There is an **error handling middleware** which defines if exception is custom or not and send default information for unknown errors.

For data access was used **Unit Of Work pattern** to merge all CRUD operation into transaction for keeping ACID.

### Technology stack
- **.NET 5.0**
- **ASP.NET Web API**
- **Entity Framework Core 5.0**
- **FluentValidation**

### Architecture
Multi layer architecture:
- **EventsPlanner** - main startup project with controllers, validators and middleware
- **EventsPlanner.BusinessLogic** - a layer defines business logic features in services and custom exceptions
- **EventsPlanner.Domain** - includes model for meeting and user
- **EventsPlanner.DataAccess** - a layer for accessing database with repositories.
- **DataBase layer**

