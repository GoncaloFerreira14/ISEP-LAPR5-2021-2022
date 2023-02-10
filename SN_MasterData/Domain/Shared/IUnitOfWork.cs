using System.Threading.Tasks;

namespace SocialNetwork.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}