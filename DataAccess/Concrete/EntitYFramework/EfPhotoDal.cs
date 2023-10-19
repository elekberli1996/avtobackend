using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitYFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, CarContext>, IPhotoDal
    {
    }
}
