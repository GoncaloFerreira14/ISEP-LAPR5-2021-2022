using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Tags
{
    public class TagId : EntityId
    {

        public TagId(String value):base(value)
        {

        }

        public TagId()
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