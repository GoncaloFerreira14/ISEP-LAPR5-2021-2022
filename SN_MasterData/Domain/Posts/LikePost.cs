using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Posts
{
    [ComplexType]
    public class LikePost : IValueObject
    {
        public int likes;

        private LikePost()
        {
            likes = 0;
        }

        public LikePost(int likes)
        {
            this.likes = likes;
        }
    }
}