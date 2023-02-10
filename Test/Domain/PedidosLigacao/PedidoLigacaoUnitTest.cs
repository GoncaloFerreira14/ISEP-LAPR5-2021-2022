using Xunit;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;
namespace Test.Domain.PedidosLIgacao{

    public class PedidoLigacaoUnitTest
    {
        [Fact]
        public void aprovarPedido()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"pP3040");

            var  pedidoLigacao =  new PedidoLigacao(jA,jB,"oi");
            pedidoLigacao.aceitarPedido();
            Assert.Equal(EstadosPedido.aceitado, pedidoLigacao.EstadoPedido);
        }

        [Fact]
        public void recusarPedido()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");

            var  pedidoLigacao =  new PedidoLigacao(jA,jB,"oi");
            pedidoLigacao.recusarPedido();
            Assert.Equal(EstadosPedido.recusado, pedidoLigacao.EstadoPedido);
        }
        }
}