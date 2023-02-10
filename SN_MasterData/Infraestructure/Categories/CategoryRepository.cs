using SocialNetwork.Domain.Categories;
using SocialNetwork.Infrastructure.Shared;

namespace SocialNetwork.Infrastructure.Categories
{
    public class CategoryRepository : BaseRepository<Category, CategoryId>, ICategoryRepository
    {
    
        public CategoryRepository(SocialNetworkDbContext context):base(context.Categories)
        {
           
        }


    }
}