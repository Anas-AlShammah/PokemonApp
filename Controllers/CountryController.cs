using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        public CountryController(IMapper mapper,ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries= _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            return Ok(countries);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountrtExsites(countryId))
            {
                return NotFound();
            }
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));
            return Ok(country);
        }
        [HttpGet("counterbyOwner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country= _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            return Ok(country);
        }
        [HttpGet("Ownersbycounter/{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            var owners = _mapper.Map<List<Owner>>(_countryRepository.GetOwnersFromCountry(countryId));
            return Ok(owners);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto createcountry)
        {
            var countryMap = _mapper.Map<Country>(createcountry);
            _countryRepository.CreateCountry(countryMap);
            return Ok("done");
        }
    }
}
