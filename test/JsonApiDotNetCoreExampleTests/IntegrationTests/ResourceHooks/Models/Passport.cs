using JetBrains.Annotations;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.ResourceHooks.Models
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public sealed class Passport : Identifiable, IIsLockable
    {
        [Attr]
        public bool IsLocked { get; set; }

        [HasOne]
        public Person Person { get; set; }
    }
}
