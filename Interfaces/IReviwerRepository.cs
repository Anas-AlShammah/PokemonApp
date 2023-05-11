using PokemonApp.Models;

namespace PokemonApp.Interfaces
{
    public interface IReviwerRepository
    {
        ICollection<Reviewer> GetReviewers();

        Reviewer GetReviewer(int reviwerId);
    }
}
