using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviwerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviwerRepository _reviwerRepository;
        public ReviwerController(IMapper mapper,IReviwerRepository reviwerRepository)
        {
            _mapper = mapper;
            _reviwerRepository = reviwerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewers()
        {
            var reviwers=_mapper.Map<List<ReviewerDto>>(_reviwerRepository.GetReviewers());
            return Ok(reviwers);
        }
        [HttpGet("{reviwerId}")]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviwerId)
        {
            var reviwer = _mapper.Map<ReviewerDto>(_reviwerRepository.GetReviewer(reviwerId));
            return Ok(reviwer);
        }
    }
}
