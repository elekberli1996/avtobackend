using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitYFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CarContext>, ICategoryDal
    {
        public bool isExsist(Expression<Func<Category, bool>> filter)
        {

            using (var context= new CarContext())
            {
                var result =context.Set<Category>().SingleOrDefault(filter);
                if (result == null)
                {
                    return true;

                }
                return false;
            
            }
        }
    }
}
