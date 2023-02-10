using SocialNetwork.Domain.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;


namespace SocialNetwork.Domain.Jogadores
{
    public interface IJogadorRepository:IRepository<Jogador,JogadorId>
    {
        new Task<List<Jogador>> GetAllAsync();

        new Task<Jogador> GetByIdAsync(JogadorId id);

        Task<Jogador> GetByEmail(string email);

        Task<List<Relacao>> GetAllRelacoesJogador(JogadorId id);

        Task<EstadoEmocional> GetEstadoHumorByJogadorId(JogadorId id);
        Task<Jogador> validarLogin(Email email, Texto password);

    }


}