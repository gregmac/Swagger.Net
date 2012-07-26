Swagger.Net
===========

Library to document the ASP.NET Web API using the Swagger specification

Latest version: 0.5

Introduction
------------

Swagger.Net will expose any apis the inherit from the ApiController in the new ASP.NET Web API.

Swagger UI is not included.  Just point your instance of Swagger UI at http://YOUR_URL/api/swagger to expose all of the APIs that you have built.  

Swagger.Net uses a combination of the Web API ApiExplorer class and XML Documentation you write in your /// blocks.

One article that helped me tremendously: [Generating a Web API using ApiExplorer] (http://blogs.msdn.com/b/yaohuang1/archive/2012/05/21/asp-net-web-api-generating-a-web-api-help-page-using-apiexplorer.aspx).

Requirements
------------

+ ASP.NET MVC 4.0
+ .NET 4.0 or 4.5

Setup
-----

1. Clone the branch labled for the version you wish, build and reference.
2. Nuget: I am currently working on this and it is incomplete.
3. Configuration: COMING SOON

Dependencies
------------
+ Newtonsoft JSON library (Will be shipping with the MVC 4 project templates)

Known Issues
------------

I'm hoping you will help me find these.


Other Thoughts
--------------

I created an Ignore Route `routes.IgnoreRoute("docs");` in the App_Start/RouteConfig.cs and then dropped the Swagger UI directly on the root in a folder called docs, then redirected the index action to /docs.  I also edited the index.html file to point it directly at /api/swagger so it can traverse the documentation.
