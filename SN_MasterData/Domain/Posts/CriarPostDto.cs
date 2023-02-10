using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain.Posts
{
    public class CriarPostDto
    {
        public string JogadorId {get; set;}
        public string Data {get; set;}
        public string Texto {get; set;}

        public int Likes {get; set;}
        public int Dislikes {get;set;}
        public List<String> TagsPost{get; set;}
    }
}