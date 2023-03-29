using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRespository : GenericRepository<Product>, IProductRepository
    {
        public ProductRespository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GeProductsWithCategory()
        {
            //IGGLE looading => prodağı çekerken categoriyde çekme
            return await _context.Products.Include(x=>x.Category).ToListAsync();
        }
    }
}
