using Business.Busines.Exceptions.Blog;
using Business.Busines.Services.Interfaces;
using Business.Core.Entities;
using Business.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busines.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository,IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env = env;
        }

        private readonly IWebHostEnvironment _env;

        public Task CreateAsync(Blog blog)
        {
           if( blog is  null )throw new NullReferenceException();
            if (blog.ImageFile is not null)        
            {
                if (blog.ImageFile.ContentType!="image/jpeg" && blog.ImageFile.ContentType!="image/png")
                {
                    throw new BlogInvalidImageFileException("ImageFile", "Content type must be jpeg or png !");
                }
                //if (blog.ImageFile.Length>2100000)
                //{
                //    throw new BlogInvalidImageFileException(");
                //}

            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetAllAsync(Expression<Func<Blog, bool>>? expression = null, params string[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetByExprssion(Expression<Func<Blog, bool>>? expression = null, params string[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
