using Xunit;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Tags;
using System;
using System.Collections.Generic;
namespace Test.Domain.Jogadores
{
   
    public class JogadorUnitTest
    {

        [Fact]
        public void conversaoTags()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
             listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var dto = new JogadorDto{Id = j.Id.AsString(), Nome = j.Nome.Text, Email = j.Email.Endereco, Avatar = j.Avatar.Text,
                                     DataNascimento = j.DataNascimento.DataNascimento.ToString(), NumeroTelefone = j.NumeroTelefone.Numero, URLLinkedIn = j.URLLinkedIn.URL
                                     , URLFacebook = j.URLFacebook.URL, DescricaoBreve = j.DescricaoBreve.Text, Cidade = j.Cidade.Text, Pais = j.Pais.Text, ListaTags = j.conversaoTags(), EstadoHumor = j.EstadoHumor.EstadoHumor, ListaRelacoes =  j.getListaRelacoes()};
            
            List<String> listTag2 = new List<String>();
            listTag2.Add("Tag1");
             listTag2.Add("Tag2");

            Assert.Equal(listTag2, dto.ListaTags);
        }

         [Fact]
        public void addRelacao()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            
            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            var j2 = new Jogador("Pedro","p@gmail.com","eu.png","2001-09-11","934997951","plinkedIn","pFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"pP3040");

            var r = new Relacao(50,listTag,j2,j);
            List<Relacao> listR = new List<Relacao>();
            listR.Add(r);
            j.addRelacao(r);
            Assert.Equal(listR, j.ListaRelacoes);
        }

        [Fact]
        public void ChangeNome()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeNome("Hugo");
            Assert.Equal("Hugo", j.Nome.Text);
        }

        [Fact]
        public void ChangeEmail()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeEmail("h@gmail.com");
            Assert.Equal("h@gmail.com", j.Email.Endereco);
        }

         [Fact]
        public void ChangeAvatar()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeAvatar("g.png");
            Assert.Equal("g.png", j.Avatar.Text);
        }

         [Fact]
        public void ChangeData()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeData("11/09/2001 00:00:00");
            Assert.Equal("11/09/2001 00:00:00", j.DataNascimento.DataNascimento.ToString());
        }

         [Fact]
        public void ChangeTelefone()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeTelefone("934997951");
            Assert.Equal("934997951", j.NumeroTelefone.Numero);
        }

        [Fact]
        public void ChangeLinkedIn()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeLinkedIn("hlinkedin");
            Assert.Equal("hlinkedin", j.URLLinkedIn.URL);
        }

        [Fact]
        public void ChangeFacebook()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeFacebook("hfacebook");
            Assert.Equal("hfacebook", j.URLFacebook.URL);
        }

         [Fact]
        public void ChangeDesc()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeDesc("oi");
            Assert.Equal("oi", j.DescricaoBreve.Text);
        }

         [Fact]
        public void ChangeCidade()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangeCidade("Lisboa");
            Assert.Equal("Lisboa", j.Cidade.Text);
        }

         [Fact]
        public void ChangePais()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"gG3040");
            
            j.ChangePais("Polonia");
            Assert.Equal("Polonia", j.Pais.Text);
        }

       /*   [Fact]
        public void getListaRelacoes()
        {
            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
             listTag.Add(new Tag("Tag2"));

            var j = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry);
            var j2 = new Jogador("Pedro","p@gmail.com","eu.png","2001-09-11","934997951","plinkedIn","pFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed);
             var r = new Relacao(50,listTag,j2,j);
            List<Relacao> listR = new List<Relacao>();
            listR.Add(r);
            j.addRelacao(r);
            var dto = new JogadorDto{Id = j.Id.AsString(), Nome = j.Nome.Text, Email = j.Email.Endereco, Avatar = j.Avatar.Text,
                                     DataNascimento = j.DataNascimento.DataNascimento.ToString(), NumeroTelefone = j.NumeroTelefone.Numero, URLLinkedIn = j.URLLinkedIn.URL
                                     , URLFacebook = j.URLFacebook.URL, DescricaoBreve = j.DescricaoBreve.Text, Cidade = j.Cidade.Text, Pais = j.Pais.Text, ListaTags = j.conversaoTags(), EstadoHumor = j.EstadoHumor.EstadoHumor, ListaRelacoes =  j.getListaRelacoes()};
            
           

            List<String> listTag2 = new List<String>();
            listTag2.Add("Tag1");
             listTag2.Add("Tag2");
             List<String> listTR2 = new List<String>();
             listTR2.Add("15860975-fa6f-4996-9194-aab8d3914699");

            Assert.Equal(listTR2, dto.ListaRelacoes);
        }*/
    }
}