using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class Inteiro : IValueObject
    {
      
        public int Contador;

        private Inteiro()
        {
            Contador = 0;
        }

        public Inteiro(int integer)
        {
           this.Contador = integer;
        }

    }
}