export interface PedidoLigacaoDto {
    id : string;
    jogadorId : string;
    jogadorObjetivoId: string;
    msgObjetivo : string;
    estadoPedido : string;
    dataPedido : string;
    dataRespostaAIntroducao : string;
    dataRespostaAoPedido : string;
    jogadorNome : string;
    jogadorObjetivoNome: string;
}