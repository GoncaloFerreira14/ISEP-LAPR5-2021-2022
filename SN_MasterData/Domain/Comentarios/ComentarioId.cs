using System;
using SocialNetwork.Domain.Shared;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.Jogadores
{
    public class ComentarioId : EntityId
    {
        [JsonConstructor]
        public ComentarioId(Guid value) : base(value)
        {
        }

        public ComentarioId(String value):base(value)
        {

        }

        public ComentarioId()
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