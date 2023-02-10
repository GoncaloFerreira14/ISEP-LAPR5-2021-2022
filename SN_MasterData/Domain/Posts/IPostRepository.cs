using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Jogadores;


namespace SocialNetwork.Domain.Posts
{
    public interface IPostRepository : IRepository<Post, PostId>
    {
        new Task<List<Post>> GetAllAsync();
        new Task<Post> GetByIdAsync(PostId id);
    }
}