using Xunit;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using System;
using Moq;
namespace Test.Domain.PedidosIntroducao
{

    public class PedidoIntroducaoServiceUnitTest
    {
        [Fact]
        public async void GetAllAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();
            var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoTags = new Mock<ITagRepository>();
            var mockServiceRelacao = new Mock<RelacaoService>(mockUnitOfWork.Object, mockRepoRelacao.Object,mockRepoTags.Object, mockRepoJogador.Object);
            var mockServicoPedidoLigacao = new Mock<PedidoLigacaoService>(mockUnitOfWork.Object, mockRepoPedidoLigacao.Object, mockRepoJogador.Object, mockRepoRelacao.Object,mockServiceRelacao.Object);


            List<PedidoIntroducao> l = new List<PedidoIntroducao>();
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jC = new Jogador("Peartree","p@gmail.com","euh.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"pP3040");
            var jA2 = new Jogador("Videira","v@gmail.com","eu.png","2001-09-13","934997954","vlinkedIn","vFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"vV3040");
            var jB2 = new Jogador("Carvalho","c@gmail.com","euh.png","2001-09-14","934997955","clinkedIn","cFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"cC3040");
            var jC2 = new Jogador("Rocha","r@gmail.com","euh.png","2001-09-15","934997956","rlinkedIn","rFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"rR3040");

            var  p1 =  new PedidoIntroducao(jA,jB,jC,"oi","ola");
            var  p2 = new PedidoIntroducao(jA2,jB2,jC2,"ola","oi");

            l.Add(p1);
            l.Add(p2);

            List<MostrarPedidoIntroducaoDto> exp = new List<MostrarPedidoIntroducaoDto>();
            exp.Add(PedidoIntroducaoMapper.toDtoM(p1));
            exp.Add(PedidoIntroducaoMapper.toDtoM(p2));

            mockRepoPedidoIntroducao.Setup(repo => repo.GetAllAsync()).ReturnsAsync(l);

            var service = new PedidoIntroducaoService(mockUnitOfWork.Object, mockRepoPedidoIntroducao.Object, mockRepoJogador.Object, mockServicoPedidoLigacao.Object);

            List<MostrarPedidoIntroducaoDto> act = await service.GetAllAsync();

          //  Assert.Equal(exp.ToString(), act.GetHashCode().ToString());

        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();
            var mockRepoPedidoLigacao = new Mock<IPedidoLigacaoRepository>();var mockRepoRelacao = new Mock<IRelacaoRepository>();
            var mockRepoTags = new Mock<ITagRepository>();
            var mockServiceRelacao = new Mock<RelacaoService>(mockUnitOfWork.Object, mockRepoRelacao.Object,mockRepoTags.Object, mockRepoJogador.Object);
            var mockServicoPedidoLigacao = new Mock<PedidoLigacaoService>(mockUnitOfWork.Object, mockRepoPedidoLigacao.Object, mockRepoJogador.Object, mockRepoRelacao.Object,mockServiceRelacao.Object);

            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jC = new Jogador("Peartree","p@gmail.com","euh.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"pP3040");
    

            var  p =  new PedidoIntroducao(jA,jB,jC,"oi","ola");
            var exp = PedidoIntroducaoMapper.toDtoM(p);

            mockRepoPedidoIntroducao.Setup(repo => repo.GetByIdAsync(It.IsAny<PedidoIntroducaoId>())).ReturnsAsync(p);

             var service = new PedidoIntroducaoService(mockUnitOfWork.Object, mockRepoPedidoIntroducao.Object, mockRepoJogador.Object, mockServicoPedidoLigacao.Object);
            var act = await service.GetByIdAsync(p.Id);
            Assert.Equal(exp.Id, act.Id);
        }

        /* [Fact]
        public async void AddAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();

            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry);
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed);
            var jC = new Jogador("Pedro","p@gmail.com","eup.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful);
    
            var  p =  new PedidoIntroducao(jA,jB,jC,"oi","ola");
            var exp = PedidoIntroducaoMapper.toDto(p);

            mockRepoPedidoIntroducao.Setup(repo => repo.AddAsync(p)).ReturnsAsync(p);

            var service = new PedidoIntroducaoService(mockUnitOfWork.Object, mockRepoPedidoIntroducao.Object, mockRepoJogador.Object);
            var act = await service.AddAsync(exp);

            Assert.IsType<String>(act.Id);
        }
        /*[Fact]
        public async void UpdateAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoEstadoEmocional = new Mock<IEstadoEmocionalRepository>();

            var e = new EstadoEmocional(EstadosHumor.Grateful);
            e.ChangeEstadoHumor(EstadosHumor.Fearful);

            EstadoEmocionalDto exp = EstadoEmocionalMapper.toDto(e);

            mockRepoEstadoEmocional.Setup(repo => repo.GetByIdAsync(It.IsAny<EstadoEmocionalId>())).ReturnsAsync(e);

            var service = new EstadoEmocionalService(mockUnitOfWork.Object, mockRepoEstadoEmocional.Object);

            var dto = new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = EstadosHumor.Fearful, Data = e.Data.DH.ToString() };
            var act = await service.UpdateAsync(dto);

            Assert.Equal(exp, act);
        }*/
    }
}