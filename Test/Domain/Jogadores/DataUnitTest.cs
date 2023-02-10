using Xunit;
using SocialNetwork.Domain.Jogadores;
using System;
namespace Test.Domain.Jogadores
{
   
    public class DataUnitTest
    {

        [Fact]
        public void AtualizarTrue()
        {
            var d = new Data("11/09/2001 00:00:00");
            Assert.True(d.Atualizar(d.DataNascimento.ToString()));
        }

        [Fact]
        public void AtualizarFalse()
        {
            var d = new Data("11/09/2019 00:00:00");
            Assert.False(d.Atualizar(d.DataNascimento.ToString()));
        }
    }
}