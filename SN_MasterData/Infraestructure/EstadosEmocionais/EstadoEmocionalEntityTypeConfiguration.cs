using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.EstadosEmocionais;

namespace SocialNetwork.Infrastructure.EstadosEmocionais
{
    internal class EstadoEmocionalEntityTypeConfiguration : IEntityTypeConfiguration<EstadoEmocional>
    {
        public void Configure(EntityTypeBuilder<EstadoEmocional> builder)
        {
            builder.ToTable("EstadoEmocional", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.Data, data =>{
                data.Property(p => p.DH);
            }
            );
            builder.OwnsOne(b => b.ValorEstado, valor =>{
                valor.Property(p => p.Numero);
            });
        }
    }
}