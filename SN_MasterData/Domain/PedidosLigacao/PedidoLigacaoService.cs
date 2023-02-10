using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Relacoes;

namespace SocialNetwork.Domain.PedidosLigacao
{
    public class PedidoLigacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoLigacaoRepository _repo;

        private readonly IJogadorRepository _repoJogadores;

        private readonly IRelacaoRepository _repoRelacao;

        private readonly RelacaoService rService;


        public PedidoLigacaoService(IUnitOfWork unitOfWork, IPedidoLigacaoRepository repo, IJogadorRepository repoJ, IRelacaoRepository repoR, RelacaoService rS)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoJogadores = repoJ;
            this._repoRelacao = repoR;
            this.rService = rS;
        }

        public async Task<List<MostrarPedidoLigacaoDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<MostrarPedidoLigacaoDto> listDto = list.ConvertAll<MostrarPedidoLigacaoDto>( p => new MostrarPedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido.ToString(), DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() });

            return listDto;
        }

        public async Task<MostrarPedidoLigacaoDto> GetByIdAsync(PedidoLigacaoId id)
        {
            var p = await this._repo.GetByIdAsync(id);
            
            if(p == null)
                return null;


            return new MostrarPedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido.ToString(), DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() };

        }

        public async Task<PedidoLigacaoDto> AddAsync(PedidoLigacaoDto dto)
        {
            Jogador j = await this._repoJogadores.GetByIdAsync(new JogadorId(dto.JogadorId));
            Jogador jObjetivo = await this._repoJogadores.GetByIdAsync(new JogadorId(dto.JogadorObjetivoId));

            var p = new PedidoLigacao(j, jObjetivo, dto.MsgObjetivo);

            await this._repo.AddAsync(p);

            await this._unitOfWork.CommitAsync();

            
            return new PedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido, DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() };
        }

        public async Task<PedidoLigacaoDto> DeleteAsync(PedidoLigacaoId id)
        {
            var p = await this._repo.GetByIdAsync(id); 

            if (p == null)
                return null;               
            this._repo.Remove(p);
            await this._unitOfWork.CommitAsync();

           return new PedidoLigacaoDto{Id = p.Id.AsString(), JogadorId = p.Jogador.Id.AsString(),
             JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
             MsgObjetivo = p.MsgObjetivo.Texto, EstadoPedido = p.EstadoPedido, DataPedido = p.DataPedido.DH.ToString(),DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString() };
        }

        public async Task<PedidoLigacaoDto> UpdateAsync(PedidoLigacaoDto dto)
        {
            var p = await this._repo.GetByIdAsync(new PedidoLigacaoId(dto.Id));

            if (dto.EstadoPedido.Equals(EstadosPedido.aceitado))
            {
                p.aceitarPedido();
                RelacaoDto rdto = new RelacaoDto
                {
                    forcaLigacao = 1,
                    ListaTags = new List<string>(),
                    jogadorAmigoId = p.JogadorObjetivo.Id.AsString(),
                    jogadorId = p.Jogador.Id.AsString()
                };
                await rService.AddAsync(rdto);
            }

            if (dto.EstadoPedido.Equals(EstadosPedido.recusado))
            {
                p.recusarPedido();
            }

            await this._unitOfWork.CommitAsync();

            return new PedidoLigacaoDto
            {
                Id = p.Id.AsString(),
                JogadorId = p.Jogador.Id.AsString(),
                JogadorObjetivoId = p.JogadorObjetivo.Id.AsString(),
                MsgObjetivo = p.MsgObjetivo.Texto,
                EstadoPedido = p.EstadoPedido,
                DataPedido = p.DataPedido.DH.ToString(),
                DataRespostaAoPedido = p.DataRespostaAoPedido.DH.ToString()
            };
        }
    }
        
}
