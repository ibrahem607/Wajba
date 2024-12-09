using Xunit;

namespace Wajba.EntityFrameworkCore;

[CollectionDefinition(WajbaTestConsts.CollectionDefinitionName)]
public class WajbaEntityFrameworkCoreCollection : ICollectionFixture<WajbaEntityFrameworkCoreFixture>
{

}
