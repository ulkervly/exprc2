using Business.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busines.Services.Interfaces
{
    public interface IBlogService
    {
        Task CreateAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<Blog> GetByExprssion(Expression<Func<Blog,bool>>?expression=null,params string[]? includes);
        Task<List<Blog>> GetAllAsync(Expression<Func<Blog,bool>>?expression=null,params string[]? includes);
    }
}
