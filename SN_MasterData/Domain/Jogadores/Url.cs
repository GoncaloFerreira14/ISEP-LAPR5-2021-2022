using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class Url : IValueObject
    {
      
        public string URL;

        private Url()
        {
        }

        public Url(string url)
        {
           this.URL = url;
        }

    }
}