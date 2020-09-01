https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/tracing-in-aspnet-web-api

To enable tracing in webapi perform the following steps:

In the Package Manager Console window, type the following commands.

Install-Package Microsoft.AspNet.WebApi.Tracing
Update-Package Microsoft.AspNet.WebApi.WebHost

Add the following line to WebApiConfig.cs:
config.EnableSystemDiagnosticsTracing();

OR, for more specific settings use:
SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
traceWriter.IsVerbose = true;
traceWriter.MinimumLevel = TraceLevel.Debug;

From that point on, all ASP.NET Web API internal activities are logged to Output > Debug

To test, from postman perform a GET against http://localhost:60089/api/demo/get

Example output:

Level=Debug, Kind=End, Category='System.Web.Http.Controllers', Id=00000000-0000-0000-0000-000000000000, Operation=WebHostHttpControllerTypeResolver.GetControllerTypes
Request received, Method=GET, Url=http://localhost:60089/api/demo/get, Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='http://localhost:60089/api/demo/get'
Level=Info, Kind=Begin, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Route='controller:demo,id:get'', Operation=DefaultHttpControllerSelector.SelectController
Level=Info, Kind=End, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Demo', Operation=DefaultHttpControllerSelector.SelectController
Level=Info, Kind=Begin, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=HttpControllerDescriptor.CreateController
Level=Info, Kind=Begin, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=DefaultHttpControllerActivator.Create
Level=Info, Kind=End, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Debugging.AddTraceWriter.Controllers.DemoController', Operation=DefaultHttpControllerActivator.Create
Level=Info, Kind=End, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Debugging.AddTraceWriter.Controllers.DemoController', Operation=HttpControllerDescriptor.CreateController
Level=Info, Kind=Begin, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=DemoController.ExecuteAsync
Level=Info, Kind=Begin, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=ApiControllerActionSelector.SelectAction
Level=Info, Kind=End, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Selected action 'Get()'', Operation=ApiControllerActionSelector.SelectAction
Level=Info, Kind=Begin, Category='System.Web.Http.ModelBinding', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=HttpActionBinding.ExecuteBindingAsync
Level=Info, Kind=End, Category='System.Web.Http.ModelBinding', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=HttpActionBinding.ExecuteBindingAsync
Level=Info, Kind=Begin, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Action='Get()'', Operation=ApiControllerActionInvoker.InvokeActionAsync
Level=Info, Kind=Begin, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Invoking action 'Get()'', Operation=ReflectedHttpActionDescriptor.ExecuteAsync

// these 2 lines are custom output added in Controllers\DemoController.Get()
Level=Info, Kind=Trace, Category='DemoController', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Info: Get()'
Level=Debug, Kind=Trace, Category='DemoController', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Debug: Get()'

Level=Info, Kind=End, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Action returned 'StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: <null>, Headers:{}'', Operation=ReflectedHttpActionDescriptor.ExecuteAsync
Level=Info, Kind=End, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=ApiControllerActionInvoker.InvokeActionAsync, Status=200 (OK)
Level=Info, Kind=End, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=DemoController.ExecuteAsync, Status=200 (OK)
Sending response, Status=200 (OK), Method=GET, Url=http://localhost:60089/api/demo/get, Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Content-type='none', content-length=unknown'
Level=Info, Kind=Begin, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=DemoController.Dispose
Level=Info, Kind=End, Category='System.Web.Http.Controllers', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Operation=DemoController.Dispose
Level=Info, Kind=Begin, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Action='Get()'', Operation=ApiControllerActionInvoker.InvokeActionAsync
Level=Info, Kind=Begin, Category='System.Web.Http.Action', Id=7b1c927b-d3d7-47b9-8eb8-1872cfe40114, Message='Invoking action 'Get()'', Operation=ReflectedHttpActionDescriptor.ExecuteAsync


