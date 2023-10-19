
using AutoMapper;
using Entities.Dtos;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebApi.AutoMapper
{
    public class AutoMapperProfil:Profile
    {
        public AutoMapperProfil()
        {
            CreateMap<CarData, CarForDetailDto>();

            CreateMap<CarData, CarForListDto>().ForMember(l => l.PhotoUrl, opt =>
            {
                opt.MapFrom(sor => sor.Photos.FirstOrDefault(p => p.IsMain == true).PhotoUrl);
            });
            CreateMap<PhotoForCreationDto,Photo>();
            CreateMap<Photo, PhotoForReturnDto>();


           

        }
    }
}
