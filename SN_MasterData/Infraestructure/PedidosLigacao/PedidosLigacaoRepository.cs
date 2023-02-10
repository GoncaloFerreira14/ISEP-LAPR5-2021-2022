using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Infrastructure.PedidosLigacao
{
    public class PedidosLigacaoRepository : BaseRepository<PedidoLigacao, PedidoLigacaoId>, IPedidoLigacaoRepository
    {
        SocialNetworkDbContext context;

        public PedidosLigacaoRepository(SocialNetworkDbContext context) : base(context.PedidosLigacao)
        {
            this.context = context;
        }

        public new async Task<List<PedidoLigacao>> GetAllAsync(){
            return await context.PedidosLigacao.Include(p => p.DataPedido).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorObjetivo).ToListAsync();
        }

        public new async Task<PedidoLigacao> GetByIdAsync(PedidoLigacaoId id){
            PedidoLigacao p = await ((DbSet<PedidoLigacao>)base.getObjs()).Where(x => x.Id == id).Include(p => p.DataPedido).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorObjetivo).FirstOrDefaultAsync();
            return p;
        }

        public async Task<List<PedidoLigacao>> GetAllPedidosLigacaoObjetivo(JogadorId id){
            return  await ((DbSet<PedidoLigacao>)base.getObjs()).Where(x => x.JogadorObjetivo.Id == id).Include(p => p.DataPedido).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorObjetivo).ToListAsync();
        }

        public async Task<List<PedidoLigacao>> GetAllPedidosLigacao(JogadorId id){
            return  await ((DbSet<PedidoLigacao>)base.getObjs()).Where(x => x.Jogador.Id == id).Include(p => p.DataPedido).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorObjetivo).ToListAsync();
        }
    }
}