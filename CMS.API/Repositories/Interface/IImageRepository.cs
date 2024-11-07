using CMS.API.Models.Domain;

namespace CMS.API.Repositories.Interface
{
    public interface IImageRepository
    {

        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetAll();
    }
}
