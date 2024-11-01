using CMS.API.Data;
using CMS.API.Models.Domain;
using CMS.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository( ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await _applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (existingCategory != null)
            {
                _applicationDbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                // _applicationDbContext.Update(category);
                await _applicationDbContext.SaveChangesAsync();
                return existingCategory;
            }
            return null;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            _applicationDbContext.Categories.Remove(existingCategory);
            await _applicationDbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
