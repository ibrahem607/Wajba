using Wajba.Samples;
using Xunit;

namespace Wajba.EntityFrameworkCore.Domains;

[Collection(WajbaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<WajbaEntityFrameworkCoreTestModule>
{

}
