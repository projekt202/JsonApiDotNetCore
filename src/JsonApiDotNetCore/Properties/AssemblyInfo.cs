using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Benchmarks")]
[assembly: InternalsVisibleTo("JsonApiDotNetCoreTests")]
[assembly: InternalsVisibleTo("UnitTests")]
[assembly: InternalsVisibleTo("DiscoveryTests")]
[assembly: InternalsVisibleTo("TestBuildingBlocks")]

// To help in supporting testing, add your project assembly to InternalsVisible and compile the nuget package - then remove before checking into GitHub repo
