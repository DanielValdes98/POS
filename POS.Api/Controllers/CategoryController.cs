using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.Request;
using POS.Application.Interfaces;
using POS.Infrastucture.Commons.Bases.Request;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
        {
            var response = await _categoryApplication.ListCategories(filters);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> CategoryByIde(int categoryId)
        {
            var response = await _categoryApplication.CategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            var response = await _categoryApplication.RegisterCategory(categoryRequestDTO);
            return Ok(response);
        }

        [HttpPut("Edit/{categoryId:int}")]
        public async Task<IActionResult> RegisterCategory(int categoryId, [FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            var response = await _categoryApplication.EditCategory(categoryId, categoryRequestDTO);
            return Ok(response);
        }

        [HttpPut("Remove/{categoryId:int}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            var response = await _categoryApplication.RemoveCategory(categoryId);
            return Ok(response);
        }
    }
}
