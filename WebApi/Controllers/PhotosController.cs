using AutoMapper;
using Business.Abstract;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/cars/{carId}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private ICarService _carService;
        private IPhotoService _photoService;
        private IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinarySettings;
        private Cloudinary _cloudinary;
        private bool deyer;

        public PhotosController(ICarService carService, IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings, IPhotoService photoService)
        {
            _carService = carService;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;
            _photoService = photoService;
            Account account = new Account(_cloudinarySettings.Value.CloudName, _cloudinarySettings.Value.ApiKey, _cloudinarySettings.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);

        }

        [HttpPost]
        public ActionResult AddPhotoForCity(int carId,[FromForm]PhotoForCreationDto photoForCreationDto)
        {
            var car = _carService.GetCarbyId(carId);
            
            if (car == null)
            {
                return BadRequest("colud not find car");

            }
           
            var file = photoForCreationDto.File;
            var upoladResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream= file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    upoladResult = _cloudinary.Upload(uploadParams);

                }
            }

            photoForCreationDto.PhotoUrl = upoladResult.Url.ToString();
            photoForCreationDto.PublicId = upoladResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);
            photo.Car = car.Data;
            if (!car.Data.Photos.Any(p => p.IsMain))
            {
                photo.IsMain = true;
            }
            photo.DataAdded = DateTime.Now;
            photo.CarId = car.Data.CarId;
           
            _photoService.Add(photo);
          
                var photoForReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoForReturn);
            
          


        } 
        [HttpGet("{id}",Name ="GetPhoto")]
        public ActionResult GetPhoto(int id)
    {
            var photoFromdb = _carService.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromdb);
            return Ok(photo);

    }

    }

   

}
