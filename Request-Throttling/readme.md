Sample project for throttling requests
NOTE: Project also uses dependency injection package Unity

From the Package Manager Console, run:
Install-Package WebApiContrib
Install-Package Unity

See App_Start\WebApiConfig.cs which has configured the ThrottlingHandler

In case a quota has been exceeded, the handler will respond with HttpStatusCode.Conflict (status code 409).
If the user cannot be identified, the response from the handler will be HttpStatusCode.Forbidden (status code 403).

ThrottlingHandler additionally injects two headers into the Web API response:
- RateLimit-Limit; and
- RateLimit-Remaining, 

