using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    [ComplexType]
    public class TextoPedidoIntroducao : IValueObject
    {
        public string Texto;

        private TextoPedidoIntroducao()
        {
            Texto = "Sem atributos definidos";
        }

        public TextoPedidoIntroducao(string texto)
        {
            this.Texto = texto;
        }
    }
}