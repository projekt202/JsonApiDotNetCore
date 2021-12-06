using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using JsonApiDotNetCoreExampleTests.IntegrationTests.ResourceHooks.Models;
using Microsoft.Extensions.Logging;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.ResourceHooks.Controllers
{
    public sealed class UsersController : JsonApiController<User>
    {
        public UsersController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<User> resourceService)
            : base(options, loggerFactory, resourceService)
        {
        }
    }
}
