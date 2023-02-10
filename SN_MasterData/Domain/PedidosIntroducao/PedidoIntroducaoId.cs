using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    public class PedidoIntroducaoId : EntityId
    {
        public PedidoIntroducaoId(String value):base(value)
        {
        }
        public PedidoIntroducaoId()
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