using System;
using SocialNetwork.Domain.Shared;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.Missoes
{

    public class MissaoId : EntityId
    {

        [JsonConstructor]
        public MissaoId(Guid value) : base(value)
        {
        }
        public MissaoId()
        {
        }

        public MissaoId(String value) : base(value)
        {
        }

        override
        protected  Object createFromString(String text){
            return new Guid(text);
        }

        override
        public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return (String) base.Value;
        }

        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}