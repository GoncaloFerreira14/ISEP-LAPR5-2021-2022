using SocialNetwork.Domain.Products;
using SocialNetwork.Infrastructure.Shared;

namespace SocialNetwork.Infrastructure.Products
{
    public class ProductRepository : BaseRepository<Product, ProductId>,IProductRepository
    {
        public ProductRepository(SocialNetworkDbContext context):base(context.Products)
        {
           
        }
    }
}