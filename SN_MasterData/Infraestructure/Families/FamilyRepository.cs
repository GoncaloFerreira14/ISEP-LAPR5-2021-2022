using SocialNetwork.Domain.Families;
using SocialNetwork.Infrastructure.Shared;

namespace SocialNetwork.Infrastructure.Families
{
    public class FamilyRepository : BaseRepository<Family, FamilyId>, IFamilyRepository
    {
      
        public FamilyRepository(SocialNetworkDbContext context):base(context.Families)
        {
            
        }

    }
}