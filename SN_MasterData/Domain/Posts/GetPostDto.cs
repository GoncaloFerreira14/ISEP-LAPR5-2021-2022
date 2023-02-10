using System;
using System.Collections.Generic;
using SocialNetwork.Domain.Comentarios;

namespace SocialNetwork.Domain.Posts
{
    public class GetPostDto
    {
        public string id { get; set; }
        public string JogadorNome {get; set;}
        public string Data {get; set;}
        public string Texto {get; set;}
        public string Likes {get; set;}
        public string Dislikes {get; set;}
        public List<String> TagsPost{get; set;}
        public List<ComentarioDto> Comentarios{get; set;}
    }
}