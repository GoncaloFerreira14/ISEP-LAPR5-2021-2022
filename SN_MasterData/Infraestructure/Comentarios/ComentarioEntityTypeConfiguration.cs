using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Comentarios;

namespace SocialNetwork.Infrastructure.Comentarios
{
    internal class ComentarioEntityTypeConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario", SchemaNames.SocialNetwork);
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Jogador);
            builder.OwnsOne(p => p.Data);
            builder.OwnsOne(p => p.Texto);
        }
    }
}