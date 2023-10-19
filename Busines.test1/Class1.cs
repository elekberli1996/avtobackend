using Business.Concrete;
using Business.Constant;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework;
using Entities.Concrete;
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
    public class Class1
    {

        [TestMethod, ExpectedException(typeof(ValidationExceptionCore))]
        public void ayni_kategorySisteme_2cikez_eklendiginde_hata()
        {
            var mock = new Mock<ICategoryDal>();

            mock.Setup(t => t.isExsist(c => c.CategoryName == "bmw"))
                .Returns(true);

            var maneger = new CategoryManager(mock.Object);
           
            maneger.Add(It.IsAny<Category>());
        }
    }
}
