using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    public class EstadoEmocionalId : EntityId
    {

        public EstadoEmocionalId(String value):base(value)
        {

        }

        public EstadoEmocionalId()
        {

        }

        override
        protected  Object createFromString(String text){
            return text;
        }
        override
        public String AsString(){
            return (String) base.Value;
        }
    }
}