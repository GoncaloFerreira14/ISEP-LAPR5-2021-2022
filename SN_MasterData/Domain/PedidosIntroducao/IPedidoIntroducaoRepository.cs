using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Jogadores;


namespace SocialNetwork.Domain.PedidosIntroducao
{
    public interface IPedidoIntroducaoRepository : IRepository<PedidoIntroducao,PedidoIntroducaoId>
    {
            new Task<List<PedidoIntroducao>> GetAllAsync();
            new Task<PedidoIntroducao> GetByIdAsync(PedidoIntroducaoId id);

            Task<List<PedidoIntroducao>> GetAllPedidosIntroducao(JogadorId id);

            Task<List<PedidoIntroducao>> GetAllPedidosIntroducaoIntermedio(JogadorId id);

            Task<List<PedidoIntroducao>> GetAllPedidosIntroducaoObjetivo(JogadorId id);
    }
}