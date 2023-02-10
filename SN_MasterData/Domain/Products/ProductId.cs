using System;
using SocialNetwork.Domain.Shared;
using Newtonsoft.Json;

namespace SocialNetwork.Domain.Products
{
    public class ProductId : EntityId
    {
        [JsonConstructor]
        public ProductId(Guid value) : base(value)
        {
        }

        public ProductId()
        {
        }

        public ProductId(String value) : base(value)
        {
        }

        override
        protected  Object createFromString(String text){
            return new Guid(text);
        }
        
        override
        public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }
        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}