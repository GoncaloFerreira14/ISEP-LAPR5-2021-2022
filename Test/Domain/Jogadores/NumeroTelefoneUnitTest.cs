using Xunit;
using SocialNetwork.Domain.Jogadores;
using System;
namespace Test.Domain.Jogadores
{
   
    public class NumeroTelefoneUnitTest
    {

        [Fact]
        public void ValidarNumeroTelefoneTrue()
        {
            var n = new NumeroTelefone("934997960");
            Assert.True(n.ValidarNumeroTelefone(n.Numero));
        }

        [Fact]
        public void ValidarNumeroTelefoneFalse()
        {
            var n = new NumeroTelefone("933999");
            Assert.False(n.ValidarNumeroTelefone("93"));
        }
    }
}