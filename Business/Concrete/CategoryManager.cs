using Business.Abstract;
using Business.Constant;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

       
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }
        public IResult Add(Category category)
        {
            var result = _categoryDal.isExsist(t => t.CategoryName == category.CategoryName);
           if (result == true)
            {
              _categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
            }
           return new ErrorResult(Messages.CategoryExisist);
           //throw  new ValidationExceptionCore("sistemde kayit var");
           
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public List<Category> GetAll()
        {
           return _categoryDal.GetAll();
         
        }

        public IDataResult<Category> GetCategory(int CategoryId)
        {
            var data= _categoryDal.Get(c => c.CategoryId == CategoryId);
            return new SuccessDataResult<Category>(data);
            
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }

     
    }
}
