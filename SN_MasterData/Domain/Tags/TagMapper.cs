using System.Collections.Generic;

namespace SocialNetwork.Domain.Tags
{
    public static class TagMapper
    { 
        public static TagDto toDto( Tag e)
        {
            return new TagDto { Id = e.Id.AsString(), TagJm = e.TagJM.Text };
        }

        public static List<TagDto> toDtoList(List<Tag> tags){
            return tags.ConvertAll<TagDto>(Tag => toDto(Tag));;
        }
    }
}