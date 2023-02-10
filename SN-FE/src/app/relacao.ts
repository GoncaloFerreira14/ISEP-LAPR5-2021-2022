export interface RelacaoDto {
    id: string;
    forcaLigacao: number;
    forcaRelacao: number;
    data: string;
    listaTags: Array<string>;
    jogadorId: string;
    jogadorAmigoId: string;
    jogadorAmigoNome: string;
}
