using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Posts
{
    [ComplexType]
    public class DislikePost : IValueObject
    {
        public int dislikes;

        private DislikePost()
        {
            dislikes = 0;
        }

        public DislikePost(int dislikes)
        {
            this.dislikes = dislikes;
        }
    }
}