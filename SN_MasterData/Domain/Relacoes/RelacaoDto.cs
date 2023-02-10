using System;
using System.Collections;
using System.Collections.Generic;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Domain.Relacoes
{
    public class RelacaoDto
    {
        public String Id { get; set; }
        
        public int forcaLigacao{get; set;}

        public int forcaRelacao{get; set;}

        public String Data{get; set;}

        public List<String> ListaTags{get; set;}

        public String jogadorAmigoId{get; set;}

        public String jogadorId{get; set;}

    }
}