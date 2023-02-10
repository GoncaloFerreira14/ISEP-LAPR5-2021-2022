using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    [ComplexType]
    public class DataHora : IValueObject
    {
      
        public DateTime DH;



        private DataHora()
        {
        }

        public DataHora(DateTime dataHora)
        {
           this.DH = dataHora;
        }
    }
}