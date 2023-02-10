using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialNetwork.Domain.Relacoes
{
   
    [ComplexType]
    public class DataRelacao : IValueObject
    {
        public DateTime dataRel{get; set;}
        
        public DataRelacao(){
        }
        
        public DataRelacao(DateTime data){
            this.dataRel = data;
        }

    }
}