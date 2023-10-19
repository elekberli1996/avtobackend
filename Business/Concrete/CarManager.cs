using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConsern.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{  
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
       // [ValidationAspect(typeof(CarValidator),Priority =2) ]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        //[SecuredOperation("Car.List")]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Car>> GetAllCars()
        {
            var cars = _carDal.GetCars();
            

            return new SuccessDataResult<List<Car>>(cars);
        }

        public IDataResult<List<CarData>> GetAllCarsData()
        { 
            var data=_carDal.JoinTable();
            var list = data.Cast<CarData>().ToList();
            return new SuccessDataResult<List<CarData>>(list);



        }
        public List<CarData> GetAllCarsData2(int id)
        {

            var data = _carDal.JoinTable2(id);
            var list = data.Cast<CarData>().ToList();
            return list;


        }

        public IDataResult<List<Car>> GetCarByCategory(int categoryId)
        {
            var cars = _carDal.GetCarsByCategory(categoryId);
            return new SuccessDataResult<List<Car>>(cars);

        }

        public IDataResult<Car> GetCarbyId(int carId)
        {
            var car = _carDal.GetCarById(carId);
            return new SuccessDataResult<Car>(car);
        }

        public IDataResult<List<Photo>> GetCarPhotos(int carId)
        {
            var photos = _carDal.GetPhotoByCar(carId).ToList();
            return new SuccessDataResult<List<Photo>>(photos);

        }

        public IDataResult<Photo> GetPhoto(int id)
        {
            var photo = _carDal.GetPhoto(id);
            return new SuccessDataResult<Photo>(photo);

        }

        public IResult SaveAll()
        {
            var result = _carDal.SaveAll();
            return new SuccessResult(result.ToString());
        }

        public bool SaveChanges()
        {
            var returned= _carDal.SaveChanges();
            return returned;
        }

        [TransactionScopeAspect]
        public IResult TrasactionOperation(Car car)
        {
            _carDal.Add(car);
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

      //  [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
