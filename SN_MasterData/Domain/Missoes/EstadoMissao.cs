using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Missoes
{

    public class EstadoMissao : IValueObject
    {

        public enum EstadosMissao
        {
            Incompleta,
            Completa
        }

        public EstadosMissao Estado;

        public EstadoMissao(){
            this.Estado = EstadosMissao.Incompleta;
        }

        public void CompletarMissao(){
            this.Estado = EstadosMissao.Completa;
        }
    }
}