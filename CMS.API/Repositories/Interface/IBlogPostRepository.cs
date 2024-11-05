using CMS.API.Models.Domain;

namespace CMS.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {

        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
