using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitYFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public Car GetCarById(int carId)
        {
            using (CarContext context= new CarContext())
            {
                var car = context.Cars.Include(p => p.Photos).FirstOrDefault(c => c.CarId == carId);
                return car;
            }
        }

        public List<Car> GetCars()
        {
            using (CarContext context= new CarContext())
            {
                var cars = context.Cars.Include(p => p.Photos).ToList();
                return cars;

            }
        }

        public List<Car> GetCarsByCategory(int categoryId)
        {
            using (CarContext context = new CarContext())
            {
                var cars = context.Cars.Include(p => p.Photos).Where(c => c.CategoryId == categoryId).ToList();
                return cars;
            }
            }

            public Photo GetPhoto(int id)
        {
            using (CarContext context = new CarContext())
            {
                var photo = context.Photos.FirstOrDefault(p => p.Id == id);
                return photo;

            }
        }

            public List<Photo> GetPhotoByCar(int carId)
         {
            using (CarContext context = new CarContext())
            {
                var photos = context.Photos.Where(p => p.CarId == carId).ToList();
                return photos;

            }
         }

        public  IEnumerable<CarData> JoinTable()
        {
            
            using (CarContext context = new CarContext())
            {
                var objlist = (from c in context.Cars
                          join cat in context.Categories on c.CategoryId equals cat.CategoryId
                          join m in context.Models on c.ModelId equals m.ModelId
                          select new CarData (){ 
                              CarId=c.CarId,
                              CategoryName=cat.CategoryName,
                              Photos=c.Photos,
                              Price=c.Price,
                              ModelName=m.ModelName,
                             UserId=c.UserId ,
                             categoryId=c.CategoryId,
                             modelId=c.ModelId,
                             City=c.City,
                             Year=c.Year,
                             Type=c.Type,
                             Color=c.Color,
                             Vip=c.Vip,
                             OtherNotes=c.OtherNotes,
                             AddedData=c.AddedData,
                             Engine=c.Engine,
                             EnginePower=c.EnginePower,
                             TotalWay=c.TotalWay,
                             Transmittor=c.Transmittor,
                             PhoneNumber=c.PhoneNumber



                          }).ToList();



                return objlist ;

            }
        }

        public IEnumerable<CarData> JoinTable2(int id)
        {

            using (CarContext context = new CarContext())
            {
                var objlist = (from c in context.Cars
                               join cat in context.Categories on c.CategoryId equals cat.CategoryId
                               join m in context.Models on c.ModelId equals m.ModelId where c.CarId==id
                               select new CarData()
                               {
                                   CarId = c.CarId,
                                   CategoryName = cat.CategoryName,
                                   Photos = c.Photos,
                                   Price = c.Price,
                                   ModelName = m.ModelName,
                                   UserId=c.UserId,
                                   City = c.City,
                                   Year = c.Year,
                                   Type = c.Type,
                                   Color = c.Color,
                                   Vip = c.Vip,
                                   OtherNotes = c.OtherNotes,
                                   AddedData = c.AddedData,
                                   Engine = c.Engine,
                                   EnginePower = c.EnginePower,
                                   TotalWay = c.TotalWay,
                                   Transmittor = c.Transmittor,
                                   PhoneNumber=c.PhoneNumber

                               }).ToList();



                return objlist;

            }
        }


        public bool SaveAll()
        {
            using (CarContext context = new CarContext())
            {
                return context.SaveChanges() > 0;

            }
        }
    }
}
