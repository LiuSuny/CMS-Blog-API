using CMS.API.Data;
using CMS.API.Models.Domain;
using CMS.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories.Implementation
{
    public class BlogPostRepository(ApplicationDbContext dbContext) : IBlogPostRepository
    {
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            // return await dbContext.BlogPosts.ToListAsync();
            return await dbContext.BlogPosts.Include(x => x.Categories).ToListAsync();
        }
    }
}
