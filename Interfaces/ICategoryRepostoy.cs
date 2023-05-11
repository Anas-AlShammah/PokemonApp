using PokemonApp.Models;

namespace PokemonApp.Interfaces
{
    public interface ICategoryRepostoy
    {
        ICollection <Category> GetCategories ();

        Category GetCategory (int id);

       
        ICollection <Pokemon> GetPokemonByCategory (int categoryId);

        bool CategoriesExists (int Id);

        bool CreateCategory(Category category);

        bool Save();
    }
}
