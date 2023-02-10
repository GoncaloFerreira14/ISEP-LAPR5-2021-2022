using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Infrastructure.Shared;

namespace SocialNetwork.Infrastructure.EstadosEmocionais
{
    public class EstadoEmocionalRepository : BaseRepository<EstadoEmocional, EstadoEmocionalId>, IEstadoEmocionalRepository
    {
    
        public EstadoEmocionalRepository(SocialNetworkDbContext context):base(context.EstadoEmocional)
        {
           
        }


    }
}