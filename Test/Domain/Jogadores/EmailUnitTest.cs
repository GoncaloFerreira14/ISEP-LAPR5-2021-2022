using Xunit;
using SocialNetwork.Domain.Jogadores;
using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test.Domain.Jogadores
{
   
    public class EmailUnitTest
    {

        [Fact]
        public void ValidarEmailTrue()
        {
            var e = new Email("g@gmail.com");
            Assert.True(e.ValidarEmail(e.Endereco));
        }

         [Fact]
        public void ValidarEmailFalse()
        {
           bool success = false;
            
            try{
                var e = new Email("ggmailcom");
                success = true;
            }catch{
                success = false;
            }

            Assert.False(success);
        }
    }
}