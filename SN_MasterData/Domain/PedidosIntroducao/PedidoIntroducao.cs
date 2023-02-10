using System;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;

namespace SocialNetwork.Domain.PedidosIntroducao
{

    public enum EstadosPedido{
            pendente,
            aprovado,
            recusado
        }
    public class PedidoIntroducao : Entity<PedidoIntroducaoId>, IAggregateRoot
    {
        
        public EstadosPedido EstadoPedido{get; set;}
        public Jogador Jogador{get; private set;} //Jogador A
        public Jogador JogadorIntermedio{get; private set;} //Jogador B
        public Jogador JogadorObjetivo{get; private set;} //Jogador C
        public TextoPedidoIntroducao  MsgIntermedio{get; private set;}
        public TextoPedidoIntroducao MsgObjetivo{get; private set;}
        public DataHora DataPedido{get; private set;} //Data em que o jogador A efetua o pedido de introdução ao jogador B
        public DataHora DataRespostaAoPedido{get; private set;} // Data em que o jogador C aceita ou recusa o pedido do jogador A
        public DataHora DataRespostaAIntroducao{get; private set;} // Data em que o jogador B aceita ou rejeita o pedido do jogador A


        public PedidoIntroducao()
        {
        }

        public PedidoIntroducao(Jogador jog, Jogador jogadorInterm, Jogador jogadorObj, string msgInterm, string msgObj)
        {
            
             if(jogadorInterm == null || jogadorObj == null || msgInterm == null || msgObj == null)
                 throw new BusinessRuleValidationException("Os pedidos de introduçao necessitam de mensagem para o utilizador intermedio e objetivo, e que os utilizadores envolvidos estejam definidos.");
            this.Id = new PedidoIntroducaoId(Guid.NewGuid().ToString());
            this.Jogador = jog;
            this.JogadorIntermedio = jogadorInterm;
            this.JogadorObjetivo = jogadorObj;
            this.MsgIntermedio = new TextoPedidoIntroducao(msgInterm);
            this.MsgObjetivo = new TextoPedidoIntroducao(msgObj);
            this.EstadoPedido = EstadosPedido.pendente;
            this.DataPedido = new DataHora(DateTime.Now);
            this.DataRespostaAIntroducao = new DataHora();
            this.DataRespostaAoPedido = new DataHora();
        }

        public void aprovarPedido(){
            this.EstadoPedido = EstadosPedido.aprovado;
            this.DataRespostaAIntroducao = new DataHora(DateTime.Now);
            this.DataRespostaAoPedido = new DataHora(DateTime.Now);
        }

        public void recusarPedido(){
            this.EstadoPedido = EstadosPedido.recusado;
            this.DataRespostaAIntroducao = new DataHora(DateTime.Now);
            this.DataRespostaAoPedido = new DataHora(DateTime.Now);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PedidoIntroducao p = (PedidoIntroducao)obj;

            return this.Id.Equals(p.Id) && this.Jogador.Equals(p.Jogador) && this.JogadorIntermedio.Equals(p.JogadorIntermedio) && this.JogadorObjetivo.Equals(p.JogadorObjetivo);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode()
                    * 3;
        }
    }
}