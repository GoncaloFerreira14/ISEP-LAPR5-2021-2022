using System;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    public class PedidoIntroducaoDto
    {
        public string Id { get; set; }
        public string jogadorId { get; set;}
        public string jogadorIntermedioId { get; set;}
        public string jogadorObjetivoId { get; set;}
        public string MsgIntermedio { get; set;}
        public string MsgObjetivo { get; set;}
        public EstadosPedido EstadoPedido { get; set; }
        public string DataPedido{get; set;}
        public string DataRespostaAIntroducao{get; set;}
        public string DataRespostaAoPedido{get; set;}
    }
}