using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _ٌReviewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        public _ٌReviewController(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviwes=_mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
            return Ok(reviwes);
        }
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            var review=_mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
            return Ok(review);
        }
    }
}
