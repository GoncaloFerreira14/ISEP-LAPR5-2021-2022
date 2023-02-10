using System;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    public enum EstadosHumor
    {
        Joyful,
        Distressed,
        Hopeful,
        Fearful,
        Relieved,
        Disappointed,
        Proud,
        Remorseful,
        Grateful,
        Angry,
        Neutral,

    }


    public class EstadoEmocional : Entity<EstadoEmocionalId>, IAggregateRoot
    {

        public EstadosHumor EstadoHumor { get; set; }
        public DataHora Data { get; private set; }
        public Valor ValorEstado { get; private set; }

        public EstadoEmocional()
        {
            EstadoHumor = EstadosHumor.Neutral;
        }

        public EstadoEmocional(EstadosHumor estadosHumor)
        {
            this.Id = new EstadoEmocionalId(Guid.NewGuid().ToString());
            this.EstadoHumor = (EstadosHumor)estadosHumor;
            this.Data = new DataHora(DateTime.Now);
            this.ValorEstado = new Valor(0.5);
        }

        public void ChangeEstadoHumor(EstadosHumor estadoHumor)
        {
            this.EstadoHumor = estadoHumor;
        }

        public void ChangeData()
        {
            this.Data = new DataHora(DateTime.Now);
        }

        public void ChangeValor(double valor)
        {
            this.ValorEstado = new Valor(valor);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            EstadoEmocional e = (EstadoEmocional)obj;

            return this.Id.Equals(e.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()
                    * 3;
        }

    }

}