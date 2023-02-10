using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class SocialNetworkMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ddd");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoEmocional",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoHumor = table.Column<int>(type: "int", nullable: false),
                    Data_DH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorEstado_Numero = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoEmocional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento_DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroTelefone_Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLLinkedIn_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLFacebook_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoBreve_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoHumorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogador_EstadoEmocional_EstadoHumorId",
                        column: x => x.EstadoHumorId,
                        principalSchema: "ddd",
                        principalTable: "EstadoEmocional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoIntroducao",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoPedido = table.Column<int>(type: "int", nullable: false),
                    JogadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JogadorIntermedioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JogadorObjetivoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MsgIntermedio_Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgObjetivo_Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPedido_DH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRespostaAoPedido_DH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRespostaAIntroducao_DH = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoIntroducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoIntroducao_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoIntroducao_Jogador_JogadorIntermedioId",
                        column: x => x.JogadorIntermedioId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoIntroducao_Jogador_JogadorObjetivoId",
                        column: x => x.JogadorObjetivoId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoLigacao",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JogadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JogadorObjetivoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MsgObjetivo_Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPedido_DH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRespostaAoPedido_DH = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoLigacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoLigacao_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoLigacao_Jogador_JogadorObjetivoId",
                        column: x => x.JogadorObjetivoId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JogadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    data_dataPost = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relacao",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    forcaRelacao_forca = table.Column<int>(type: "int", nullable: true),
                    forcaLigacao_forca = table.Column<int>(type: "int", nullable: true),
                    DataRelacao_dataRel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    jogadorAmigoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    jogadorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relacao_Jogador_jogadorAmigoId",
                        column: x => x.jogadorAmigoId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relacao_Jogador_jogadorId",
                        column: x => x.jogadorId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JogadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Post_PostId",
                        column: x => x.PostId,
                        principalSchema: "ddd",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "ddd",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagJM_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Post_PostId",
                        column: x => x.PostId,
                        principalSchema: "ddd",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JogadorTag",
                schema: "ddd",
                columns: table => new
                {
                    ListaTagsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListajogadoresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadorTag", x => new { x.ListaTagsId, x.ListajogadoresId });
                    table.ForeignKey(
                        name: "FK_JogadorTag_Jogador_ListajogadoresId",
                        column: x => x.ListajogadoresId,
                        principalSchema: "ddd",
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogadorTag_Tags_ListaTagsId",
                        column: x => x.ListaTagsId,
                        principalSchema: "ddd",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelacaoTag",
                schema: "ddd",
                columns: table => new
                {
                    ListaTagsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListarelacoesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacaoTag", x => new { x.ListaTagsId, x.ListarelacoesId });
                    table.ForeignKey(
                        name: "FK_RelacaoTag_Relacao_ListarelacoesId",
                        column: x => x.ListarelacoesId,
                        principalSchema: "ddd",
                        principalTable: "Relacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelacaoTag_Tags_ListaTagsId",
                        column: x => x.ListaTagsId,
                        principalSchema: "ddd",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_JogadorId",
                schema: "ddd",
                table: "Comentario",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostId",
                schema: "ddd",
                table: "Comentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogador_EstadoHumorId",
                schema: "ddd",
                table: "Jogador",
                column: "EstadoHumorId");

            migrationBuilder.CreateIndex(
                name: "IX_JogadorTag_ListajogadoresId",
                schema: "ddd",
                table: "JogadorTag",
                column: "ListajogadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIntroducao_JogadorId",
                schema: "ddd",
                table: "PedidoIntroducao",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIntroducao_JogadorIntermedioId",
                schema: "ddd",
                table: "PedidoIntroducao",
                column: "JogadorIntermedioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIntroducao_JogadorObjetivoId",
                schema: "ddd",
                table: "PedidoIntroducao",
                column: "JogadorObjetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoLigacao_JogadorId",
                schema: "ddd",
                table: "PedidoLigacao",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoLigacao_JogadorObjetivoId",
                schema: "ddd",
                table: "PedidoLigacao",
                column: "JogadorObjetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_JogadorId",
                schema: "ddd",
                table: "Post",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Relacao_jogadorAmigoId",
                schema: "ddd",
                table: "Relacao",
                column: "jogadorAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Relacao_jogadorId",
                schema: "ddd",
                table: "Relacao",
                column: "jogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacaoTag_ListarelacoesId",
                schema: "ddd",
                table: "RelacaoTag",
                column: "ListarelacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PostId",
                schema: "ddd",
                table: "Tags",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comentario",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "JogadorTag",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "PedidoIntroducao",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "PedidoLigacao",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RelacaoTag",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Relacao",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "Jogador",
                schema: "ddd");

            migrationBuilder.DropTable(
                name: "EstadoEmocional",
                schema: "ddd");
        }
    }
}
