using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace SocialNetwork.Infrastructure.Relacoes
{
    public class RelacaoRepository : BaseRepository<Relacao, RelacaoId>, IRelacaoRepository
    {
      
      SocialNetworkDbContext context;
        public RelacaoRepository(SocialNetworkDbContext context):base(context.Relacoes)
        {
            this.context = context;
        }

        public new async Task<List<Relacao>> GetAllAsync(){
            return await context.Relacoes.Include(r => r.ListaTags).Include(r => r.jogador).ThenInclude(r => r.ListaTags)
            .Include(r => r.jogadorAmigo).ThenInclude(r => r.ListaTags).ToListAsync();
        }

        public new async Task<Relacao> GetByIdAsync(RelacaoId id){
            Relacao r = await ((DbSet<Relacao>)base.getObjs()).Where(x => x.Id == id).Include(x => x.ListaTags).Include(x => x.jogador).Include(x => x.jogadorAmigo).FirstOrDefaultAsync();
            return r;
            //return await context.Relacoes.Include(r => r.ListaTags).FirstOrDefaultAsync();
        }

        public async Task<List<Relacao>> GetAllRelacoesJogadorAmigo(JogadorId id){
            return  await ((DbSet<Relacao>)base.getObjs()).Where(x => x.jogadorAmigo.Id == id).Include(x => x.ListaTags).Include(x => x.jogador).Include(x => x.jogadorAmigo).ToListAsync();
        }
        //UC7 PROVISORIOOOOOO
        public void preencherRelacoesPorNivel(int n, List<KeyValuePair<int,RelacaoDto>> listR, JogadorId jogadorId, List<RelacaoDto> listaAux, int x){
            
            x++;
            if(n == 0){
                return;
            }

            foreach (RelacaoDto r in listaAux)
            {
                if(r.jogadorId == jogadorId.AsString()){
                    listR.Add(new KeyValuePair<int,RelacaoDto>(x,r));
                    JogadorId id = new JogadorId(r.jogadorAmigoId);
                    preencherRelacoesPorNivel(n-1,listR,id,listaAux,x);
                }
            }
        }
    }
}