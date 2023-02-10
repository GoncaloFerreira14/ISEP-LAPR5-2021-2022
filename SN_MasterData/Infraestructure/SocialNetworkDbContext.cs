using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Categories;
using SocialNetwork.Domain.Products;
using SocialNetwork.Domain.Families;
using SocialNetwork.Domain.Posts;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Infrastructure.Categories;
using SocialNetwork.Infrastructure.Products;
using SocialNetwork.Infrastructure.Jogadores;
using SocialNetwork.Infrastructure.Tags;
using SocialNetwork.Infrastructure.Relacoes;
using SocialNetwork.Infrastructure.EstadosEmocionais;
using SocialNetwork.Infrastructure.PedidosIntroducao;
using SocialNetwork.Infrastructure.PedidosLigacao;
using SocialNetwork.Infrastructure.Posts;
using SocialNetwork.Infrastructure.Comentarios;

namespace SocialNetwork.Infrastructure
{
    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<Jogador> Jogadores {get; set;}

        public DbSet<Tag> Tags{get; set;}

        public DbSet<Relacao> Relacoes{get; set;}

        public DbSet<EstadoEmocional> EstadoEmocional{get; set;}

        public DbSet<PedidoIntroducao> PedidosIntroducao{get; set;}

        public DbSet<PedidoLigacao> PedidosLigacao{get; set;}

        public DbSet<Post> Posts{get; set;}
        public DbSet<Post> Comentarios{get; set;}

        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JogadorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RelacaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoEmocionalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoIntroducaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoLigacaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        }
    }
}