using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class NumeroTelefone : IValueObject
    {
      
        public string Numero;



        private NumeroTelefone()
        {
            this.Numero = "Sem número de telefone atribuído";
        }

        public NumeroTelefone(string numeroTelefone)
        {
           if(ValidarNumeroTelefone(numeroTelefone)){ 
           this.Numero = numeroTelefone;
           }
        }

        public  bool ValidarNumeroTelefone(string numeroTelefone)
        {
            return Regex.Match(numeroTelefone, @"^([0-9]{4,14})$").Success;
        }
    }
}