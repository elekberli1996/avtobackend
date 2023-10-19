using Castle.DynamicProxy;
using Core.CrossCuttingConsern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;

        private ICachManager _cachManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cachManager = ServiceTool.ServiceProvider.GetService<ICachManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{ invocation.Method.ReturnType.FullName}.{ invocation.Method.Name}");
            var arg = invocation.Arguments.ToList();
            var key= $"{methodName}({string.Join(",", arg.Select(x => x?.ToString() ?? "<Null>"))})";
            
            if (_cachManager.isAdd(key))
            {
                invocation.ReturnValue = _cachManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cachManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
