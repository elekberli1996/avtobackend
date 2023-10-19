using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model model);

        IResult Delete(Model model);

        IResult Update(Model  model);

        IDataResult<Model> GetModel(int modelId);

      List<Model> GetAll();
    }
}
