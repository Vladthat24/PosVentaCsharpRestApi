using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Aplication.Dtos.Request;
using POS.Aplication.Interfaces;
using POS.Infraestructure.Commons.Bases.Request;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryAplication;

        public CategoryController(ICategoryApplication categoryAplication)
        {
            _categoryAplication = categoryAplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFilterRequest filters)
        {
            var response = await _categoryAplication.ListCategories(filters);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult>ListSelectCategories()
        {
            var response = await _categoryAplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("{catgortyId:int}")]
        public async Task<IActionResult> CategoryById(int categoryId)
        {
            var response = await _categoryAplication.CategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
        {
            var response=await _categoryAplication.RegisterCategory(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{categoryId:int}")]
        public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDto requestDto)
        {
            var response = await _categoryAplication.EditCategory(categoryId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{categoryId:int}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            var response = await _categoryAplication.RemoveCategory(categoryId);
            return Ok(response);
        }

    }
}
