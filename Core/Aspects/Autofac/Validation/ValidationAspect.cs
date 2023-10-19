using Castle.DynamicProxy;
using Core.CrossCuttingConsern.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {

        private Type _validatdionType;
        public ValidationAspect(Type validatdionType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatdionType))
            {
                throw new Exception(AspectMessages.WrongValidatrionType);
            }

            _validatdionType = validatdionType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatdionType);
            var entitiyType = _validatdionType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => p.GetType() == entitiyType);

            foreach (var entity in entities)
            {
                ValidationTool.Validator(validator, entity);
            }
                
        }
    }
}
