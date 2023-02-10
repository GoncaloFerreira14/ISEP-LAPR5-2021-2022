using System.Collections.Generic;

namespace SocialNetwork.Domain.PedidosLigacao
{
public static class PedidoLigacaoMapper
{ 
    public static PedidoLigacaoDto toDto(PedidoLigacao p)
    {
        return new PedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido, DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() };
    }

      public static List<PedidoLigacaoDto> toDtoList(List<PedidoLigacao> pedidosLigacao){
            return pedidosLigacao.ConvertAll<PedidoLigacaoDto>(PedidoLigacao => toDto(PedidoLigacao));;
        }

         public static MostrarPedidoLigacaoDto toDtoM(PedidoLigacao p)
    {
        return new MostrarPedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido.ToString(), DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() };
    }

      public static List<MostrarPedidoLigacaoDto> toDtoListM(List<PedidoLigacao> pedidosLigacao){
            return pedidosLigacao.ConvertAll<MostrarPedidoLigacaoDto>(PedidoLigacao => toDtoM(PedidoLigacao));;
        }
}
}