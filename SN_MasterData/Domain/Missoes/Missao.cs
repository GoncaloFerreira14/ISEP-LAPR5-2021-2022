using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Missoes
{

    public class Missao : Entity<MissaoId>, IAggregateRoot
    {

        public MissaoId MissaoId { get; private set; }
        public NivelDificulade NivelDificulade { get; private set; }
        public EstadoMissao EstadoMissao { get; private set; }
        public Introducao Introducao { get; private set; }

        public Missao()
        {
        }

        public Missao(MissaoId missaoId, NivelDificulade nivelDificulade, EstadoMissao estadoMissao, Introducao introducao){
            
            //TODO: VERIFICAR SE A INTRODUCAO NAO PODE SER NULL
            if(missaoId == null && nivelDificulade == null && estadoMissao == null)
                throw new BusinessRuleValidationException("As missoes necessitam de id, nivelDificuldade e do seu respetivo estado.");
        
            this.Id = new MissaoId(Guid.NewGuid());
        }
        
    }
}