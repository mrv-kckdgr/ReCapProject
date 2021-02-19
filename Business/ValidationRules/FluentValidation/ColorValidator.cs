using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color_>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).MinimumLength(3);
            RuleFor(p => p.ColorName).Must(StartWithA).WithMessage("Renk adı C harfi ile başlamalıdır!!!");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("C");
        }
    }
}
