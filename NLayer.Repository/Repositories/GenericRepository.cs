using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //readonly kullandığın zaman ya tanımlama esnasında değer atıycaksın ya da cons. içerinden değer atıycaksın!
        //2 yer dışında değer atarsan => run time error. bir kere setlenince bir daha setlenmez!
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.AnyAsync(expression);
        }

        public  IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            //AsNoTracking() => efcore çekmiş olduğu datayı memorye almasın daha performanslı çalışsın
           
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            // dbden siinmiyor entitnin state i deleted olarak işaretlenir.
            // context.Entry(entity).State= EntitState.Deleded => temelde property setleme yüklü iş yok async gerek yok!!!
            //saveChange yapınca efcore flaglere bakarak db den bunları siliyor.
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
