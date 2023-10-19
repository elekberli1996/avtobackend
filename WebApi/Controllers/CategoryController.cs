using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService; ;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data = _categoryService.GetAll();
          
                return Ok(data);
            
            return BadRequest();


        }
        [HttpPost("AddCategory")]
        public IActionResult GetAll([FromBody] Category category)
        {
           
            var result = _categoryService.Add(category);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);


        }
        [HttpGet("getCategoryById")]
        public IActionResult GetCategory(int categoryId)
        {
            var result = _categoryService.GetCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);


        }
    }
}
