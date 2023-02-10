using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Tags
{
    [ComplexType]
    public class TextoTag : IValueObject
    {
      
        public string Text;

        private TextoTag()
        {
            Text = "Sem atributos definidos";
        }

        public TextoTag(string texto)
        {
           this.Text = texto;
        }

    }
}