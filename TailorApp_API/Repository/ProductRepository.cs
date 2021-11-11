using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.DataContext;

namespace TailorApp_API.Repository
{
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
