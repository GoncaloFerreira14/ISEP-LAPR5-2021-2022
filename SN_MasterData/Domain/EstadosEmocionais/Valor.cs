using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    [ComplexType]
    public class Valor : IValueObject
    {
      
        public double Numero;

        private Valor()
        {
            Numero = 0;
        }

        public Valor(double integer)
        {
           this.Numero = integer;
        }

    }
}