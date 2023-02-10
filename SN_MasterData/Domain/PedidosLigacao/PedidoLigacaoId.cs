using System;
using SocialNetwork.Domain.Shared;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.PedidosLigacao
{
    public class PedidoLigacaoId : EntityId
    {
        public PedidoLigacaoId(String value) : base(value)
        {
        }

        public PedidoLigacaoId()
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

        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}