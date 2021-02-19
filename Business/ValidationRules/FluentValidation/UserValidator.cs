using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(5);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password_).NotEmpty();
            RuleFor(u => u.Password_).MinimumLength(6);
        }
    }
}
