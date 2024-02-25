using Microsoft.EntityFrameworkCore;
using Server.Models.Exceptions;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;
using Server.DataContext;

namespace Server.Repositories.Category
{
    /// <summary>
    /// Repository used to manipulate <see cref="Category"/> from database (CRUD and more).
    /// </summary>
    public class CategoryRepository : Repository<Data.Category>, ICategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(InsuranceDbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public override async Task<IEnumerable<Data.Category>> GetAsync(FilterSpecification<Data.Category>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.Category>? sortSpecification = null)
        {
            var query = GenerateQuery(filterSpecification, pagingSpecification, sortSpecification);
            return await query.Include(x => x.Posts).ToListAsync();
        }

        /// <inheritdoc />
        public override async Task<Data.Category> GetAsync(int id)
        {
            try
            {
                return await _context.Set<Data.Category>()
                    .Include(x => x.Posts)
                    .SingleAsync(x => x.Id == id);
            }
            catch
            {
                throw new ResourceNotFoundException("Category doesn't exist.");
            }
        }

        /// <inheritdoc />
        public override Data.Category Get(int id)
        {
            try
            {
                return _context.Set<Data.Category>()
                    .Include(x => x.Posts)
                    .Single(x => x.Id == id);
            }
            catch
            {
                throw new ResourceNotFoundException("Category doesn't exist.");
            }
        }

        /// <inheritdoc />
        public override IEnumerable<Data.Category> GetAll()
        {
            return _context.Set<Data.Category>()
                .Include(x => x.Posts).ToList();
        }

        /// <inheritdoc />
        public async Task<bool> NameAlreadyExists(string name)
        {
            var category = await _context.Set<Data.Category>().Where(x => x.Name == name).FirstOrDefaultAsync();
            return category != null;
        }

        /// <inheritdoc />
        public override async Task<IEnumerable<Data.Category>> GetAllAsync()
        {
            return await _context.Set<Data.Category>()
                .Include(x => x.Posts).ToListAsync();
        }
    }
}
