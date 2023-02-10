using Xunit;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.EstadosEmocionais;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using System;
using Moq;
namespace Test.Domain.Jogadores
{

    public class JogadoresServiceUnitTest
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
        public const string PASS = "HH3040";
         public const string PASS2 = "GG3040";
        public  List<Tag> ListaTags = new List<Tag>();

        public  List<Tag> ListaTags2 = new List<Tag>();

        public List<Tag> listaR = new List<Tag>();

        [Fact]
        public async void GetAllAsyncTest()
        {
            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            Tag t3 = new Tag("computadores");
            Tag t4 = new Tag("programar");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            ListaTags2.Add(t3);
            ListaTags2.Add(t4);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();


            List<Jogador> listaJogadores = new List<Jogador>();
            var j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry,PASS);
            var j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);
            listaJogadores.Add(j1);
            listaJogadores.Add(j2);

            List<MostrarJogadorDto> expected = new List<MostrarJogadorDto>();
            expected.Add(JogadorMapper.toMostrarDto(j1));
            expected.Add(JogadorMapper.toMostrarDto(j2));

            mockRepoJogador.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listaJogadores);

            var service = new JogadorService(mockUnitOfWork.Object, mockRepoJogador.Object,mockRepoTag.Object,mockRepoRelacao.Object,mockRepoPedidoIntroducao.Object,mockRepoPedidoLigacao.Object);

            List<MostrarJogadorDto> actual = await service.GetAllAsync();

            //Assert.Equal(expected, actual);

        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();

            var j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry,PASS);
            var expected = JogadorMapper.toMostrarDto(j1);

            mockRepoJogador.Setup(repo => repo.GetByIdAsync(It.IsAny<JogadorId>())).ReturnsAsync(j1);

            var service = new JogadorService(mockUnitOfWork.Object, mockRepoJogador.Object,mockRepoTag.Object,mockRepoRelacao.Object,mockRepoPedidoIntroducao.Object,mockRepoPedidoLigacao.Object);
            var actual = await service.GetByIdAsync(j1.Id);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async void AddAsyncTest()
        {
            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();


            var j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry,PASS);
            var expected = JogadorMapper.toDto(j1);

            mockRepoJogador.Setup(repo => repo.AddAsync(j1)).ReturnsAsync(j1);

            var service = new JogadorService(mockUnitOfWork.Object, mockRepoJogador.Object,mockRepoTag.Object,mockRepoRelacao.Object,mockRepoPedidoIntroducao.Object,mockRepoPedidoLigacao.Object);
            var actual = await service.AddAsync(expected);
            Assert.IsType<String>(actual.Id);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            Tag t1 = new Tag("carros");
            Tag t2 = new Tag("corridas");
            ListaTags.Add(t1);
            ListaTags.Add(t2);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();

            var j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry,PASS);
            
            j1.ChangeAvatar("tetetee5555.png");
            j1.ChangeCidade("Porto");
            j1.ChangeData("20/10/2000");
            j1.ChangeDesc("Sou fixe");
            j1.ChangeEmail("hvid@gmail.com");
            j1.ChangeFacebook("facebook.com/hugo");
            j1.ChangeLinkedIn("linkedin.com/videira");
            j1.ChangeNome("Tiago");
            j1.ChangePais("Inglaterra");
            j1.ChangeTelefone("956787978");

            var expected = JogadorMapper.toDto(j1);

            mockRepoJogador.Setup(repo => repo.GetByIdAsync(It.IsAny<JogadorId>())).ReturnsAsync(j1);

            var service = new JogadorService(mockUnitOfWork.Object, mockRepoJogador.Object,mockRepoTag.Object,mockRepoRelacao.Object,mockRepoPedidoIntroducao.Object,mockRepoPedidoLigacao.Object);
            
            var dto = new JogadorDto{Id = j1.Id.AsString(), Nome = j1.Nome.Text, Email = j1.Email.Endereco, Avatar = j1.Avatar.Text,
                                     DataNascimento = j1.DataNascimento.DataNascimento.ToString(), NumeroTelefone = j1.NumeroTelefone.Numero, URLLinkedIn = j1.URLLinkedIn.URL
                                     , URLFacebook = j1.URLFacebook.URL, DescricaoBreve = j1.DescricaoBreve.Text, Cidade = j1.Cidade.Text, Pais = j1.Pais.Text, ListaTags = j1.conversaoTags(), EstadoHumor = j1.EstadoHumor.EstadoHumor, ListaRelacoes =  j1.getListaRelacoes()};
            var actual = await service.UpdateAsync(dto);

            Assert.Equal(expected.Id, actual.Id);
        }


       /* [Fact]

        public async void GetAllRelacoesJogadorTest(){
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
            listaR.Add(t5);
            listaR.Add(t6);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoJogador = new Mock<IJogadorRepository>();
            var mockRepoTag = new Mock<ITagRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();


            var j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry);
            var j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud);

            List<Relacao> listR = new List<Relacao>();
            Relacao r = new Relacao(15,listaR,j1,j2);

            listR.Add(r);

            List<RelacaoDto> expected = new List<RelacaoDto>();
            expected.Add(RelacaoMapper.toDto(r));

            mockRepoJogador.Setup(r => r.GetAllRelacoesJogador(It.IsAny<JogadorId>()));

            var service = new JogadorService(mockUnitOfWork.Object, mockRepoJogador.Object,mockRepoTag.Object,mockRepoRelacao.Object,mockRepoPedidoIntroducao.Object,mockRepoPedidoLigacao.Object);

            var actual = await service.GetAllRelacoesJogador(r.jogador.Id);

            Assert.(actual);
        }*/
        [Fact]

        public void GetAllRelacoesPorNivelJogador(){
            
        }

        [Fact]

        public void GetAllPedidosIntroducao(){
            
        }

        [Fact]

        public void GetAllPedidosLigacao(){
            
        }
    }
}