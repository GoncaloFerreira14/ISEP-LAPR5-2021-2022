using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Relacoes;

namespace SocialNetwork.Infrastructure.Relacoes
{
    internal class RelacaoEntityTypeConfiguration : IEntityTypeConfiguration<Relacao>
    {
        public void Configure(EntityTypeBuilder<Relacao> builder)
        {
            builder.ToTable("Relacao", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(r => r.forcaLigacao, f => {
                f.Property(p => p.forca).IsRequired();
            });
            builder.OwnsOne(r => r.forcaRelacao, f => {
                f.Property(p => p.forca).IsRequired();
            });
            builder.OwnsOne(b => b.DataRelacao, dt =>
                dt.Property(p => p.dataRel));
            builder.HasMany(b => b.ListaTags);
            builder.HasOne(b => b.jogadorAmigo);
        }
    }
}