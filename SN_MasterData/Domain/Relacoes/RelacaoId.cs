using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Relacoes
{
    public class RelacaoId : EntityId
    {
        public RelacaoId(String value):base(value)
        {

        }

        public RelacaoId()
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