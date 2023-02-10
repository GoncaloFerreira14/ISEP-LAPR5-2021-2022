using System;
using System.Collections;
using System.Collections.Generic;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Relacoes;

namespace SocialNetwork.Domain.Jogadores
{
    public class MostrarJogadorDto
    {
        public String Id { get; set; }
        public String Nome{get; set;}
        public String Email{get; set;}
        public String Avatar{get; set;}
        public String  DataNascimento{get; set;}
        public String NumeroTelefone{get;set;}
        public String URLLinkedIn {get; set;}
        public String URLFacebook{get;set;}
        public String DescricaoBreve{get; set;}
        public String Cidade{get; set;}
        public String Pais{get; set;}
        public List<String> ListaTags{get; set;}
        public EstadoEmocional EstadoHumor { get; set; }

        public List<String> ListaRelacoes{get; set;}

        public String Password{get; set;}
        
    }
}