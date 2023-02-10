using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    [ComplexType]
    public class DataHora : IValueObject
    {
      
        public DateTime DH;



        public DataHora()
        {
        }

        public DataHora(DateTime dataHora)
        {
           this.DH = dataHora;
        }
    }
}