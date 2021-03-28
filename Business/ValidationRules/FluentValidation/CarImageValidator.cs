using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            //RuleFor(c => c.ImagePath).MinimumLength(5);
          //  RuleFor(c => c.ImagePath).NotEmpty();
        }
    }
}
