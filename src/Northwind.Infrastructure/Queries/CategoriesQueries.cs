using Microsoft.EntityFrameworkCore;

using Northwind.Application.Production.Categories;

namespace Northwind.Infrastructure.Queries
{
    public class CategoriesQueries : ICategoriesQueries
    {
        private readonly Context _context;

        public CategoriesQueries(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<CategoryDetailsDto>> GetCategories()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new CategoryDetailsDto
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
        }
    }
}