using Northwind.Domain.Production;

namespace Northwind.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Add(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new ArgumentNullException(nameof(category));

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            await _context.SaveChangesAsync();
        }
    }
}