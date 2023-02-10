using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.PedidosLigacao;

namespace SocialNetwork.Domain.PedidosIntroducao
{
    public class PedidoIntroducaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoIntroducaoRepository _repo;

        private readonly IJogadorRepository _repoJogadores;

        private readonly PedidoLigacaoService plServ;


        public PedidoIntroducaoService(IUnitOfWork unitOfWork, IPedidoIntroducaoRepository repo, IJogadorRepository repoJ, PedidoLigacaoService plServ)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoJogadores = repoJ;
            this.plServ = plServ;
        }

        public async Task<List<MostrarPedidoIntroducaoDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<MostrarPedidoIntroducaoDto> listDto = list.ConvertAll<MostrarPedidoIntroducaoDto>(p => new MostrarPedidoIntroducaoDto
            {
                Id = p.Id.AsString(),
                jogadorId = p.Jogador.Id.AsString(),
                jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
                jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgIntermedio = p.MsgIntermedio.Texto,
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido.ToString(),
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            });

            return listDto;
        }

        public async Task<MostrarPedidoIntroducaoDto> GetByIdAsync(PedidoIntroducaoId id)
        {
            var p = await this._repo.GetByIdAsync(id);

            if (p == null)
                return null;


            return new MostrarPedidoIntroducaoDto
            {
                Id = p.Id.AsString(),
                jogadorId = p.Jogador.Id.AsString(),
                jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
                jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgIntermedio = p.MsgIntermedio.Texto,
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido.ToString(),
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            };

        }

        public async Task<PedidoIntroducaoDto> AddAsync(PedidoIntroducaoDto dto)
        {
            JogadorId jogId = new JogadorId(dto.jogadorId);
            JogadorId jogIntermId = new JogadorId(dto.jogadorIntermedioId);
            JogadorId jogObjId = (new JogadorId(dto.jogadorObjetivoId));

            Jogador j = await this._repoJogadores.GetByIdAsync(jogId);
            Jogador jIntermedio = await this._repoJogadores.GetByIdAsync(jogIntermId);
            Jogador jObjetivo = await this._repoJogadores.GetByIdAsync(jogObjId);

            var p = new PedidoIntroducao(j, jIntermedio, jObjetivo, dto.MsgIntermedio,
             dto.MsgObjetivo);

            await this._repo.AddAsync(p);

            await this._unitOfWork.CommitAsync();


            return new PedidoIntroducaoDto
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
            };
        }

        public async Task<PedidoIntroducaoDto> DeleteAsync(PedidoIntroducaoId id)
        {
            var p = await this._repo.GetByIdAsync(id);

            if (p == null)
                return null;
            this._repo.Remove(p);
            await this._unitOfWork.CommitAsync();

            return new PedidoIntroducaoDto
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
            };
        }

        public async Task<List<MostrarPedidoIntroducaoDto>> GetAllPedidoIntroducaoJogador(string id)
        {

            var list = await this._repo.GetAllAsync();
            List<PedidoIntroducao> listFinal = new List<PedidoIntroducao>();

            if (list == null)
                return null;

            foreach (PedidoIntroducao pedido in list)
            {
                if (pedido.JogadorIntermedio.Id.AsString().CompareTo(id) == 0)
                {
                    listFinal.Add(pedido);
                }
            }

            List<MostrarPedidoIntroducaoDto> listDto = listFinal.ConvertAll<MostrarPedidoIntroducaoDto>(p => new MostrarPedidoIntroducaoDto
            {
                Id = p.Id.AsString(),
                jogadorId = p.Jogador.Id.AsString(),
                jogadorIntermedioId = p.JogadorIntermedio.Id.AsString(),
                jogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgIntermedio = p.MsgIntermedio.Texto,
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido.ToString(),
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAIntroducao = p.DataRespostaAIntroducao.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            });

            return listDto;
        }
        public async Task<PedidoIntroducaoDto> UpdateAsync(PedidoIntroducaoDto dto)
        {
            var p = await this._repo.GetByIdAsync(new PedidoIntroducaoId(dto.Id));

            if (dto.EstadoPedido.Equals(EstadosPedido.aprovado))
            {
                p.aprovarPedido();
                PedidoLigacaoDto pldto = new PedidoLigacaoDto
                {
                    JogadorId = dto.jogadorId,
                    JogadorObjetivoId = dto.jogadorObjetivoId,
                    MsgObjetivo = dto.MsgObjetivo,
                };
                await plServ.AddAsync(pldto);
            }

            if (dto.EstadoPedido.Equals(EstadosPedido.recusado))
            {
                p.recusarPedido();
            }

            await this._unitOfWork.CommitAsync();

            return new PedidoIntroducaoDto
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
            };
        }
    }
}