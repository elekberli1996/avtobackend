

using AutoMapper;
using Business.Abstract;

using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;

        }
    

       
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var car = _carService.GetAllCarsData2(id);
            var returnedData = _mapper.Map<List<CarForDetailDto>>(car);
            if (car != null)
            {

                return Ok(returnedData);
            }
            return BadRequest("elan bulunamadi");



        }
        [HttpGet("photo")]
        public IActionResult GetPhotosById(int id)
        {
            var photos = _carService.GetCarPhotos(id);
          

                return Ok(photos);
       
        }


        [HttpGet("getall")]
        // [Authorize()]
        public IActionResult GetAll()
        {
         
         

            var data = _carService.GetAllCarsData();
            

            var returnData = _mapper.Map<List<CarForListDto>>(data.Data);

            if (data.Success)
            {

                return Ok(returnData);
            }
            return BadRequest(data.Message);



        }
        [HttpPost("search")]
        // [Authorize()]
        public IActionResult search([FromBody] Search seacrhCar)
        {



            var data = _carService.GetAllCarsData();
            var cars = data.Data.Where(p=>p.categoryId==seacrhCar.CategoryId && 
            seacrhCar.ModelId>0?p.modelId==seacrhCar.ModelId:p.modelId>seacrhCar.ModelId);


            var returnData = _mapper.Map<List<CarForListDto>>(cars);

            if (data.Success)
            {

                return Ok(returnData);
            }

            return BadRequest(data.Message);



        }
        [HttpGet("getCategory")]
        // [Authorize()]
        public IActionResult GetAll(int categoryId)
        {
            var data = _carService.GetCarByCategory(categoryId);

            var returnData = _mapper.Map<List<CarForListDto>>(data.Data);

            if (data.Success)
            {

                return Ok(returnData);
            }
            return BadRequest(data.Message);


        }

        [HttpPost("AddCar")]
        public IActionResult Add([FromBody] Car car )
        {
           
            car.AddedData = DateTime.Now;
          
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(car);
            }

            return BadRequest(result.Message);


        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Car car)
        {
            car.AddedData = DateTime.Now;
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);


        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);


        }
    }
}
