using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Missoes
{
    [ComplexType]
    public class NivelDificulade : IValueObject
    {

        public int NivelDif;

        private NivelDificulade()
        {
        }

        public NivelDificulade(int niveldif)
        {
            if( niveldif <= 0 )
                throw new BusinessRuleValidationException("O nivel de dificuldade tem de ser superior a 0");
            this.NivelDif = niveldif;
        }

    }
}