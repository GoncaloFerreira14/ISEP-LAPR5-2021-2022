using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Tags;

namespace SocialNetwork.Infrastructure.Tags
{
    internal class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        //PROVISORIO
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.TagJM, tag => {
                tag.Property(p => p.Text).IsRequired();
            });
            builder.HasMany(b => b.Listajogadores);
            builder.HasMany(b => b.Listarelacoes);
        }
    }
}