using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Infrastructure.PedidosIntroducao
{
    public class PedidosIntroducaoRepository : BaseRepository<PedidoIntroducao, PedidoIntroducaoId>, IPedidoIntroducaoRepository
    {
        SocialNetworkDbContext context;

        public PedidosIntroducaoRepository(SocialNetworkDbContext context) : base(context.PedidosIntroducao)
        {
            this.context = context;

        }

        public new async Task<List<PedidoIntroducao>> GetAllAsync(){
            return await context.PedidosIntroducao.Include(p => p.DataRespostaAIntroducao).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorIntermedio).Include(p => p.JogadorObjetivo).ToListAsync();
        }

        public async Task<List<PedidoIntroducao>> GetAllPedidosIntroducao(JogadorId id){
            return  await ((DbSet<PedidoIntroducao>)base.getObjs()).Where(x => x.Jogador.Id == id).Include(p => p.DataRespostaAIntroducao).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorIntermedio).Include(p => p.JogadorObjetivo).ToListAsync();
        }

        public async Task<List<PedidoIntroducao>> GetAllPedidosIntroducaoIntermedio(JogadorId id){
            return  await ((DbSet<PedidoIntroducao>)base.getObjs()).Where(x => x.JogadorIntermedio.Id == id).Include(p => p.DataRespostaAIntroducao).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorIntermedio).Include(p => p.JogadorObjetivo).ToListAsync();
        }

        public async Task<List<PedidoIntroducao>> GetAllPedidosIntroducaoObjetivo(JogadorId id){
            return  await ((DbSet<PedidoIntroducao>)base.getObjs()).Where(x => x.JogadorObjetivo.Id == id).Include(p => p.DataRespostaAIntroducao).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorIntermedio).Include(p => p.JogadorObjetivo).ToListAsync();
        }
        public new async Task<PedidoIntroducao> GetByIdAsync(PedidoIntroducaoId id){
            PedidoIntroducao p = await ((DbSet<PedidoIntroducao>)base.getObjs()).Where(x => x.Id == id).Include(p => p.DataRespostaAIntroducao).Include(p => p.DataRespostaAoPedido).Include(p => p.Jogador).Include(p => p.JogadorIntermedio).Include(p => p.JogadorObjetivo).FirstOrDefaultAsync();
            return p;
        }
    }
}