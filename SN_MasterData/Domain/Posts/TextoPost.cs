using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Posts
{
    [ComplexType]
    public class TextoPost : IValueObject
    {
        public string Texto;

        private TextoPost()
        {
            Texto = "Sem atributos definidos";
        }

        public TextoPost(string texto)
        {
            this.Texto = texto;
        }
    }
}