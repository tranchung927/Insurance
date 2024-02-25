using Microsoft.EntityFrameworkCore;
using Server.DataContext;

namespace Server.Repositories.Tag
{
    public class TagRepository : Repository<Data.Tag>, ITagRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public TagRepository(InsuranceDbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<bool> NameAlreadyExists(string name)
        {
            var tag = await _context.Set<Data.Tag>().Where(x => x.Name == name).FirstOrDefaultAsync();
            return tag != null;
        }
    }
}
