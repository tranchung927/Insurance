using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.Product
{
    public class ProductRepository : Repository<Data.Product>, IProductRepository
    {
        public ProductRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

