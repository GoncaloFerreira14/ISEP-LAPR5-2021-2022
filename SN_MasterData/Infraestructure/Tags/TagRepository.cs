using SocialNetwork.Infrastructure.Shared;
using SocialNetwork.Domain.Tags;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Infrastructure.Tags
{
    public class TagRepository : BaseRepository<Tag, TagId>, ITagRepository
    {
        SocialNetworkDbContext context;
        public TagRepository(SocialNetworkDbContext context):base(context.Tags)
        {
            this.context = context;
        }
        public async Task<Tag> GetByStringAsync(string tag){
            return await ((DbSet<Tag>)base.getObjs()).Where(x => x.TagJM.Text == tag).FirstOrDefaultAsync();
            }
    }
}