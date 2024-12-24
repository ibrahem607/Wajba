namespace Wajba.Mapping;

public class BranchMapping:Profile
{
    public BranchMapping()
    {
        CreateMap<Branch, BranchDto>()
            .ReverseMap();
    }
}
