﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);

        IResult Delete(Category category);

        IResult Update(Category category);

        IDataResult<Category> GetCategory(int CategoryId);

         List<Category> GetAll();

       

    }
}
