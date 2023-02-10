using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;

namespace SocialNetwork.Domain.Tags
{
    public class TagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagRepository _repo;

        public TagService(IUnitOfWork unitOfWork, ITagRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<TagDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<TagDto> listDto = list.ConvertAll<TagDto>(t => new TagDto{Id = t.Id.AsString(), TagJm = t.TagJM.Text });

            return listDto;
        }

        public async Task<TagDto> GetByIdAsync(TagId id)
        {
            var t = await this._repo.GetByIdAsync(id);
            
            if(t == null)
                return null;
            return new TagDto{Id = t.Id.AsString(), TagJm = t.TagJM.Text};
        }

        public async Task<TagDto> AddAsync(TagDto dto)
        {
            var t = new Tag(dto.TagJm);

            await this._repo.AddAsync(t);

            await this._unitOfWork.CommitAsync();


            return new TagDto { Id = t.Id.AsString(), TagJm = t.TagJM.Text};
        }

        public async Task<TagDto> DeleteAsync(TagId id)
        {
            var t = await this._repo.GetByIdAsync(id); 

            if (t == null)
                return null;               
            this._repo.Remove(t);
            await this._unitOfWork.CommitAsync();


            return new TagDto {Id = t.Id.AsString(),TagJm = t.TagJM.Text};
        }  
    }
}