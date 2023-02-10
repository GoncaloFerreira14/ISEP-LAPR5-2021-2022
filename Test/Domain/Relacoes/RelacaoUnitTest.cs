using Xunit;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;
using System;
namespace Test.Domain.Relacoes
{
   
    public class RelacaoUnitTest
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
        public const string PASS = "gG3040";
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
        public void changeForcaLigacao()
        {
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
            Relacao  r =  new Relacao(20,ListaTagsR,j1,j2);
            r.changeForcaLigacao(12);
            Assert.Equal(12, r.forcaLigacao.forca);
        }

        [Fact]
        public void changeListaTags()
        {
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


            List<Tag> novasTags = new List<Tag>();
            Tag t7 = new Tag("viajar");
            Tag t8 = new Tag("dormir");
            novasTags.Add(t7);
            novasTags.Add(t8);
            Jogador j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,EstadosHumor.Angry,PASS);
            Jogador j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);
            Relacao  r =  new Relacao(20,ListaTagsR,j1,j2);
            r.changeListaTags(novasTags);
            Assert.Equal(novasTags, r.ListaTags);
        }

        [Fact]
        public void changeData()
        {
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
            Relacao  r =  new Relacao(20,ListaTagsR,j1,j2);
            r.changeData();
            Assert.Equal(DateTime.Now.Second, r.DataRelacao.dataRel.Second);
        }

        [Fact]
        public void conversaoTagsRelacao()
        {
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

            List<string> listaS = new List<string>();

            List<string> listaR = new List<string>();

            listaR.Add("telemovel");
            listaR.Add("roupa");

            Jogador j1 = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,EstadosHumor.Angry,PASS);
            Jogador j2 = new Jogador(NOME2,EMAIL2,AVATAR2,DATANASCIMENTO2,NUMEROTELEFONE2,URLLINKEDIN2,URLFACEBOOK2,DESCRICAOBREVE2,CIDADE2,PAIS2,ListaTags2,EstadosHumor.Proud,PASS2);
            Relacao  r =  new Relacao(20,ListaTagsR,j1,j2);
            listaS = r.conversaoTagsRelacao();
            Assert.Equal(listaR, listaS);
        }
        
    }
}