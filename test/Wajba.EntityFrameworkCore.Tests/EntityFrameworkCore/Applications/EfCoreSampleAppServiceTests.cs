using Wajba.Samples;
using Xunit;

namespace Wajba.EntityFrameworkCore.Applications;

[Collection(WajbaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<WajbaEntityFrameworkCoreTestModule>
{

}
