# AspNetCoreTest
Sample .net core rest api

#System Requirements: 
Visual Studio 2017
Net core 2.1


This is Sample Asp.net core api with Best practices for 
 --Rest Verbs used in this project 
 --Rest Status codes used in this project
 --Startup File Concepts
 --What is host, What is its role?
 --What Can you Configure using WebHostBuilder class?
 --Configuration in Aspnetcore
 --Error handling, global level in .net core api.
 --Routing basic and advanced.
 
#Rest Verbs used in this project
 Get/    - Fetch resources based on filter mentioned via query paramaters.
 Get/id  - Fetch a unique resource
 Post    - Create a resource, resource data is sent via Body.
 Put/id  - Update a resoruce, resource id specified in url, resource data is sent via Body.
 Delete/id  - Delete a resource, resource id specified in url.
 
#Rest Status codes used in this project
 200 -- Ok status, when the request was processed sucessfully. the response should have a body. eg Get api/users/id.
 201 -- Created status, when a resource is created sucessfully. eg Post api/users (user data in request body).
 202 -- Accepted status, when a resource is accepeted for processing asynchronously. eg Post api/orders (where the order is accepted but processing happens asynchronously).
 204 -- No Content status, when a request is processed but has nothing to sent back to the client. eg Delete api/comments (No message sent back to client).
 
 401 -- UnAuthorized status, when a request is not authenticated.
 403 -- Forbidden status, when a request is authenticated, but does not have right roles/permissions/right to execute the request.
 404 -- Not found status, when a request is not found for processing. 
 400 -- Bad request status, when request param/body, is not formed well with proper syntaxt. eg incorrect data format.
 422 -- UnProcessible Entity status, when a request input fails a business validation to perform a function.
 405 -- Method not allowed status, The request verb is not allowed. Eg readonly resource wheren GET and POST are only available. 
 406 -- Not Acceptable. When the server could not respond with request resource representation. eg Appliation/xml, but api supports only application/json.
 415 -- Unsupportable media type status. When the content is different type and api doesnt suppor this type.
 409 -- Conflict status. When the update of a resource fails due to race condition.
  
 500 -- Internal server error. Any logic exception, connectivity issue, memory issue errors are sent back as 500.
 
How routing is done in this project?
Url naming and right conventions?
How API docummentation is done?
Response data format, business validation?
  
#Startup File Concepts
 The Startup class configures services and the app's request pipeline. The startup class is mandatory one. The Start up class includes two methods.
 1) void ConfigureServices(IServiceCollection services) -- To configure app's services. eg logging service, database service. A Service provides an instance of a class. One way to get an instance of a service in a class is to create a constructor with a parameter of the required type. 
 The parameter can be the service type or an interface. While DI is built in, it's designed to let you plug in a third-party Inversion of Control (IoC) container if you prefer.
 2) void Configure(IApplicationBuilder app, IHostingEnvironment env) -- to configure the request pipeline. The reqest pipeline is a series of middleware components
 executed sequentially. Each middle ware performs a asynchronous logic or trasfers the next to the next pipeline. eg a middleware for authentication, 
 middle ware for fetching static files. ASP.NET Core includes a rich set of built-in middleware, and you can write custom middleware.

#What is host, What is its role?

 Asp.net core apps require a host within which they execute. The host is responsible for application start up and lifetime management. Host responsibility also includes server and application's availability and its configuration. 
 A host must implement "IWebHost" interface. AspNetcore provided "IWebHost" implementation is "WebHost". This "WebHost" is created using "WebHostBuilder" class (Factory pattern). With "WebHostBuilder" you create host, set the webserver(like kestrel), set the content root etc.

#What Can you Configure using WebHostBuilder class?

 set the WebServer                                            -- .UseKestrel()
 set IIS as proxy to Kesterl                                  -- .UseIISIntegration()
 set the middleware/request pipeline                          -- .Configure()
 set the DI                                                   -- .ConfigureServices()
 move Configure and ConfigureServices method to Startup file  -- .UseStartup()
 set Content root path                                        -- .UseContentRoot(path)
 set Environment variables                                    -- .UseSetting(key,value)
 set the path to access static files                          -- .UseWebRoot(FolderName)
 set the url which the server will listen to                  -- .UseUrls("http://localhost:5001;https://hostname:5002")
 set the startupAssembly                                      -- .UseStartup("StartupAssemblyName")

#Configuration in Aspnetcore.

 Configuration to Aspnetcore app can come from 
 1) appsettings.json 2) appsettings.{Environment}.json 3) User secrets file 4) Environment variables(launchSettings.json) 5) Command-line arguments

 1. launchSettings.json - This launchSettings.json file is for development purpose. When .net core application is run from Visual Studio or .Net Core CLI it uses launchSetting.json
 This file is not required while publishing to environment. So dont store application specific values in this file.
	It has 2 sections "iisSettings" and "profiles"
	a) iisSettings --> 
	b) profiles    --> You can have multiple profiles, based on environment settings, where you app will run. Few Properties under each profile.
	commandName           --  Which can be IISExpress, IIS or Project.
	launchUrl             --  eg api/users. The default path on launch
	launchBrowser         -- true or false. Where to lanunch browser.
	applicationUrl        -- can have multile urls specified. where your app will be listening for request.
	environmentVariables  -- It is object with different properties.

  2. appsettings.json -- This is same as app.config or web.config in traditional Asp.net applications. appsetting can be environment specific like appsettings.Development.json.

#Error Handling in AspnetCore
  1) UseDeveloperExceptionPage()		-- add this middleware to capture exception with complete stack trace
  2) UseExceptionHandler("/api/Error")  -- use this middleware to a handler eg to Error Controller get method.
  3) UseStatusCodePages()				-- use this middleware to sent status code as pages for 4xx and 5xx status code with no body.
  4) ExceptionFilers					-- Which captures exception withing the action method. Exception filters can be applied at global, at controller or at action method level.








