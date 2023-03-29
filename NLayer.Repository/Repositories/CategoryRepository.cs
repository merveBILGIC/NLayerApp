﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCetegortyByIdWithProductAsync(int categortyId)
        {
           return await _context.Categories.Include(x=>x.Products).Where(x=>x.Id == categortyId).SingleOrDefaultAsync();
        }
    }
}
