<p align="center">
<img src ="https://raw.githubusercontent.com/json-api-dotnet/JsonApiDotNetCore/master/logo.png" />
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

### About
- [What is JSON:API and why should I use it?](https://nordicapis.com/the-benefits-of-using-json-api/) (blog, 2017)
- [Pragmatic JSON:API Design](https://www.youtube.com/watch?v=3jBJOga4e2Y) (video, 2017)
- [JSON:API and JsonApiDotNetCore](https://www.youtube.com/watch?v=79Oq0HOxyeI) (video, 2021)
- [JsonApiDotNetCore Release 4.0](https://dev.to/wunki/getting-started-5dkl) (blog, 2020)
- [JSON:API, .Net Core, EmberJS](https://youtu.be/KAMuo6K7VcE) (video, 2017)
- [Embercasts: Full Stack Ember with ASP.NET Core](https://www.embercasts.com/course/full-stack-ember-with-dotnet/watch/whats-in-this-course-cs) (paid course, 2017)

### Official documentation
- [The JSON:API specification](https://jsonapi.org/format/1.1/)
- [JsonApiDotNetCore website](https://www.jsonapi.net/)
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
#nullable enable

[Resource]
public class Article : Identifiable<int>
{
    [Attr]
    public string Name { get; set; } = null!;
}
```

### Middleware

```c#
// Program.cs

builder.Services.AddJsonApi<AppDbContext>();

// ...

app.UseRouting();
app.UseJsonApi();
app.MapControllers();
```

## Compatibility

The following chart should help you pick the best version, based on your environment.
See also our [versioning policy](./VERSIONING_POLICY.md).

| JsonApiDotNetCore | Status      | .NET     | Entity Framework Core |
| ----------------- | ----------- | -------- | --------------------- |
| 3.x               | Stable      | Core 2.x | 2.x                   |
| 4.x               | Stable      | Core 3.1 | 3.1                   |
|                   |             | Core 3.1 | 5                     |
|                   |             | 5        | 5                     |
|                   |             | 6        | 5                     |
| v5.x              | Stable      | 6        | 6                     |

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
pwsh run-docker-postgres.ps1
```

And then to run the tests:

```bash
dotnet test
```

Alternatively, to build and validate the code, run all tests, generate code coverage and produce the NuGet package:

```bash
pwsh Build.ps1
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
