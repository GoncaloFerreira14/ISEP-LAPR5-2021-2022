using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;


namespace SocialNetwork.Domain.EstadosEmocionais
{
    public class EstadoEmocionalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEstadoEmocionalRepository _repo;

        public EstadoEmocionalService(IUnitOfWork unitOfWork, IEstadoEmocionalRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<EstadoEmocionalDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<EstadoEmocionalDto> listDto = list.ConvertAll<EstadoEmocionalDto>(e => new EstadoEmocionalDto{Id = e.Id.AsString(), EstadoHumor = e.EstadoHumor,Data = e.Data.DH.ToString(), ValorEstado = e.ValorEstado.Numero});

            return listDto;
        }

         public async Task<EstadoEmocionalDto> GetByIdAsync(EstadoEmocionalId id)
        {
            var e = await this._repo.GetByIdAsync(id);
            
            if(e == null)
                return null;

            return new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = e.EstadoHumor, Data = e.Data.DH.ToString(), ValorEstado = e.ValorEstado.Numero};
        }
           public async Task<EstadoEmocionalDto> AddAsync(EstadoEmocionalDto dto)
        {
            var e = new  EstadoEmocional(dto.EstadoHumor);

            await this._repo.AddAsync(e);

            await this._unitOfWork.CommitAsync();

            

            return new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = e.EstadoHumor, Data = e.Data.DH.ToString(), ValorEstado = e.ValorEstado.Numero};
        }

        public async Task<EstadoEmocionalDto> UpdateAsync(EstadoEmocionalDto dto)
        {
            var estado = await this._repo.GetByIdAsync(new EstadoEmocionalId(dto.Id)); 

            if (estado == null)
                return null;   

            // change all field
            estado.ChangeEstadoHumor(dto.EstadoHumor);
            estado.ChangeData();
            estado.ChangeValor(dto.ValorEstado);
            await this._unitOfWork.CommitAsync();

           return new EstadoEmocionalDto { Id = estado.Id.AsString(), EstadoHumor = estado.EstadoHumor, Data = estado.Data.DH.ToString(), ValorEstado = estado.ValorEstado.Numero};
        }   
        public async Task<EstadoEmocionalDto> DeleteAsync(EstadoEmocionalId id)
        {
            var e = await this._repo.GetByIdAsync(id); 

            if (e == null)
                return null;               
            this._repo.Remove(e);
            await this._unitOfWork.CommitAsync();

    
           return new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = e.EstadoHumor, Data = e.Data.DH.ToString(), ValorEstado = e.ValorEstado.Numero};
        }        
    }
}