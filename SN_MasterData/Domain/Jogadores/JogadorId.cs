using System;
using SocialNetwork.Domain.Shared;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.Jogadores
{
    public class JogadorId : EntityId
    {
        [JsonConstructor]
        public JogadorId(Guid value) : base(value)
        {
        }

        public JogadorId(String value):base(value)
        {

        }

        public JogadorId()
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