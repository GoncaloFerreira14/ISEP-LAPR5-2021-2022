using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Products
{
    public interface IProductRepository: IRepository<Product,ProductId>
    {
    }
}