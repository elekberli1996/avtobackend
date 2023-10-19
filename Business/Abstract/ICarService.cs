using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);

        IDataResult<List<Car>> GetAllCars();

        IDataResult<List<Car>> GetCarByCategory(int categoryId);

        IDataResult<Car> GetCarbyId(int carId);

        IDataResult<Photo> GetPhoto(int id);

        IResult TrasactionOperation(Car car);

        IResult SaveAll();


        IDataResult<List<Photo>> GetCarPhotos(int carId);

        IResult Update(Car car);

        IDataResult<List<CarData>> GetAllCarsData();
        List<CarData> GetAllCarsData2(int id);

        bool SaveChanges();

    }
}
