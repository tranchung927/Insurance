using Server.Data;
using Server.Models.DTOs.Tag;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;

namespace Server.Services.TagService
{
    public interface ITagService
    {
        Task<IEnumerable<GetTagDto>> GetAllTags();

        public Task<IEnumerable<GetTagDto>> GetTags(FilterSpecification<Tag>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Tag>? sortSpecification = null);

        public Task<int> CountTagsWhere(FilterSpecification<Tag>? filterSpecification = null);

        Task<GetTagDto> GetTag(int id);

        Task<GetTagDto> AddTag(AddTagDto tag);

        Task UpdateTag(UpdateTagDto tag);

        Task DeleteTag(int id);
    }
}
