using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Infrastructure.Jogadores
{
    internal class JogadorEntityTypeConfiguration : IEntityTypeConfiguration<Jogador>
    {
        //PROVISORIO
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogador", SchemaNames.SocialNetwork);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(jogador => jogador.Nome, text => {
                text.Property(p => p.Text).IsRequired();
            });
            builder.OwnsOne(jogador => jogador.Email, email => { 
                email.Property(p => p.Endereco).IsRequired();
            });
            builder.OwnsOne(jogador => jogador.Avatar, avatar => {
                avatar.Property(p => p.Text);
            });
            builder.OwnsOne(jogador => jogador.Password, pass => {
                pass.Property(p => p.Text);
            });
            builder.OwnsOne(jogador => jogador.DataNascimento, dtnascimento => {
                dtnascimento.Property(p => p.DataNascimento).IsRequired();
            });
            builder.OwnsOne(jogador => jogador.NumeroTelefone, numero => {
                numero.Property(p => p.Numero);
            });
            builder.OwnsOne(jogador => jogador.URLFacebook, urlfb => {
                urlfb.Property(p => p.URL);
            });
            builder.OwnsOne(jogador => jogador.URLLinkedIn, urlL => {
                urlL.Property(p => p.URL);
            });
            builder.OwnsOne(jogador => jogador.DescricaoBreve, desc => {
                desc.Property(p => p.Text);
            });
            builder.OwnsOne(jogador => jogador.Cidade, c => {
                c.Property(p => p.Text);
            });
            builder.OwnsOne(jogador => jogador.Pais, pais => {
                pais.Property(p => p.Text);
            });
            builder.HasMany(jogador => jogador.ListaTags);
            builder.HasOne(jogador => jogador.EstadoHumor);
            builder.HasMany(jogador => jogador.ListaRelacoes).WithOne(r => r.jogador);
        }
    }
}