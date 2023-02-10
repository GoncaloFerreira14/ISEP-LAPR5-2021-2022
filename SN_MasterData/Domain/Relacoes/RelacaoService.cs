using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Jogadores;
using System.Linq;

namespace SocialNetwork.Domain.Relacoes
{
    public class RelacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelacaoRepository _repo;

        private readonly IJogadorRepository _repoJogadores;

        private readonly ITagRepository _repoTags;

        public RelacaoService(IUnitOfWork unitOfWork, IRelacaoRepository repo, ITagRepository repoT, IJogadorRepository repoJ)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoTags = repoT;
            this._repoJogadores = repoJ;
        }

        public async Task<List<RelacaoDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<RelacaoDto> listDto = list.ConvertAll<RelacaoDto>( r => new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()});

            return listDto;
        }

        public async Task<RelacaoDto> GetByIdAsync(RelacaoId id)
        {
            var r = await this._repo.GetByIdAsync(id);

            if(r == null)
                return null;
            return new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
        }

        public async Task<RelacaoDto> AddAsync(RelacaoDto dto)
        {
            List<Tag> tags = new List<Tag>();

            if(dto.ListaTags.Count != 0){
                foreach (string s in dto.ListaTags)
            {
                Tag tagDb = await this._repoTags.GetByStringAsync(s);
                if(tagDb != null){
                    tags.Add(tagDb);
                }else{
                    Tag t = new Tag(s);
                    tags.Add(t);
                }
            }
            }

            JogadorId idAmigo = new JogadorId(dto.jogadorAmigoId);
            JogadorId idJogador = new JogadorId(dto.jogadorId);
            Jogador jamigo = await this._repoJogadores.GetByIdAsync(idAmigo);
            Jogador j = await this._repoJogadores.GetByIdAsync(idJogador);
            
            var r = new Relacao(dto.forcaLigacao,tags, jamigo, j);
            j.addRelacao(r);
            await this._repo.AddAsync(r);

            await this._unitOfWork.CommitAsync();

            return new RelacaoDto {Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
        }


        

        public async Task<List<LeaderboardFortalezaDto>> GetAllFortaleza()
        {
            Dictionary<string,int> r = new Dictionary<string, int>();
            List<Jogador> list = await this._repoJogadores.GetAllAsync();
            List<LeaderboardFortalezaDto> listr = new List<LeaderboardFortalezaDto>();
            foreach(Jogador element in list){
                int cont = 0;
                foreach(Relacao rel in element.ListaRelacoes){
                    cont = cont + rel.forcaLigacao.forca;
                }
                r.Add(element.Nome.Text,cont);
            }

            var res = r.OrderByDescending(d => d.Value);

            foreach(KeyValuePair<string, int> entry in res)
            {
                LeaderboardFortalezaDto dto = new LeaderboardFortalezaDto { Nome = entry.Key, Fortaleza = entry.Value};
                listr.Add(dto);
            }
            return listr;
        }


        public async Task<RelacaoDto> DeleteAsync(RelacaoId id)
        {
            var r = await this._repo.GetByIdAsync(id); 

            if (r == null)
                return null;
            this._repo.Remove(r);
            await this._unitOfWork.CommitAsync();


            return new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
        }

        public async Task<RelacaoDto> UpdateAsync(RelacaoDto dto)
        {
            var r = await this._repo.GetByIdAsync(new RelacaoId(dto.Id)); 

            if (r == null)
                return null;   
        
             if (dto.forcaLigacao != 0 ){
                r.changeForcaLigacao(dto.forcaLigacao);
            }
            List<Tag> lista = new List<Tag>();
             if (dto.ListaTags != null ){
                 foreach (string s in dto.ListaTags)
                 {
                    Tag tagDb = await this._repoTags.GetByStringAsync(s);
                    if(tagDb != null){
                        lista.Add(tagDb);
                    }else{
                        Tag t = new Tag(s);
                        lista.Add(t);
                    }
                 }
                r.changeListaTags(lista);
            } 

            r.changeData();
            
            await this._unitOfWork.CommitAsync();

           return new RelacaoDto{Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, forcaRelacao = r.forcaRelacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(),  jogadorId = r.jogador.Id.AsString()};
        }   
    }
}