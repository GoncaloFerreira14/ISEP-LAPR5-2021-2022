using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Relacoes;
using System.Collections.Generic;


namespace SocialNetwork.Domain.Tags
{
    
    public class Tag : Entity<TagId>, IAggregateRoot
    {
      
        public TextoTag TagJM {get; set;}

        public List<Jogador> Listajogadores{get; set;}

        public List<Relacao> Listarelacoes{get; set;}

        private Tag()
        {
        }

        public Tag(string tag)
        {
            if(!Regex.Match(tag, @"^([a-z-A-Z-0-9]{1,255})$").Success)
                throw new BusinessRuleValidationException("Tag com formato inválido.");
            this.Id = new TagId(Guid.NewGuid().ToString());
            this.TagJM = new TextoTag(tag);
        }
    }
}