using PokemonApp.Data;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Repository
{
    public class CategoryRepository : ICategoryRepostoy
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoriesExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

            return Save();
        }

        public ICollection<Category> GetCategories()
        {
           return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.Where(e => e.Id == categoryId).FirstOrDefault();
        }

       

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == categoryId).Select(e=>e.Pokemon).ToList();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
