Swagger.Net
===========

Library to document the ASP.NET Web API using the Swagger specification

Latest version: Pre-release 0.5.2

Introduction
------------

Swagger.Net will expose any apis the inherit from the ApiController in the new [ASP.NET Web API](http://www.asp.net/web-api).

Swagger UI is included.  If you roll your own somewhere, just point your instance of [Swagger UI](https://github.com/wordnik/swagger-ui) at http://YOUR_URL/api/swagger to expose all of the APIs that you have built.  

Swagger.Net uses a combination of the Web API [ApiExplorer](http://msdn.microsoft.com/en-us/library/system.web.http.description.apiexplorer.aspx) class and XML Documentation you write in your /// blocks.

One article that helped me tremendously: [Generating a Web API help page using ApiExplorer] (http://blogs.msdn.com/b/yaohuang1/archive/2012/05/21/asp-net-web-api-generating-a-web-api-help-page-using-apiexplorer.aspx).

Swagger.NET conforms to the [Swagger specification](http://swagger.wordnik.com/spec) to support all swagger components including client code gen.

Requirements
------------

+ [ASP.NET MVC 4.0](http://www.asp.net/mvc/mvc4)
+ .NET 4.5

Upgrading from v0.5.1
---------------------

You will need to remove all Swagger.Net related code from `Global.asax.cs` and also from `App_Start\RouteConfig.cs`. If you also had a docs xml file in `App_Data`, please remove and/or refer to step 1 of the configuration below.

Setup
-----

Install the [Nuget Package](https://nuget.org/packages/Swagger.Net): Search for Swagger.Net in the package manager or Install-Package Swagger.Net

Configuration
-------------
1. Enable "XML documentation file" and accept the default value, or specify a custom value (i.e. App_Data\Docs.XML), in the Web API's properties | Build menu (Alt+Enter). If you specify a custom value, you will need to edit the App_Start\SwaggerNet.cs file.

2. Optional: If you wish to see the JSON easily from the browser and you don't care about xml Accept headers, then add the following to your `Application_Start()`:

            var xmlFormatter = config.Formatters
              .Where(f =>
              {
                  return f.SupportedMediaTypes.Any(v => v.MediaType == "text/xml");
              })
              .FirstOrDefault();

            if (xmlFormatter != null)
            {
                config.Formatters.Remove(xmlFormatter);
            }

Known Issues
------------

I'm hoping you will help me find these.

+ The version of Swagger UI I have built in the /docs folder DOES NOT WORK in Internet Explorer.  :-(
+ Models according to the swagger spec are not yet supported


Other Thoughts
--------------

I dropped the Swagger UI directly on the root in a folder called docs, then redirected the index action to /docs.  I also edited the index.html file to point it directly at /api/swagger so it can traverse the documentation.  The Swagger UI that I installed I got from the [Swagger UI GitHub Repo](https://github.com/wordnik/swagger-ui/tree/master/dist)

I have built this library with the lastest/prerelease versions of everything .NET.  (VS 2012 RC, .NET 4.5 RC, etc.)

Improvements
-----------------

Create a fork of [Swagger.Net](https://github.com/miketrionfo/Swagger.Net/fork)

Did you change it? [Submit a pull request](https://github.com/miketrionfo/Swagger.Net/pull/new/master).

License
-------

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at [apache.org/licenses/LICENSE-2.0](http://apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
