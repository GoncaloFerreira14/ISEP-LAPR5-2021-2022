using System;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Domain.PedidosLigacao
{

    public enum EstadosPedido{
            pendente,
            aceitado,
            recusado
        }

    public class PedidoLigacao : Entity<PedidoLigacaoId>, IAggregateRoot
    {
        public EstadosPedido EstadoPedido;
        public Jogador Jogador {get; private set;} //Jogador A
        public Jogador JogadorObjetivo {get; private set;} //Jogador C
        public TextoPedidoLigacao MsgObjetivo {get; private set;}

        public DataHora DataPedido {get; private set;}   //Data em que o jogador A efetua o pedido de ligaçao para o jogador C

        public DataHora DataRespostaAoPedido {get; private set;} // Data em que o jogador C responde ao pedido de ligacao

        public PedidoLigacao()
        {
        }

        public PedidoLigacao(Jogador jog, Jogador jogadorObj, string msgObj)
        {
            if(jogadorObj == null || msgObj == null)
                throw new BusinessRuleValidationException("Os pedidos de ligacao necessitam de mensagem para o utilizador objetivo, e que os utilizadores envolvidos estejam definidos.");
            this.Id = new PedidoLigacaoId(Guid.NewGuid().ToString());
            this.Jogador = jog;
            this.JogadorObjetivo = jogadorObj;
            this.MsgObjetivo = new TextoPedidoLigacao(msgObj);
            this.EstadoPedido = EstadosPedido.pendente;
            this.DataPedido = new DataHora(DateTime.Now);
            this.DataRespostaAoPedido = new DataHora();
        }

        public void aceitarPedido()
        {
            this.EstadoPedido = EstadosPedido.aceitado;
        }

        public void recusarPedido()
        {
            this.EstadoPedido = EstadosPedido.recusado;
        }

         public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PedidoLigacao p = (PedidoLigacao)obj;

            return this.Id.Equals(p.Id) && this.Jogador.Equals(p.Jogador) && this.JogadorObjetivo.Equals(p.JogadorObjetivo);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()
                    * 3;
        }
    }
}