﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    partial class SocialNetworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("JogadorTag", b =>
                {
                    b.Property<string>("ListaTagsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ListajogadoresId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ListaTagsId", "ListajogadoresId");

                    b.HasIndex("ListajogadoresId");

                    b.ToTable("JogadorTag");
                });

            modelBuilder.Entity("RelacaoTag", b =>
                {
                    b.Property<string>("ListaTagsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ListarelacoesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ListaTagsId", "ListarelacoesId");

                    b.HasIndex("ListarelacoesId");

                    b.ToTable("RelacaoTag");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Categories.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Comentarios.Comentario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comentario", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.EstadosEmocionais.EstadoEmocional", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EstadoHumor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EstadoEmocional", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Families.Family", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Jogadores.Jogador", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EstadoHumorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoHumorId");

                    b.ToTable("Jogador", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PedidosIntroducao.PedidoIntroducao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EstadoPedido")
                        .HasColumnType("int");

                    b.Property<string>("JogadorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorIntermedioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorObjetivoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("JogadorIntermedioId");

                    b.HasIndex("JogadorObjetivoId");

                    b.ToTable("PedidoIntroducao", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PedidosLigacao.PedidoLigacao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorObjetivoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("JogadorObjetivoId");

                    b.ToTable("PedidoLigacao", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Posts.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JogadorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.ToTable("Post", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Products.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Relacoes.Relacao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("jogadorAmigoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("jogadorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("jogadorAmigoId");

                    b.HasIndex("jogadorId");

                    b.ToTable("Relacao", "ddd");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Tags.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Tags", "ddd");
                });

            modelBuilder.Entity("JogadorTag", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Tags.Tag", null)
                        .WithMany()
                        .HasForeignKey("ListaTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", null)
                        .WithMany()
                        .HasForeignKey("ListajogadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelacaoTag", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Tags.Tag", null)
                        .WithMany()
                        .HasForeignKey("ListaTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Relacoes.Relacao", null)
                        .WithMany()
                        .HasForeignKey("ListarelacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Comentarios.Comentario", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("JogadorId");

                    b.HasOne("SocialNetwork.Domain.Posts.Post", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("PostId");

                    b.OwnsOne("SocialNetwork.Domain.Comentarios.DataComentario", "Data", b1 =>
                        {
                            b1.Property<string>("ComentarioId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("ComentarioId");

                            b1.ToTable("Comentario");

                            b1.WithOwner()
                                .HasForeignKey("ComentarioId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Comentarios.TextoComentario", "Texto", b1 =>
                        {
                            b1.Property<string>("ComentarioId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("ComentarioId");

                            b1.ToTable("Comentario");

                            b1.WithOwner()
                                .HasForeignKey("ComentarioId");
                        });

                    b.Navigation("Data");

                    b.Navigation("Jogador");

                    b.Navigation("Texto");
                });

            modelBuilder.Entity("SocialNetwork.Domain.EstadosEmocionais.EstadoEmocional", b =>
                {
                    b.OwnsOne("SocialNetwork.Domain.EstadosEmocionais.DataHora", "Data", b1 =>
                        {
                            b1.Property<string>("EstadoEmocionalId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("EstadoEmocionalId");

                            b1.ToTable("EstadoEmocional");

                            b1.WithOwner()
                                .HasForeignKey("EstadoEmocionalId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.EstadosEmocionais.Valor", "ValorEstado", b1 =>
                        {
                            b1.Property<string>("EstadoEmocionalId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("Numero")
                                .HasColumnType("float");

                            b1.HasKey("EstadoEmocionalId");

                            b1.ToTable("EstadoEmocional");

                            b1.WithOwner()
                                .HasForeignKey("EstadoEmocionalId");
                        });

                    b.Navigation("Data");

                    b.Navigation("ValorEstado");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Jogadores.Jogador", b =>
                {
                    b.HasOne("SocialNetwork.Domain.EstadosEmocionais.EstadoEmocional", "EstadoHumor")
                        .WithMany()
                        .HasForeignKey("EstadoHumorId");

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Data", "DataNascimento", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DataNascimento")
                                .HasColumnType("datetime2");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Email", "Email", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.NumeroTelefone", "NumeroTelefone", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Numero")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "Avatar", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "Cidade", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "DescricaoBreve", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "Nome", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "Pais", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Texto", "Password", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Url", "URLFacebook", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("URL")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Jogadores.Url", "URLLinkedIn", b1 =>
                        {
                            b1.Property<string>("JogadorId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("URL")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("JogadorId");

                            b1.ToTable("Jogador");

                            b1.WithOwner()
                                .HasForeignKey("JogadorId");
                        });

                    b.Navigation("Avatar");

                    b.Navigation("Cidade");

                    b.Navigation("DataNascimento");

                    b.Navigation("DescricaoBreve");

                    b.Navigation("Email");

                    b.Navigation("EstadoHumor");

                    b.Navigation("Nome");

                    b.Navigation("NumeroTelefone");

                    b.Navigation("Pais");

                    b.Navigation("Password");

                    b.Navigation("URLFacebook");

                    b.Navigation("URLLinkedIn");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PedidosIntroducao.PedidoIntroducao", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("JogadorId");

                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "JogadorIntermedio")
                        .WithMany()
                        .HasForeignKey("JogadorIntermedioId");

                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "JogadorObjetivo")
                        .WithMany()
                        .HasForeignKey("JogadorObjetivoId");

                    b.OwnsOne("SocialNetwork.Domain.PedidosIntroducao.DataHora", "DataPedido", b1 =>
                        {
                            b1.Property<string>("PedidoIntroducaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("PedidoIntroducaoId");

                            b1.ToTable("PedidoIntroducao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoIntroducaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosIntroducao.DataHora", "DataRespostaAIntroducao", b1 =>
                        {
                            b1.Property<string>("PedidoIntroducaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("PedidoIntroducaoId");

                            b1.ToTable("PedidoIntroducao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoIntroducaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosIntroducao.DataHora", "DataRespostaAoPedido", b1 =>
                        {
                            b1.Property<string>("PedidoIntroducaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("PedidoIntroducaoId");

                            b1.ToTable("PedidoIntroducao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoIntroducaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosIntroducao.TextoPedidoIntroducao", "MsgIntermedio", b1 =>
                        {
                            b1.Property<string>("PedidoIntroducaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Texto")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PedidoIntroducaoId");

                            b1.ToTable("PedidoIntroducao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoIntroducaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosIntroducao.TextoPedidoIntroducao", "MsgObjetivo", b1 =>
                        {
                            b1.Property<string>("PedidoIntroducaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Texto")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PedidoIntroducaoId");

                            b1.ToTable("PedidoIntroducao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoIntroducaoId");
                        });

                    b.Navigation("DataPedido");

                    b.Navigation("DataRespostaAIntroducao");

                    b.Navigation("DataRespostaAoPedido");

                    b.Navigation("Jogador");

                    b.Navigation("JogadorIntermedio");

                    b.Navigation("JogadorObjetivo");

                    b.Navigation("MsgIntermedio");

                    b.Navigation("MsgObjetivo");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PedidosLigacao.PedidoLigacao", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("JogadorId");

                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "JogadorObjetivo")
                        .WithMany()
                        .HasForeignKey("JogadorObjetivoId");

                    b.OwnsOne("SocialNetwork.Domain.PedidosLigacao.DataHora", "DataPedido", b1 =>
                        {
                            b1.Property<string>("PedidoLigacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("PedidoLigacaoId");

                            b1.ToTable("PedidoLigacao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoLigacaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosLigacao.DataHora", "DataRespostaAoPedido", b1 =>
                        {
                            b1.Property<string>("PedidoLigacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("DH")
                                .HasColumnType("datetime2");

                            b1.HasKey("PedidoLigacaoId");

                            b1.ToTable("PedidoLigacao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoLigacaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.PedidosLigacao.TextoPedidoLigacao", "MsgObjetivo", b1 =>
                        {
                            b1.Property<string>("PedidoLigacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Texto")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PedidoLigacaoId");

                            b1.ToTable("PedidoLigacao");

                            b1.WithOwner()
                                .HasForeignKey("PedidoLigacaoId");
                        });

                    b.Navigation("DataPedido");

                    b.Navigation("DataRespostaAoPedido");

                    b.Navigation("Jogador");

                    b.Navigation("JogadorObjetivo");

                    b.Navigation("MsgObjetivo");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Posts.Post", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("JogadorId");

                    b.OwnsOne("SocialNetwork.Domain.Posts.DataPost", "data", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("dataPost")
                                .HasColumnType("datetime2");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Posts.DislikePost", "DislikePost", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Posts.LikePost", "LikePost", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Posts.TextoPost", "Texto", b1 =>
                        {
                            b1.Property<string>("PostId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("PostId");

                            b1.ToTable("Post");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("data");

                    b.Navigation("DislikePost");

                    b.Navigation("Jogador");

                    b.Navigation("LikePost");

                    b.Navigation("Texto");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Relacoes.Relacao", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "jogadorAmigo")
                        .WithMany()
                        .HasForeignKey("jogadorAmigoId");

                    b.HasOne("SocialNetwork.Domain.Jogadores.Jogador", "jogador")
                        .WithMany("ListaRelacoes")
                        .HasForeignKey("jogadorId");

                    b.OwnsOne("SocialNetwork.Domain.Relacoes.DataRelacao", "DataRelacao", b1 =>
                        {
                            b1.Property<string>("RelacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime>("dataRel")
                                .HasColumnType("datetime2");

                            b1.HasKey("RelacaoId");

                            b1.ToTable("Relacao");

                            b1.WithOwner()
                                .HasForeignKey("RelacaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Relacoes.ForcaLigacao", "forcaLigacao", b1 =>
                        {
                            b1.Property<string>("RelacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("forca")
                                .HasColumnType("int");

                            b1.HasKey("RelacaoId");

                            b1.ToTable("Relacao");

                            b1.WithOwner()
                                .HasForeignKey("RelacaoId");
                        });

                    b.OwnsOne("SocialNetwork.Domain.Relacoes.ForcaRelacao", "forcaRelacao", b1 =>
                        {
                            b1.Property<string>("RelacaoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("forca")
                                .HasColumnType("int");

                            b1.HasKey("RelacaoId");

                            b1.ToTable("Relacao");

                            b1.WithOwner()
                                .HasForeignKey("RelacaoId");
                        });

                    b.Navigation("DataRelacao");

                    b.Navigation("forcaLigacao");

                    b.Navigation("forcaRelacao");

                    b.Navigation("jogador");

                    b.Navigation("jogadorAmigo");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Tags.Tag", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Posts.Post", null)
                        .WithMany("TagsPost")
                        .HasForeignKey("PostId");

                    b.OwnsOne("SocialNetwork.Domain.Tags.TextoTag", "TagJM", b1 =>
                        {
                            b1.Property<string>("TagId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TagId");

                            b1.ToTable("Tags");

                            b1.WithOwner()
                                .HasForeignKey("TagId");
                        });

                    b.Navigation("TagJM");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Jogadores.Jogador", b =>
                {
                    b.Navigation("ListaRelacoes");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Posts.Post", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("TagsPost");
                });
#pragma warning restore 612, 618
        }
    }
}
