using Microsoft.EntityFrameworkCore;
using InsuranceCore.Data.Contracts;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly InsuranceDbContext _context;

        /// <inheritdoc />
        public void Dispose()
        {
            _context.Dispose();
        }


        private void ChangeModifiedAt()
        {
            var modified = _context.ChangeTracker.Entries()
                .Where(t => t.Entity is IHasModificationDate && t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is IHasModificationDate track)
                {
                    track.ModifiedAt = DateTimeOffset.UtcNow;
                }
            }
        }

        public void Save()
        {
            ChangeModifiedAt();

            _context.SaveChanges();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(InsuranceDbContext context)
        {
            _context = context;
        }
    }
}
