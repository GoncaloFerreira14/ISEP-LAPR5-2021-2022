using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Tags
{
    public interface ITagRepository:IRepository<Tag,TagId>
    {
        Task<Tag> GetByStringAsync(string tag);
    }
}