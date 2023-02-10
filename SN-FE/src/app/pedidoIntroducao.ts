export interface PedidoIntroducaoDto {
    id: string;
    jogadorId: string;
    jogadorIntermedioId: string;
    jogadorObjetivoId: string;
    msgIntermedio: string;
    msgObjetivo: string;
    estadoPedido: string;
    dataPedido: string;
    dataRespostaAIntroducao: string;
    dataRespostaAoPedido: string;
    jogadorNome : string;
    jogadorIntermedioNome : string;
    jogadorObjetivoNome : string;
}
