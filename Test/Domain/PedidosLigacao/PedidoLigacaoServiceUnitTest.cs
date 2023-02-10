using Xunit;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using System;
using Moq;
namespace Test.Domain.PedidosLIgacao
{

    public class PedidoLigacaoServiceUnitTest
    {
        [Fact]
        public async void GetAllAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();
            var mockRepoRelacao  = new Mock<IRelacaoRepository>();
            var mockRepoTags  = new Mock<ITagRepository>();
            var mockServicoRelacao = new Mock<RelacaoService>(mockUnitOfWork.Object, mockRepoRelacao.Object,mockRepoTags.Object, mockRepoJogador.Object);


            List<PedidoLigacao> l = new List<PedidoLigacao>();
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jA2 = new Jogador("Videira","v@gmail.com","eu.png","2001-09-13","934997954","vlinkedIn","vFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"vV3040");
            var jB2 = new Jogador("Carvalho","c@gmail.com","euh.png","2001-09-14","934997955","clinkedIn","cFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"cC");

            var  p1 =  new PedidoLigacao(jA,jB,"oi");
            var  p2 = new PedidoLigacao(jA2,jB2,"ola");

            l.Add(p1);
            l.Add(p2);

            List<MostrarPedidoLigacaoDto> exp = new List<MostrarPedidoLigacaoDto>();
            exp.Add(PedidoLigacaoMapper.toDtoM(p1));
            exp.Add(PedidoLigacaoMapper.toDtoM(p2));

            mockRepoPedidoLigacao.Setup(repo => repo.GetAllAsync()).ReturnsAsync(l);

            var service = new PedidoLigacaoService(mockUnitOfWork.Object, mockRepoPedidoLigacao.Object, mockRepoJogador.Object,mockRepoRelacao.Object,mockServicoRelacao.Object);

            List<MostrarPedidoLigacaoDto> act = await service.GetAllAsync();

            //Assert.Equal(exp, act);

        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();
            var mockRepoRelacao  = new Mock<IRelacaoRepository>();
            var mockRepoTags  = new Mock<ITagRepository>();
            var mockServicoRelacao = new Mock<RelacaoService>(mockUnitOfWork.Object, mockRepoRelacao.Object,mockRepoTags.Object, mockRepoJogador.Object);

            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jC = new Jogador("Peartree","p@gmail.com","euh.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"pP3040");
    

            var  p =  new PedidoLigacao(jA,jB,"ola");
            var exp = PedidoLigacaoMapper.toDtoM(p);

            mockRepoPedidoLigacao.Setup(repo => repo.GetByIdAsync(It.IsAny<PedidoLigacaoId>())).ReturnsAsync(p);

            var service = new PedidoLigacaoService(mockUnitOfWork.Object, mockRepoPedidoLigacao.Object, mockRepoJogador.Object,mockRepoRelacao.Object,mockServicoRelacao.Object);
            var act = await service.GetByIdAsync(p.Id);
            Assert.Equal(exp.Id, act.Id);
        }

      /* [Fact]
        public async void AddAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();

            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry);
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed);
            var jC = new Jogador("Pedro","p@gmail.com","eup.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful);
    
            var  p =  new PedidoLigacao(jA,jB,"ola");
            var exp = PedidoLigacaoMapper.toDto(p);

            mockRepoPedidoLigacao.Setup(repo => repo.AddAsync(p)).ReturnsAsync(p);

            var service = new PedidoLigacaoService(mockUnitOfWork.Object, mockRepoPedidoLigacao.Object, mockRepoJogador.Object);
            var act = await service.AddAsync(exp);

            Assert.IsType<String>(act.Id);
        }*/
    }
}