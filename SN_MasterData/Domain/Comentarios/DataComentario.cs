using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialNetwork.Domain.Comentarios
{

    [ComplexType]
    public class DataComentario : IValueObject
    {
        public DateTime dataComentario;

        public DataComentario()
        {
        }

        public DataComentario(DateTime data)
        {
            this.dataComentario = data;
        }

    }
}