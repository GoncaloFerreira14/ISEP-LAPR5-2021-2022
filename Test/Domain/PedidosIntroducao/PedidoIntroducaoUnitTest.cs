using Xunit;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;
namespace Test.Domain.PedidosIntroducao
{
   
    public class PedidoIntroducaoUnitTest
    {
        [Fact]
        public void aprovarPedido()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jC = new Jogador("Peartree","p@gmail.com","euh.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"pP3040");

            var  pedidoIntroducao =  new PedidoIntroducao(jA,jB,jC,"oi","ola");
            pedidoIntroducao.aprovarPedido();
            Assert.Equal(EstadosPedido.aprovado, pedidoIntroducao.EstadoPedido);
        }

        [Fact]
        public void recusarPedido()
        {
           List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"hH3040");
            var jC = new Jogador("Peartree","p@gmail.com","euh.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"pP3040");

            var  pedidoIntroducao =  new PedidoIntroducao(jA,jB,jC,"oi","ola");
            pedidoIntroducao.recusarPedido();
            Assert.Equal(EstadosPedido.recusado, pedidoIntroducao.EstadoPedido);
        }

        
    }
}