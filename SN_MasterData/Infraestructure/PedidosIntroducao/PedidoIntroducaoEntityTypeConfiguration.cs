using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.PedidosIntroducao;

namespace SocialNetwork.Infrastructure.PedidosIntroducao
{
    internal class PedidoIntroducaoEntityTypeConfiguration : IEntityTypeConfiguration<PedidoIntroducao>
    {
        public void Configure(EntityTypeBuilder<PedidoIntroducao> builder)
        {
            builder.ToTable("PedidoIntroducao", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.MsgIntermedio, msg =>{
                msg.Property(p => p.Texto);
            });
            builder.OwnsOne(b => b.MsgObjetivo, msg =>{
                msg.Property(p => p.Texto);
            });
            builder.OwnsOne(b => b.DataPedido, data =>{
                data.Property(p => p.DH);
            });
            builder.OwnsOne(b => b.DataRespostaAIntroducao, data =>{
                data.Property(p => p.DH);
            });
            builder.OwnsOne(b => b.DataRespostaAoPedido, data =>{
                data.Property(p => p.DH);
            });
            builder.HasOne(b => b.Jogador);
            builder.HasOne(b => b.JogadorIntermedio);
            builder.HasOne(b => b.JogadorObjetivo);
        }
    }
}