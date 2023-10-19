using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidator
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            
            
          //  RuleFor(c => c.Brand).NotEmpty();
//RuleFor(c => c.Model).NotEmpty();
        }
    }
}
