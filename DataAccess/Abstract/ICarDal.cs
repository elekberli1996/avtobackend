        using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntitiyRepository<Car>
    {
        List<Photo> GetPhotoByCar(int carId);
       

        bool SaveAll();
        List<Car> GetCars();
        List<Car> GetCarsByCategory(int categoryId);

        Car GetCarById(int carId);

        Photo GetPhoto(int id);

       IEnumerable<CarData> JoinTable();

        IEnumerable<CarData> JoinTable2(int id);




    }
}
