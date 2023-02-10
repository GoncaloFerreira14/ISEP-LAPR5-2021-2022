using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class Texto : IValueObject
    {
      
        public string Text;

        private Texto()
        {
            Text = "Sem atributos definidos";
        }

        public Texto(string texto)
        {
           this.Text = texto;
        }

}
}