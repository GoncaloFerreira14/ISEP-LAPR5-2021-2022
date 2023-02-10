using System.Collections.Generic;

namespace SocialNetwork.Domain.PedidosIntroducao
{
public static class PedidoIntroducaoMapper
{ 
    public static PedidoIntroducaoDto toDto( PedidoIntroducao p)
    {
        return new PedidoIntroducaoDto { Id = p.Id.AsString(), jogadorId = p.Jogador.Id.AsString(), jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
        jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),  MsgIntermedio = p.MsgIntermedio.Texto.ToString(),MsgObjetivo = p.MsgObjetivo.Texto.ToString(), EstadoPedido = p.EstadoPedido, DataPedido = p.DataPedido.DH.ToString(), DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),DataRespostaAoPedido= p.DataRespostaAoPedido.DH.ToString() };
    }

      public static List<PedidoIntroducaoDto> toDtoList(List<PedidoIntroducao> pedidosIntroducao){
            return pedidosIntroducao.ConvertAll<PedidoIntroducaoDto>(EstadoEmocional => toDto(EstadoEmocional));;
        }

        public static MostrarPedidoIntroducaoDto toDtoM( PedidoIntroducao p)
    {
        return new MostrarPedidoIntroducaoDto { Id = p.Id.AsString(), jogadorId = p.Jogador.Id.AsString(), jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
        jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),  MsgIntermedio = p.MsgIntermedio.Texto.ToString(),MsgObjetivo = p.MsgObjetivo.Texto.ToString(), EstadoPedido = p.EstadoPedido.ToString(), DataPedido = p.DataPedido.DH.ToString(), DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),DataRespostaAoPedido= p.DataRespostaAoPedido.DH.ToString() };
    }

      public static List<MostrarPedidoIntroducaoDto> toDtoListM(List<PedidoIntroducao> pedidosIntroducao){
            return pedidosIntroducao.ConvertAll<MostrarPedidoIntroducaoDto>(EstadoEmocional => toDtoM(EstadoEmocional));;
        }
        /*public static AlterarEstadoIntroducaoDto toAtualizarDTO(Email email, EstadoHumor estadoHumor){

            return new AlterarEstadoIntroducaoDto(email.email, estadoHumor.estadoHumor.ToString(), estadoHumor.dataInsercao.data.ToString());
        }*/
}
}