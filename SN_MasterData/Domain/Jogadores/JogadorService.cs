using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;

namespace SocialNetwork.Domain.Jogadores
{
    public class JogadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJogadorRepository _repo;

        private readonly ITagRepository _repoTags;

        private readonly IRelacaoRepository _repoRelacoes;

        private readonly IPedidoIntroducaoRepository _repoPedidosIntroducao;

        private readonly IPedidoLigacaoRepository _repoPedidosLigacao;

        public JogadorService(IUnitOfWork unitOfWork, IJogadorRepository repo, ITagRepository repoT, IRelacaoRepository repoR, IPedidoIntroducaoRepository repoPI, IPedidoLigacaoRepository repoPL)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoTags = repoT;
            this._repoRelacoes = repoR;
            this._repoPedidosIntroducao = repoPI;
            this._repoPedidosLigacao = repoPL;
        }

        public async Task<List<MostrarJogadorDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<MostrarJogadorDto> listDto = list.ConvertAll<MostrarJogadorDto>(j => new MostrarJogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes(),
                Password = j.Password.Text
            });

            return listDto;
        }

        public async Task<MostrarJogadorDto> GetByIdAsync(JogadorId id)
        {
            var j = await this._repo.GetByIdAsync(id);

            if (j == null)
                return null;


            return new MostrarJogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes(),
                Password = j.Password.Text
            };
        }

        public async Task<MostrarJogadorDto> GetByEmail(string email)
        {
            var j = await this._repo.GetByEmail(email);

            if (j == null)
                return null;


            return new MostrarJogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes(),
                Password = j.Password.Text
            };
        }

        public async Task<JogadorDto> AddAsync(JogadorDto dto)
        {
            List<Tag> tags = new List<Tag>();

            if (dto.ListaTags == null)
            {
                dto.ListaTags = new List<string>();
            }

            foreach (string s in dto.ListaTags)
            {
                Tag tagDb = await this._repoTags.GetByStringAsync(s);
                if (tagDb != null)
                {
                    tags.Add(tagDb);
                }
                else
                {
                    Tag t = new Tag(s);
                    tags.Add(t);
                }
            }
            var j = new Jogador(dto.Nome, dto.Email, dto.Avatar, dto.DataNascimento, dto.NumeroTelefone, dto.URLLinkedIn, dto.URLFacebook, dto.DescricaoBreve, dto.Cidade, dto.Pais, tags, dto.EstadoHumor, dto.Password);

            await this._repo.AddAsync(j);

            await this._unitOfWork.CommitAsync();



            return new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes(),
                Password = j.Password.Text
            };
        }

        public async Task<JogadorDto> DeleteAsync(JogadorId id)
        {
            var j = await this._repo.GetByIdAsync(id);

            if (j == null)
                return null;
            this._repo.Remove(j);
            await this._unitOfWork.CommitAsync();

            return new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            };
        }

        public async Task<List<RelacaoDto>> GetAllRelacoesJogador(JogadorId id)
        {

            var lista = await this._repo.GetAllRelacoesJogador(id);

            if (lista == null)
                return null;

            List<RelacaoDto> listDto = lista.ConvertAll<RelacaoDto>(r => new RelacaoDto { Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(), jogadorId = r.jogador.Id.AsString() });


            return listDto;
        }

        public async Task<MostrarEstadoDto> GetEstadoHumorByJogadorId(JogadorId id)
        {

            var estado = await this._repo.GetEstadoHumorByJogadorId(id);

            if (estado == null)
                return null;

            return new MostrarEstadoDto { Id = estado.Id.AsString(), EstadoHumor = estado.EstadoHumor.ToString(), Data = estado.Data.DH.ToString(), ValorEstado = estado.ValorEstado.Numero };
        }
        public async Task<JogadorDto> UpdateAsync(JogadorDto dto)
        {
            var j = await this._repo.GetByIdAsync(new JogadorId(dto.Id));

            if (j == null)
                return null;

            if (dto.Nome != null && dto.Nome != "")
            {
                j.ChangeNome(dto.Nome);
            }

            if (dto.Email != null && dto.Email != "")
            {
                j.ChangeEmail(dto.Email);
            }

            if (dto.Avatar != null && dto.Avatar != "")
            {
                j.ChangeAvatar(dto.Avatar);
            }

            if (dto.DataNascimento != null && dto.DataNascimento != "")
            {
                j.ChangeData(dto.DataNascimento);
            }

            if (dto.NumeroTelefone != null && dto.NumeroTelefone != "")
            {
                j.ChangeTelefone(dto.NumeroTelefone);
            }

            if (dto.URLLinkedIn != null && dto.URLLinkedIn != "")
            {
                j.ChangeLinkedIn(dto.URLLinkedIn);
            }

            if (dto.URLFacebook != null && dto.URLFacebook != "")
            {
                j.ChangeFacebook(dto.URLFacebook);
            }

            if (dto.DescricaoBreve != null && dto.DescricaoBreve != "")
            {
                j.ChangeDesc(dto.DescricaoBreve);
            }

            if (dto.Cidade != null && dto.Cidade != "")
            {
                j.ChangeCidade(dto.Cidade);
            }

            if (dto.Pais != null && dto.Pais != "")
            {
                j.ChangePais(dto.Pais);
            }

            if (dto.Password != null && dto.Password != "")
            {
                j.ChangePassword(dto.Password);
            }

            List<Tag> lista = new List<Tag>();
            if (dto.ListaTags != null)
            {
                foreach (string s in dto.ListaTags)
                {
                    Tag tagDb = await this._repoTags.GetByStringAsync(s);
                    if (tagDb != null)
                    {
                        lista.Add(tagDb);
                    }
                    else
                    {
                        Tag t = new Tag(s);
                        lista.Add(t);
                    }
                }
                j.changeListaTags(lista);
            }

            await this._unitOfWork.CommitAsync();

            return new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                      ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            };
        }

        //UC7 PROVISORIOOOOO
        public async Task<List<KeyValuePair<int, RelacaoDto>>> GetAllRelacoesPorNivelJogador(JogadorId id, int n)
        {

            var listaAux = await this._repoRelacoes.GetAllAsync();

            List<RelacaoDto> listDto = listaAux.ConvertAll<RelacaoDto>(r => new RelacaoDto { Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(), jogadorId = r.jogador.Id.AsString() });

            List<KeyValuePair<int, RelacaoDto>> listR = new List<KeyValuePair<int, RelacaoDto>>();

            this._repoRelacoes.preencherRelacoesPorNivel(n, listR, id, listDto, 0);

            return listR;
        }

         public async Task<List<LeaderboardDimensaoDto>>GetAllDimensao()
        {

            List<LeaderboardDimensaoDto> listr = new List<LeaderboardDimensaoDto>();
            Dictionary<string,int> r = new Dictionary<string, int>();

            List<Jogador> list = await this._repo.GetAllAsync();
            foreach(Jogador element in list){
                List<KeyValuePair<int,RelacaoDto>> listnivel = await this.GetAllRelacoesPorNivelJogador(element.Id,1);
                r.Add(element.Nome.Text, listnivel.Count);
            }

            var res = r.OrderByDescending(d => d.Value);

            foreach(KeyValuePair<string, int> entry in res)
            {
                LeaderboardDimensaoDto dto = new LeaderboardDimensaoDto { Nome = entry.Key, Dimensao = entry.Value};
                listr.Add(dto);
            }
            return listr;
        }

        public async Task<List<PedidoIntroducaoDto>> GetAllPedidosIntroducao(JogadorId id)
        {

            List<PedidoIntroducao> listaf = new List<PedidoIntroducao>();

            var lista1 = await this._repoPedidosIntroducao.GetAllPedidosIntroducao(id);

            var lista2 = await this._repoPedidosIntroducao.GetAllPedidosIntroducaoIntermedio(id);

            var lista3 = await this._repoPedidosIntroducao.GetAllPedidosIntroducaoObjetivo(id);

            listaf.AddRange(lista1);
            listaf.AddRange(lista2);
            listaf.AddRange(lista3);



            if (listaf == null)
                return null;

            List<PedidoIntroducaoDto> listDto = listaf.ConvertAll<PedidoIntroducaoDto>(p => new PedidoIntroducaoDto
            {
                Id = p.Id.AsString(),
                jogadorId = p.Jogador.Id.AsString(),
                jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
                jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgIntermedio = p.MsgIntermedio.Texto,
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido,
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            });


            return listDto;
        }

        public async Task<List<PedidoLigacaoDto>> GetAllPedidosLigacao(JogadorId id)
        {

            List<PedidoLigacao> listaf = new List<PedidoLigacao>();

            var lista1 = await this._repoPedidosLigacao.GetAllPedidosLigacao(id);

            var lista2 = await this._repoPedidosLigacao.GetAllPedidosLigacaoObjetivo(id);


            listaf.AddRange(lista1);
            listaf.AddRange(lista2);


            if (listaf == null)
                return null;

            List<PedidoLigacaoDto> listDto = listaf.ConvertAll<PedidoLigacaoDto>(p => new PedidoLigacaoDto
            {
                Id = p.Id.AsString(),
                JogadorId = p.Jogador.Id.AsString(),
                JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido,
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            });

            return listDto;
        }

        public async Task<List<RelacaoDto>> GetAllRelacoesJogadorAmigo(JogadorId id)
        {

            List<Relacao> listaf = new List<Relacao>();

            var lista1 = await this._repoRelacoes.GetAllRelacoesJogadorAmigo(id);

            listaf.AddRange(lista1);
            


             if (listaf == null)
                return null;

            List<RelacaoDto> listDto = listaf.ConvertAll<RelacaoDto>(r => new RelacaoDto { Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(), jogadorId = r.jogador.Id.AsString() });


            return listDto;
        }
        public async Task<List<JogadorDto>> GetAllJogadoresByCommonTags(JogadorId id)
        {
            var j = await this._repo.GetByIdAsync(id);
            var list = await this._repo.GetAllAsync();
            var listRel = await this.GetAllRelacoesJogador(id);

            List<string> amigos = new List<string>();
            foreach(RelacaoDto jogadorAmigo in listRel){
                amigos.Add(jogadorAmigo.jogadorAmigoId);
            }

            if (list == null)
                return null;

            //List<RelacaoDto> listRelDto = listRel.ConvertAll<RelacaoDto>(r => new RelacaoDto { Id = r.Id.AsString(), forcaLigacao = r.forcaLigacao.forca, Data = r.DataRelacao.dataRel.ToString(), ListaTags = r.conversaoTagsRelacao(), jogadorAmigoId = r.jogadorAmigo.Id.AsString(), jogadorId = r.jogador.Id.AsString() });
            JogadorDto jogDto = new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            };

            List<JogadorDto> listDto = list.ConvertAll<JogadorDto>(j => new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            });

            SortedDictionary<int, List<JogadorDto>> map = new SortedDictionary<int, List<JogadorDto>>();
            List<JogadorDto> listJogs;

            foreach (JogadorDto jog in listDto)
            {
                if (jog.Id != id.AsString() && !amigos.Contains(jog.Id))
                {
                    int cont = 0;
                    foreach (string tag in jogDto.ListaTags)
                    {
                        if (jog.ListaTags.Contains(tag))
                        {
                            cont++;
                        }
                    }

                    if (map.ContainsKey(cont))
                    {
                        if (map[cont] == null)
                        {
                            listJogs = new List<JogadorDto>();
                        }
                        else
                        {
                            listJogs = map[cont];
                        }
                        listJogs.Add(jog);
                        map[cont] = listJogs;
                    }
                    else
                    {
                        listJogs = new List<JogadorDto>();
                        listJogs.Add(jog);
                        map[cont] = listJogs;
                    }
                }
            }

            List<JogadorDto> listFinalJogs = new List<JogadorDto>();
            foreach (KeyValuePair<int, List<JogadorDto>> pair in map)
            {
                listFinalJogs.AddRange(pair.Value);
            }

            return listFinalJogs;
        }
        public async Task<MostrarJogadorDto> ValidarLogin(Email email, Texto password)
        {
            var j = await this._repo.validarLogin(email, password);

            if (j == null)
                return null;


            return new MostrarJogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                     ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes(),
                Password = j.Password.Text
            };
        }
        public async Task<List<JogadorDto>> PesquisarJogadores(string id, string pesquisa)
        {

            var list = await this._repo.GetAllAsync();
            List<Jogador> jogadores = new List<Jogador>();

            foreach (Jogador z in list)
            {
                if (z.Nome.Text.ToLower().Equals(pesquisa.ToLower()))
                {
                    if (!jogadores.Contains(z))
                        jogadores.Add(z);
                }
            }



            foreach (Jogador s in list)
            {
                if (s.Pais.Text.Equals(pesquisa))
                {
                    if (!jogadores.Contains(s))
                        jogadores.Add(s);
                }
            }



            foreach (Jogador l in list)
            {
                if (l.Cidade.Text.Equals(pesquisa))
                {
                    if (!jogadores.Contains(l))
                        jogadores.Add(l);
                }
            }


            List<JogadorDto> listDto1 = list.ConvertAll<JogadorDto>(j => new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                          ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            });

            List<JogadorDto> listDto = jogadores.ConvertAll<JogadorDto>(j => new JogadorDto
            {
                Id = j.Id.AsString(),
                Nome = j.Nome.Text,
                Email = j.Email.Endereco,
                Avatar = j.Avatar.Text,
                DataNascimento = j.DataNascimento.DataNascimento.ToString(),
                NumeroTelefone = j.NumeroTelefone.Numero,
                URLLinkedIn = j.URLLinkedIn.URL
                                         ,
                URLFacebook = j.URLFacebook.URL,
                DescricaoBreve = j.DescricaoBreve.Text,
                Cidade = j.Cidade.Text,
                Pais = j.Pais.Text,
                ListaTags = j.conversaoTags(),
                EstadoHumor = j.EstadoHumor.EstadoHumor,
                ListaRelacoes = j.getListaRelacoes()
            });


            foreach (JogadorDto l in listDto1)
            {
                if (l.ListaTags.Contains(pesquisa))
                {
                    if (!listDto.Contains(l))
                        listDto.Add(l);
                }
            }



            return listDto;

        }
    }
}