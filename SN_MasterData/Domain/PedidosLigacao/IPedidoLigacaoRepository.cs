using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Jogadores;


namespace SocialNetwork.Domain.PedidosLigacao
{
    public interface IPedidoLigacaoRepository : IRepository<PedidoLigacao,PedidoLigacaoId>
    {
            new Task<List<PedidoLigacao>> GetAllAsync();
            new Task<PedidoLigacao> GetByIdAsync(PedidoLigacaoId id);
            Task<List<PedidoLigacao>> GetAllPedidosLigacao(JogadorId id);

            Task<List<PedidoLigacao>> GetAllPedidosLigacaoObjetivo(JogadorId id);
    }
}