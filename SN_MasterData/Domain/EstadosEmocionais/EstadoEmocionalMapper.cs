using System.Collections.Generic;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    public static class EstadoEmocionalMapper
    { 
        public static EstadoEmocionalDto toDto( EstadoEmocional e)
        {
            return new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = e.EstadoHumor, Data = e.Data.DH.ToString(), ValorEstado = e.ValorEstado.Numero };
        }

        public static List<EstadoEmocionalDto> toDtoList(List<EstadoEmocional> estadoEmocionals){
            return estadoEmocionals.ConvertAll<EstadoEmocionalDto>(EstadoEmocional => toDto(EstadoEmocional));;
        }
    }
}