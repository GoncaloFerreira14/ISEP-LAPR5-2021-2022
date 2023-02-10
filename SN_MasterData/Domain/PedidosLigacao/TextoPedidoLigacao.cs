using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.PedidosLigacao
{
    [ComplexType]
    public class TextoPedidoLigacao : IValueObject
    {
        public string Texto;

        private TextoPedidoLigacao()
        {
            Texto = "Sem atributos definidos";
        }

        public TextoPedidoLigacao(string texto){
            this.Texto = texto;
        }
    }
}