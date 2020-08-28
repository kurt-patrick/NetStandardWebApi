This project uses Direct Routes.
Direct Routes are enabled in App_Start\WebApiConfig.cs

By calling config.MapHttpAttributeRoutes();

You use direct routes by annotatating your actions with a RouteAttribute, 
and pass it a relevant route template

Option 1: Route

Each action is annotated with the full path to the action

[Route("api/teams/{id}")]
public Team GetTeam(int id) {}


Option 2: RoutePrefix
By using RoutePrefix you can define the base path into the controller at the class level,
and then add the specifics for at the action level

[RoutePrefix("api/teams")]
public class TeamsController : ApiController
{
	[Route("{id}")]
	public Team GetTeam(int id) {}

	[Route("{teamId}/players")]
	public IEnumerable<Player> GetPlayers(int teamId) {}
}

When you call MapHttpAttributeRoutes at your application startup, 
you instruct ASP.NET Web API to scan all of your controllers for any route declarations.

Ultimately, routes declared with attribute routing are not much different from centralized routing; once found,
they are added to the same route collection that centralized routing uses. The only difference is
that direct routes (attribute-based routes) are added to the route collection as a single composite route (an internal
SubRouteCollection type) under a common MS_attributerouteWebApi route key.

When processing each attribute route, the controller (HttpControllerDescriptor) or action (HttpActionDescriptor)
that the direct route is specifically pointing to will be marked as only reachable via attribute routing. 

This is achieved by adding an MS_IsAttributeRouted to the Properties dictionary on either of those descriptor types.

To run the examples below, open postman and run the examples located in Routing-Centralized-Routes

• GET myapi.com/api/teams
• GET myapi.com/api/teams/1
• GET myapi.com/api/teams/1/players

