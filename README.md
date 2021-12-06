<p align="center">
<img src ="https://raw.githubusercontent.com/json-api-dotnet/JsonApiDotnetCore/master/logo.png" />
</p>

# JsonApiDotNetCore
A framework for building [JSON:API](http://jsonapi.org/) compliant REST APIs using .NET Core and Entity Framework Core. Includes support for [Atomic Operations](https://jsonapi.org/ext/atomic/).

[![Build](https://ci.appveyor.com/api/projects/status/t8noo6rjtst51kga/branch/master?svg=true)](https://ci.appveyor.com/project/json-api-dotnet/jsonapidotnetcore/branch/master)
[![Coverage](https://codecov.io/gh/json-api-dotnet/JsonApiDotNetCore/branch/master/graph/badge.svg?token=pn036tWV8T)](https://codecov.io/gh/json-api-dotnet/JsonApiDotNetCore)
[![NuGet](https://img.shields.io/nuget/v/JsonApiDotNetCore.svg)](https://www.nuget.org/packages/JsonApiDotNetCore/)
[![Chat](https://badges.gitter.im/json-api-dotnet-core/Lobby.svg)](https://gitter.im/json-api-dotnet-core/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![FIRST-TIMERS](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](http://www.firsttimersonly.com/)

The ultimate goal of this library is to eliminate as much boilerplate as possible by offering out-of-the-box features such as sorting, filtering and pagination. You just need to focus on defining the resources and implementing your custom business logic. This library has been designed around dependency injection, making extensibility incredibly easy.

## Getting Started

These are some steps you can take to help you understand what this project is and how you can use it:

- [What is JSON:API and why should I use it?](https://nordicapis.com/the-benefits-of-using-json-api/)
- [The JSON:API specification](http://jsonapi.org/format/)
- Demo [Video](https://youtu.be/KAMuo6K7VcE), [Blog](https://dev.to/wunki/getting-started-5dkl)
- [Our documentation](https://www.jsonapi.net/)
- [Check out the example projects](https://github.com/json-api-dotnet/JsonApiDotNetCore/tree/master/src/Examples)
- [Embercasts: Full Stack Ember with ASP.NET Core](https://www.embercasts.com/course/full-stack-ember-with-dotnet/watch/whats-in-this-course-cs)
- [Roadmap](ROADMAP.md)

## Related Projects

- [Performance Reports](https://github.com/json-api-dotnet/PerformanceReports)
- [JsonApiDotNetCore.MongoDb](https://github.com/json-api-dotnet/JsonApiDotNetCore.MongoDb)
- [JsonApiDotNetCore.Marten](https://github.com/wayne-o/JsonApiDotNetCore.Marten)
- [Todo List App](https://github.com/json-api-dotnet/TodoListExample)

## Examples

See the [examples](https://github.com/json-api-dotnet/JsonApiDotNetCore/tree/master/src/Examples) directory for up-to-date sample applications. There is also a [Todo List App](https://github.com/json-api-dotnet/TodoListExample) that includes a JsonApiDotNetCore API and an EmberJs client.

## Installation and Usage

See [our documentation](https://www.jsonapi.net/) for detailed usage.

### Models

```c#
public class Article : Identifiable
{
    [Attr]
    public string Name { get; set; }
}
```

### Controllers

```c#
public class ArticlesController : JsonApiController<Article>
{
    public ArticlesController(IJsonApiOptions options, ILoggerFactory loggerFactory,
        IResourceService<Article> resourceService,)
        : base(options, loggerFactory, resourceService)
    {
    }
}
```

### Middleware

```c#
public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddJsonApi<AppDbContext>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseJsonApi();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
```

## Compatibility

A lot of changes were introduced in v4. The following chart should help you pick the best version, based on your environment.
See also our [versioning policy](./VERSIONING_POLICY.md).

| .NET Version      | EF Core Version | JsonApiDotNetCore Version |
| ----------------- | --------------- | ------------------------- |
| .NET Core 2.x     | 2.x             | v3.x                      |
| .NET Core 3.1     | 3.1, 5          | v4                        |
| .NET 5            | 5               | v4                        |


## Contributing

Have a question, found a bug or want to submit code changes? See our [contributing guidelines](./.github/CONTRIBUTING.md).

## Trying out the latest build

After each commit to the master branch, a new prerelease NuGet package is automatically published to AppVeyor at https://ci.appveyor.com/nuget/jsonapidotnetcore. To try it out, follow the next steps:

* In Visual Studio: **Tools**, **NuGet Package Manager**, **Package Manager Settings**, **Package Sources**
    * Click **+**
    * Name: **AppVeyor JADNC**, Source: **https://ci.appveyor.com/nuget/jsonapidotnetcore**
    * Click **Update**, **Ok**
* Open the NuGet package manager console (**Tools**, **NuGet Package Manager**, **Package Manager Console**)
    * Select **AppVeyor JADNC** as package source
    * Run command: `Install-Package JonApiDotNetCore -pre`

## Development

To build the code from this repository locally, run:

```bash
dotnet build
```

Running tests locally requires access to a PostgreSQL database. If you have docker installed, this can be propped up via:

```bash
run-docker-postgres.ps1
```

And then to run the tests:

```bash
dotnet test
```

Alternatively, to build and validate the code, run all tests, generate code coverage and produce the NuGet package:

```bash
Build.ps1
```
## Referencing the Framework

A nuget package for this framework is automatically built upon compilation, which can then be used in other dependent applications. However,
it is NOT available on public http://nuget.org. There are several options available in referencing the framework.


#### Application-Level NuGet Package Hosting

To use the NuGet package without a remote host, you can add it to your dependent application solution. 

- Create 'Dependencies' file system folder in your dependent application and copy the NuGet package to it.
- Create a 'Dependencies' Solution folder in your dependent application solution and then add the NuGet package to it.
- Create a *nuget.config* file in the root of your dependent application with a package source that points to your 'Dependencies' folder.

Visual Studio will add the new package source location so you can then add a reference to the JADNC nuget package.


#### Host in Private Azure DevOps Artifact Feed

* Ensure Nuget.exe is installed locally
* Ensure a package location is added to *nuget.config* file **in your dependent application**:
 
<configuration>
  <packageSources>
    <clear />
    <add key="Your-Feed-Name" value="https://pkgs.dev.azure.com/Your-Path-To-Azure-DevOps/_packaging/Your-Feed-Name/nuget/v3/index.json" />
  </packageSources>
</configuration>


* From the Powershell command-line and the **JsonApiDotNetCore** project directory, issue the following:

 ```bash
 nuget.exe restore

 nuget.exe push -Source "Your-Feed-Name" -ApiKey az .\bin\{build-config}\Projekt202.JsonApiDotNetCore.{current version}.nupkg  -configfile {PATH TO DEPENDENT APP}\nuget.config
 ```
See https://docs.microsoft.com/en-us/azure/devops/artifacts/get-started-nuget?view=azure-devops for more details.

#### Host on Other Private Nuget Feed Platform

- [Artifactory](https://www.jfrog.com/artifactory/) from JFrog.
- [BaGet](https://github.com/loic-sharma/BaGet), an open-source implementation of NuGet V3 server built on ASP.NET Core
- [Cloudsmith](https://cloudsmith.io/l/nuget-feed/), a fully managed package management SaaS
- [GitHub package registry](https://help.github.com/articles/configuring-nuget-for-use-with-github-package-registry)
- [LiGet](https://github.com/ai-traders/liget), an open-source implementation of NuGet V2 server that runs on kestrel in docker
- [MyGet](https://myget.org/)
- [Nexus Repository OSS](https://www.sonatype.com/nexus-repository-oss) from Sonatype.
- [NuGet Server (Open Source)](https://github.com/svenkle/nuget-server), an open-source implementation similar to Inedo's NuGet Server
- [NuGet Server](http://nugetserver.net/), a community project from Inedo
- [ProGet](https://inedo.com/proget) from Inedo
- [Sleet](https://github.com/emgarten/sleet), an open-source NuGet V3 static feed generator
- [TeamCity](https://www.jetbrains.com/teamcity/) from JetBrains.


#### Include DLL Directly in Dependent App

Include the compiled DLL in your solution and reference it directly using a relative path.
