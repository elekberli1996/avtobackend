using Castle.DynamicProxy;
using Core.CrossCuttingConsern.Logging;
using Core.CrossCuttingConsern.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Logging
{
   public  class LogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggingService)
        {
            if (loggingService.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.WrongLogType);

            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggingService);

        }
        protected override void OnBefore(IInvocation invocation)
        {
            var data = GetLog(invocation);
            _loggerServiceBase.Info(data);   
        }
        private LogDetail GetLog(IInvocation invocation)
        {
            var logParameter = invocation.Arguments.Select(x => new LogParameter
            {
                
                Value = x,
                Type = x.GetType().Name
            }).ToList();
            var logDetail = new LogDetail
            {
                LogParameters = logParameter,
                MethodName = invocation.Method.Name
            };
            return logDetail;
        }
    }
}
