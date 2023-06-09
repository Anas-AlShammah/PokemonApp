﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Data;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly DataContext context;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, DataContext context,IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            this.context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]

        public IActionResult GetPokemons()
        {
            // var pokemons =_pokemonRepository.GetPokemons();
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200,Type=typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            //            var Pokemon=_pokemonRepository.GetPokemon(pokeId);
            var Pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var Pokemon = _pokemonRepository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Pokemon);
        }
    }
}
