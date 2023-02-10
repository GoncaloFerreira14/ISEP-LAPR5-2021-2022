using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Jogadores;


namespace SocialNetwork.Domain.Relacoes
{
    public interface IRelacaoRepository:IRepository<Relacao,RelacaoId>
    {
            new Task<List<Relacao>> GetAllAsync();
            new Task<Relacao> GetByIdAsync(RelacaoId id);
            Task<List<Relacao>> GetAllRelacoesJogadorAmigo(JogadorId id);
            void preencherRelacoesPorNivel(int n, List<KeyValuePair<int,RelacaoDto>> listR, JogadorId jogadorId, List<RelacaoDto> listaAux, int x);
    }
}