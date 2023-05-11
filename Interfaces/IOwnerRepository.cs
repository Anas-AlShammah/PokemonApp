using PokemonApp.Models;

namespace PokemonApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection <Owner> GetOwners ();

        Owner GetOwner (int ownerId);


    }
}
