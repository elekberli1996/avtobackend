using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitYFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver.Autofac
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();
            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>();
            builder.RegisterType<PhotoManager>().As<IPhotoService>();



            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UserManager>().As<IUserService>();

            var assemly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assemly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }
            ).SingleInstance();

        }
    }
}
