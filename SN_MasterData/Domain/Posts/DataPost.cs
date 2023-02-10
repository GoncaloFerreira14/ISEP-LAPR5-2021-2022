using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialNetwork.Domain.Posts
{

    [ComplexType]
    public class DataPost : IValueObject
    {
        public DateTime dataPost { get; set; }

        public DataPost()
        {
        }

        public DataPost(DateTime data)
        {
            this.dataPost = data;
        }

    }
}