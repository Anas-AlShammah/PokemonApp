using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;
        public OwnerController(IMapper mapper,IOwnerRepository ownerRepository)
        {
            _mapper= mapper;
            _ownerRepository= ownerRepository;
        }
        [HttpGet("{ownerId}")]
        [ProducesResponseType(200,Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            var owner=_mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));
            return Ok(owner);
        }
        [HttpGet("owners")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwners()
        {
            var owners =_mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
            return Ok(owners);
        }



    }
}
