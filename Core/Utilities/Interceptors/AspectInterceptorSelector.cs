using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAtributes = type.GetCustomAttributes<MethodInterceptionBaseAtribute>(true).ToList();

            var methodAtributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAtribute>(true);
            classAtributes.AddRange(methodAtributes);

            return classAtributes.OrderBy(c => c.Priority).ToArray();

        }
    }
}
