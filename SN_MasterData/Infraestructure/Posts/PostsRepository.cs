using SocialNetwork.Domain.Posts;
using SocialNetwork.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Infrastructure.Posts
{
    public class PostsRepository : BaseRepository<Post,PostId>, IPostRepository
    {
        SocialNetworkDbContext context;

        public PostsRepository(SocialNetworkDbContext context) : base(context.Posts)
        {
            this.context = context;
        }

        public new async Task<List<Post>> GetAllAsync(){
            return await context.Posts.Include(p => p.Comentarios).Include(p => p.TagsPost).ToListAsync();
        }

        public new async Task<Post> GetByIdAsync(PostId id){
            Post p = await ((DbSet<Post>)base.getObjs()).Where(x => x.Id == id).Include(p => p.Comentarios).Include(p => p.TagsPost).FirstOrDefaultAsync();
            return p;
        }
    }
}