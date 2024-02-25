using Microsoft.EntityFrameworkCore;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;
using Server.Models.Exceptions;

namespace Server.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IRepository{T}"/> interface.
    /// It implements the available generics methods necessary to manipulate the Resources from the database (CRUD and more).
    /// It also defines some protected methods needed for Repositories class which inherited from <see cref="Repository{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext.InsuranceDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context"></param>
        public Repository(DataContext.InsuranceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method used to generate <see cref="IQueryable{T}"/> for a resource with Specifications.
        /// This methods is used inside <see cref="GetAsync(FilterSpecification{T}, PagingSpecification, SortSpecification{T})"/> implementations.
        /// Since this code is always the same for all the repositories, it was realized inside this class and made as protected.
        /// </summary>
        /// <param name="filterSpecification"></param>
        /// <param name="pagingSpecification"></param>
        /// <param name="sortSpecification"></param>
        /// <returns></returns>
        protected IQueryable<T> GenerateQuery(FilterSpecification<T>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<T>? sortSpecification = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filterSpecification != null)
                query = query.Where(filterSpecification);

            if (sortSpecification != null)
                query = SortQuery(sortSpecification, query);

            if (pagingSpecification != null)
                query = query.Skip(pagingSpecification.Skip).Take(pagingSpecification.Take);
            return query;
        }

        /// <inheritdoc />
        public virtual async Task<T> GetAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result == null)
                throw new ResourceNotFoundException("Element doesn't exist.");
            return result;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<T>> GetAsync(FilterSpecification<T>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<T>? sortSpecification = null)
        {

            var query = GenerateQuery(filterSpecification, pagingSpecification, sortSpecification);
            return await query.ToListAsync();
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        private static Func<IQueryable<T>, IOrderedQueryable<T>>? SortThenBy(Sort<T> sortElement,
            Func<IQueryable<T>, IOrderedQueryable<T>> sort)
        {
            Func<IQueryable<T>, IOrderedQueryable<T>>? result = null;

            if (sortElement.OrderBy != null &&
                sortElement.SortingDirection == SortingDirectionSpecification.Ascending)
                result = items => sort(items).ThenBy(sortElement.OrderBy.Order);

            if (sortElement.OrderBy != null &&
                sortElement.SortingDirection == SortingDirectionSpecification.Descending)
                result = items => sort(items).ThenByDescending(sortElement.OrderBy.Order);
            return result;
        }

        private static Func<IQueryable<T>, IOrderedQueryable<T>>? SortOrderBy(Sort<T> sortElement)
        {
            Func<IQueryable<T>, IOrderedQueryable<T>>? result = null;

            if (sortElement.OrderBy != null &&
                sortElement.SortingDirection == SortingDirectionSpecification.Ascending)
                result = items => items.OrderBy(sortElement.OrderBy.Order);

            if (sortElement.OrderBy != null &&
                sortElement.SortingDirection == SortingDirectionSpecification.Descending)
                result = items => items.OrderByDescending(sortElement.OrderBy.Order);
            return result;
        }

        private static IQueryable<T>? SortQuery(SortSpecification<T> sortSpecification, IQueryable<T> query)
        {
            Func<IQueryable<T>, IOrderedQueryable<T>>? sort = null;

            foreach (var sortElement in sortSpecification.SortElements)
            {
                sort = sort != null ? SortThenBy(sortElement, sort) : SortOrderBy(sortElement);
            }

            if (sort != null)
                query = sort(query);
            return query;
        }

        /// <inheritdoc />
        public async Task<int> CountWhereAsync(FilterSpecification<T>? filterSpecification = null)
        {
            var totalEntities = 0;
            IQueryable<T> query = _context.Set<T>();
            if (filterSpecification != null)
                query = query.Where(filterSpecification);
            if (query != null)
                totalEntities = await query.CountAsync();
            return totalEntities;
        }

        /// <inheritdoc />
        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _context.Set<T>().AddAsync(entity)).Entity;
        }

        /// <inheritdoc />
        public virtual Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            _context.Set<T>().RemoveRange(entities);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<int> CountAllAsync()
        {
            return _context.Set<T>().CountAsync();
        }

        /// <inheritdoc />
        public virtual T Get(int id)
        {
            var result = _context.Set<T>().Find(id) ?? throw new ResourceNotFoundException("Element doesn't exist.");
            return result;
        }

        /// <inheritdoc />
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <inheritdoc />
        public virtual T Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _context.Set<T>().Add(entity).Entity;
        }

        /// <inheritdoc />
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <inheritdoc />
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        /// <inheritdoc />
        public int CountAll()
        {
            return _context.Set<T>().Count();
        }
    }
}
