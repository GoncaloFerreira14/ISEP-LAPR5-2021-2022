using Xunit;
using SocialNetwork.Domain.EstadosEmocionais;
namespace Test.Domain.EstadosEmocionais
{
   
    public class EstadoEmocionalUnitTest
    {
        [Fact]
        public void ChangeEstadoEmocional()
        {
            var  estado =  new EstadoEmocional(EstadosHumor.Joyful);
            estado.ChangeEstadoHumor(EstadosHumor.Distressed);
            Assert.Equal(EstadosHumor.Distressed, estado.EstadoHumor);
        }
    }
}