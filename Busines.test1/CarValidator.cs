using Business.Concrete;
using Business.Constant;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Busines.test1
{
    [TestClass]
    public class CarValidator
    {

        [TestMethod] 
        [ExpectedException(typeof(ValidationException))]
        public void Car_Validator()
        {
            

            Mock<ICarDal> mock = new Mock<ICarDal>();
            CarManager maneger = new CarManager(mock.Object);

            maneger.Add(new Car());
        }
    }
}
