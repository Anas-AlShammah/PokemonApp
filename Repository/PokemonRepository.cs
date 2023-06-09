﻿using PokemonApp.Data;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context=context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p=>p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p=>p.Pokemon.Id == pokeId);
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r=>r.Rating)/review.Count());
          //  Pokemon pok = GetPokemon(pokeId);
           // return pok.Reviews.Sum(p => p.Rating);
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
           return _context.Pokemon.Any(e=>e.Id == pokeId);
        }
    }
}
