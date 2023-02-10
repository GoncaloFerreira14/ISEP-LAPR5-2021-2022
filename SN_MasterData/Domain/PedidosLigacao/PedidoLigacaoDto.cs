using System;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.PedidosLigacao;

namespace SocialNetwork.Domain.PedidosLigacao
{
    public class PedidoLigacaoDto
    {
        public string Id { get; set; }
        public string JogadorId { get; set;}
        public string JogadorObjetivoId { get; set;}
        public string MsgObjetivo { get; set;}
        public EstadosPedido EstadoPedido { get; set; }

        public string DataPedido{get; set;}
        public string DataRespostaAoPedido{get; set;}

    }
}