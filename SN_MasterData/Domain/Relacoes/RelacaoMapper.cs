using System.Collections.Generic;

namespace SocialNetwork.Domain.Relacoes
{
public static class RelacaoMapper
{ 
    public static RelacaoDto toDto( Relacao r)
    {
        return new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
    }

      public static List<RelacaoDto> toDtoList(List<Relacao> relacoes){
            return relacoes.ConvertAll<RelacaoDto>(Relacao => toDto(Relacao));;
        }
}
}