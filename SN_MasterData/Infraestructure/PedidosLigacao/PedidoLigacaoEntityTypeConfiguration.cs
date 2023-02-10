using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.PedidosLigacao;

namespace SocialNetwork.Infrastructure.PedidosLigacao
{
    internal class PedidoLigacaoEntityTypeConfiguration : IEntityTypeConfiguration<PedidoLigacao>
    {
        public void Configure(EntityTypeBuilder<PedidoLigacao> builder)
        {
            builder.ToTable("PedidoLigacao", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.MsgObjetivo, msg =>{
                msg.Property(p => p.Texto);
            });
            builder.HasOne(b => b.Jogador);
            builder.HasOne(b => b.JogadorObjetivo);
            builder.OwnsOne(b => b.DataPedido, data =>{
                data.Property(p => p.DH);
            });
            builder.OwnsOne(b => b.DataRespostaAoPedido, data =>{
                data.Property(p => p.DH);
            });
        }
    }
}