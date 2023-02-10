using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Comentarios
{
    [ComplexType]
    public class TextoComentario : IValueObject
    {
        public string Texto;

        private TextoComentario()
        {
            Texto = "Sem atributos definidos";
        }

        public TextoComentario(string texto)
        {
            this.Texto = texto;
        }
    }
}