using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private IModelService _modelService;
        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Model model)
        {
            var result = _modelService.Add(model);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
            
         
        }
        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _modelService.GetAll();

          
                return Ok(result);

        


        }
        [HttpGet("get")]
        public IActionResult Get(int categoryId)
        {
            var result = _modelService.GetModel(categoryId);

            if (result.Success)
            {
                return Ok(result.Data);

            }
            return BadRequest(result.Message);


        }

    }
}
