This project uses Centralized Routes.
Centralized Routes are configured in App_Start\WebApiConfig.cs

With route defaults you are able to point specific routes to relevant controllers directly; however, such routes need to be defined before generic routes. 

The reason for that is that route order matters because a route that will handle an incoming HTTP request is selected by scanning the route collection on every request. 
As soon as a first matching route template is found, the route is going to be used. 
Therefore, you will always need to declare the more specific routes before the generic ones.

Centralized routing makes it very tedious and unnatural when it comes to defining complex, hierarchical, or nested routes. 
Consider the following routing requirement (located in Controllers\TeamsController.cs):

To run the examples below, open postman and run the examples located in Routing-Centralized-Routes

• GET myapi.com/api/teams
• GET myapi.com/api/teams/1
• GET myapi.com/api/teams/1/players

With centralized routing it’s possible to contain all three methods in the same controller; however, you have to
be careful not to have routes 2 and 3 conflict with each other since both are a GET with a single ID parameter. 
A specific route pointing to the /players/segment of the URL is defined before the generic route.

See App_Start\WebApiConfig.cs

config.Routes.MapHttpRoute(
name: "players",
routeTemplate: "api/teams/{teamid}/players",
defaults: new { controller = "teams" }
);

config.Routes.MapHttpRoute(
name: "DefaultApi",
routeTemplate: "api/{controller}/{id}",
defaults: new { id = RouteParameter.Optional }
);

