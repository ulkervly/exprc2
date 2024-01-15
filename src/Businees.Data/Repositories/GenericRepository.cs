using Businees.Data.DAL;
using Business.Core.Entities;
using Business.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        public AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }
        private IQueryable<T> _getQuery(params string[] includes)
        {
            var query=Table.AsQueryable();
            if (includes!=null && includes.Length>0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;

        }

        public IQueryable<T> GetAll(params string[] includes)
        {
           var query=_getQuery(includes);
            return query;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = _getQuery(includes);
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query=_getQuery(includes);
            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }
    }
}
