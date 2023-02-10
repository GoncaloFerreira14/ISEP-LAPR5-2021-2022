using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Posts;

namespace SocialNetwork.Infrastructure.Posts
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", SchemaNames.SocialNetwork);
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Jogador);
            builder.OwnsOne(p => p.data);
            builder.OwnsOne(p => p.Texto);
            builder.OwnsOne(p => p.LikePost);
            builder.OwnsOne(p => p.DislikePost);
            builder.HasMany(p => p.TagsPost);
            builder.HasMany(p => p.Comentarios);
        }
    }
}
