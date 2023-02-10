using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class Email : IValueObject
    {
      
        public string Endereco{get;set;}



        private Email()
        {
            this.Endereco = "Sem email atribuído";
        }

        public Email(string email)
        {
          if(!ValidarEmail(email)){
            throw new BusinessRuleValidationException("Email com formato inválido.");}
          this.Endereco = email;
          
        }

       public  bool ValidarEmail(string email)
        {
          try {
           
           var endereco = new System.Net.Mail.MailAddress(email);
             return endereco.Address == email;
            }
          catch {
            return false;
            }
        }
    }
}