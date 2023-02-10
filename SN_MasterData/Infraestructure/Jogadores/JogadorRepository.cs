using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Infrastructure.Jogadores
{
    public class JogadorRepository : BaseRepository<Jogador, JogadorId>, IJogadorRepository
    {
      
      SocialNetworkDbContext context;
        public JogadorRepository(SocialNetworkDbContext context):base(context.Jogadores)
        {
            this.context = context;
        }

        public new async Task<List<Jogador>> GetAllAsync(){
            //await context.Jogadores.Include(e => e.ListaTags).ToListAsync();
            return await context.Jogadores.Include(e => e.EstadoHumor).Include(e => e.ListaRelacoes).Include(e => e.ListaTags).ToListAsync();
        }

        public new async Task<Jogador> GetByIdAsync(JogadorId id){
            Jogador r = await ((DbSet<Jogador>)base.getObjs()).Where(x => x.Id == id).Include(x => x.ListaTags).Include(x => x.EstadoHumor).Include(x =>x.ListaRelacoes).FirstOrDefaultAsync();
            //await context.Jogadores.Include(e => e.ListaTags).FirstOrDefaultAsync();
            //return await context.Jogadores.Include(e => e.EstadoHumor).FirstOrDefaultAsync();
            return r;
        }

        public async Task<Jogador> GetByEmail(string email){
            Jogador r = await ((DbSet<Jogador>)base.getObjs()).Where(x => x.Email.Endereco == email).Include(x => x.ListaTags).Include(x => x.EstadoHumor).Include(x =>x.ListaRelacoes).FirstOrDefaultAsync();
            return r;
        }

        public async Task<List<Relacao>> GetAllRelacoesJogador(JogadorId id){
            Jogador j = await ((DbSet<Jogador>)base.getObjs()).Where(x => x.Id == id).Include(x => x.ListaRelacoes).ThenInclude(x => x.ListaTags)
            .Include(x => x.ListaRelacoes).ThenInclude(x => x.jogadorAmigo).FirstOrDefaultAsync();
            return j.ListaRelacoes;
        }

         
        public async Task<EstadoEmocional> GetEstadoHumorByJogadorId(JogadorId id){

            var jogador = await context.Jogadores.Where(j => j.Id == id)
                                            .Include(j => j.EstadoHumor).FirstOrDefaultAsync();

            EstadoEmocional estado = jogador.EstadoHumor;

            return estado;
        }
         public async Task<Jogador> validarLogin(Email email, Texto password){
            return await ((DbSet<Jogador>)base.getObjs()).Where(x => x.Email.Endereco == email.Endereco && x.Password.Text == password.Text).Include(x => x.ListaTags).Include(x=> x.ListaRelacoes).Include(x=>x.EstadoHumor).FirstOrDefaultAsync();
        }

    }
}