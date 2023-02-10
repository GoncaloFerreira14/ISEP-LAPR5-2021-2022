using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Posts
{
    public class PostId : EntityId
    {
        public PostId(String value):base(value)
        {
        }
        public PostId()
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