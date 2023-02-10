using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain.Comentarios
{
    public class ComentarioDto
    {
        public string PostId{get;set;}
        public string JogadorId { get; set; }
        public string Texto {get; set;}
        public string Data {get; set;}
    }
}