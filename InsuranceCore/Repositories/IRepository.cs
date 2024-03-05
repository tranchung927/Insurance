using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;

namespace InsuranceCore.Repositories
{
    /// <summary>
    /// Interface of all Repositories. It defines the available generics methods necessary to manipulate the Resources from the database (CRUD and more).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Method used to get a <see cref="T"/> resource by giving its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Method used to get <see cref="T"/> resource(s) by specified filter(s), pagination, and sort(s) (sort, etc.).
        /// </summary>
        /// <param name="filterSpecification"></param>
        /// <param name="pagingSpecification"></param>
        /// <param name="sortSpecification"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(FilterSpecification<T>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<T>? sortSpecification = null);

        /// <summary>
        /// Method used to get all <see cref="T"/> resources.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Method used to count <see cref="T"/> resources where the expression match.
        /// </summary>
        /// <param name="filterSpecification"></param>
        /// <returns></returns>
        Task<int> CountWhereAsync(FilterSpecification<T>? filterSpecification = null);

        /// <summary>
        /// Method used to add a <see cref="T"/> resource.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Method used to remove a <see cref="T"/> resource.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RemoveAsync(T entity);

        /// <summary>
        /// Method used to remove a list of <see cref="T"/> resources.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Method used to count all existing <see cref="T"/>
        /// </summary>
        /// <returns></returns>
        Task<int> CountAllAsync();

        /// <summary>
        /// Method used to get a <see cref="T"/> resource by giving its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Method used to get all existing <see cref="T"/> resources.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Method used to add a <see cref="T"/> resource.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Method used to remove a <see cref="T"/> resource.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Method used to remove a list of <see cref="T"/> resources.
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Method used to count all existing <see cref="T"/>
        /// </summary>
        /// <returns></returns>
        int CountAll();
    }

}