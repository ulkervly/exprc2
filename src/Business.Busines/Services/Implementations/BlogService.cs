using Business.Busines.Exceptions.Blog;
using Business.Busines.Exceptions.Common;
using Business.Busines.Services.Interfaces;
using Business.Core.Entities;
using Business.Core.Repositories;
using Bziland.Business.Extensions.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(Blog blog)
        {
           if( blog is  null )throw new NullReferenceException();
            if (blog.ImageFile is not null)        
            {
                if (blog.ImageFile.ContentType!="image/jpeg" && blog.ImageFile.ContentType!="image/png")
                {
                    throw new BlogInvalidImageFileException("ImageFile", "Content type must be jpeg or png !");
                }
                if (blog.ImageFile.Length > 2100000)
                {
                    throw new BlogInvalidImageFileException("ImageFile", "File size must be lower 2 mb");
                }

            }
            blog.ImageUrl = blog.ImageFile.SaveFile(_env.WebRootPath, "uploads/blogs");
            blog.CreatedTime = DateTime.UtcNow;
            blog.UpdatedTime = DateTime.UtcNow;
            await _blogRepository.CreateAsync(blog);
            await _blogRepository.CommitAsync();

        }

        public async Task DeleteAsync(int id)
        {
            if (id<0)
            {
                throw new IdBelowZeroException();
                
            }
            var blog = await _blogRepository.GetSingleAsync(x=>x.Id==id);
            if (blog is null)
            {
                throw new BlogNotFoundException();
            }
            _blogRepository.Delete(blog);
            await _blogRepository.CommitAsync();
        }

        public async Task<List<Blog>> GetAllAsync(Expression<Func<Blog, bool>>? expression = null, params string[]? includes)
        {
            return await _blogRepository.GetAllWhere(expression, includes).ToListAsync();
        }

        public async Task<Blog> GetByExprssion(Expression<Func<Blog, bool>>? expression = null, params string[]? includes)
        {
            return await _blogRepository.GetSingleAsync(expression, includes);
        }

        public async Task UpdateAsync(Blog blog)
        {
            if (blog is null) throw new NullReferenceException();
            var existblog = await _blogRepository.GetSingleAsync(x => x.Id == blog.Id && !x.IsDeleted);
            if (existblog is null)
            {
                throw new BlogNotFoundException();
            }
            if (blog.ImageFile is not null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    throw new BlogInvalidImageFileException("ImageFile", "Content type must be jpeg or png !");
                }
                if (blog.ImageFile.Length > 2100000)
                {
                    throw new BlogInvalidImageFileException("ImageFile", "File size must be lower 2 mb");
                }
                FileManager.DeleteFile(_env.WebRootPath, "uploads/blogs", existblog.ImageUrl);
                existblog.ImageUrl = existblog.ImageFile.SaveFile(_env.WebRootPath, "uploads/blogs");

            }
            existblog.Author=blog.Author;
            existblog.Description=blog.Description;
            existblog.Name=blog.Name;
            existblog.UpdatedTime=DateTime.Now;
            await _blogRepository.CommitAsync();
            

        }

        public async Task SoftDelete(int id)
        {
            if(id<0) throw new IdBelowZeroException();
            var blog = await _blogRepository.GetSingleAsync(x=>x.Id==id);
            if(blog is null) throw new BlogNotFoundException();
            blog.IsDeleted=!blog.IsDeleted;
            await _blogRepository.CommitAsync();
        }
    }
}
