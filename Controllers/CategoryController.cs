using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        
        private readonly ICategoryRepostoy _categoryRepostoy;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepostoy categoryRepostoy,IMapper mapper)
        {
           
            _categoryRepostoy=categoryRepostoy;
            _mapper=mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var category = _mapper.Map<List<CategoryDto>>(_categoryRepostoy.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int categoryId)
        {
            if (_categoryRepostoy.CategoriesExists(categoryId))
            {
                return NotFound();
            }
            var category = _mapper.Map<CategoryDto>(_categoryRepostoy.GetCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {
            
            var pokemons = _mapper.Map<PokemonDto>(_categoryRepostoy.GetPokemonByCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);

        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepostoy.GetCategories()
                .Where(c => c.Name.ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryMap = _mapper.Map<Category>(categoryCreate);
            if (!_categoryRepostoy.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Somethig wrong will saving");
                return StatusCode(500,ModelState);
            }
            return Ok("Successfullt");
        }

    }
}
