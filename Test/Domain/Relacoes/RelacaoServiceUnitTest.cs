using Xunit;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.EstadosEmocionais;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using Moq;
namespace Test.Domain.Relacoes
{

    public class RelacaoServiceUnitTest
    {

        public const string NOME = "Hugo";
        public const string EMAIL = "hv@gmail.com";
        public const string AVATAR = "eu.png";
        public const string DATANASCIMENTO = "10/08/2001";
        public const string NUMEROTELEFONE = "934567899";
        public const string URLLINKEDIN = "linkedin.com";
        public const string URLFACEBOOK = "fb.com";
        public const string DESCRICAOBREVE = "eu sou amigo";
        public const string CIDADE = "Chaves";
        public const string PAIS = "Portugal";
        public const string PASS = "hH3040";

        public const string NOME2 = "Gonçalo";
        public const string EMAIL2 = "gf@gmail.com";
        public const string AVATAR2 = "gg.png";
        public const string DATANASCIMENTO2 = "10/08/2001";
        public const string NUMEROTELEFONE2 = "934444444";
        public const string URLLINKEDIN2 = "linkedin.com";
        public const string URLFACEBOOK2 = "fb.com";
        public const string DESCRICAOBREVE2 = "eu sou mau";
        public const string CIDADE2 = "Porto";
        public const string PAIS2 = "Portugal";
        public const string PASS2 = "gG3040";
        public  List<Tag> ListaTags = new List<Tag>();

        public  List<Tag> ListaTags2 = new List<Tag>();

        public  List<Tag> ListaTagsR = new List<Tag>();

        [Fact]
        public async void GetAllAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();

            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            Tag t3 = new Tag("computadores");
            Tag t4 = new Tag("programar");
            Tag t5 = new Tag("telemovel");
            Tag t6 = new Tag("roupa");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            ListaTags2.Add(t3);
            ListaTags2.Add(t4);
            ListaTagsR.Add(t5);
            ListaTagsR.Add(t6);
            Jogador j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,EstadosHumor.Angry,PASS);
            Jogador j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);

            List<Relacao> listaR = new List<Relacao>();
            var r1 = new Relacao(13,ListaTagsR,j1,j2);
            var r2 = new Relacao(20,ListaTagsR,j2,j1);
            listaR.Add(r1);
            listaR.Add(r2);

            List<RelacaoDto> expected = new List<RelacaoDto>();
            expected.Add(RelacaoMapper.toDto(r1));
            expected.Add(RelacaoMapper.toDto(r2));

            mockRepoRelacao.Setup(r => r.GetAllAsync()).ReturnsAsync(listaR);

            var service = new RelacaoService(mockUnitOfWork.Object, mockRepoRelacao.Object, mockRepoTag.Object, mockRepoJogador.Object);

            List<RelacaoDto> actual = await service.GetAllAsync();

           // Assert.Equal(expected, actual);

        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();

            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            Tag t3 = new Tag("computadores");
            Tag t4 = new Tag("programar");
            Tag t5 = new Tag("telemovel");
            Tag t6 = new Tag("roupa");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            ListaTags2.Add(t3);
            ListaTags2.Add(t4);
            ListaTagsR.Add(t5);
            ListaTagsR.Add(t6);
            Jogador j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,EstadosHumor.Angry,PASS);
            Jogador j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);

            var r = new Relacao(13,ListaTagsR,j1,j2);
            var expected = RelacaoMapper.toDto(r);

            mockRepoRelacao.Setup(r => r.GetByIdAsync(It.IsAny<RelacaoId>())).ReturnsAsync(r);

            var service = new RelacaoService(mockUnitOfWork.Object, mockRepoRelacao.Object, mockRepoTag.Object, mockRepoJogador.Object);
            
            var actual = await service.GetByIdAsync(r.Id);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();

            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            Tag t3 = new Tag("computadores");
            Tag t4 = new Tag("programar");
            Tag t5 = new Tag("telemovel");
            Tag t6 = new Tag("roupa");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            ListaTags2.Add(t3);
            ListaTags2.Add(t4);
            ListaTagsR.Add(t5);
            ListaTagsR.Add(t6);
            Jogador j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,EstadosHumor.Angry,PASS);
            Jogador j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);


            List<Tag> novasTags = new List<Tag>();
            Tag t7 = new Tag("viajar");
            Tag t8 = new Tag("dormir");
            novasTags.Add(t7);
            novasTags.Add(t8);

            var r = new Relacao(13,ListaTagsR,j1,j2);
            r.changeForcaLigacao(30);
            r.changeListaTags(novasTags);

            RelacaoDto expected = RelacaoMapper.toDto(r);

            mockRepoRelacao.Setup(r => r.GetByIdAsync(It.IsAny<RelacaoId>())).ReturnsAsync(r);

            var service = new RelacaoService(mockUnitOfWork.Object, mockRepoRelacao.Object, mockRepoTag.Object, mockRepoJogador.Object);

            var dto = new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
            var actual = await service.UpdateAsync(dto);

            Assert.Equal(expected.Id, actual.Id);
        }
    }
}