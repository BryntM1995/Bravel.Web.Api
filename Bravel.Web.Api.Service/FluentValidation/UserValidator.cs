using Bravel.Web.Api.Service.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Service.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(UserValidate => UserValidate.Id).NotNull();
            RuleFor(UserValidate => UserValidate.Name).NotNull().WithMessage("Name cannot be null.");
            RuleFor(UserValidate => UserValidate.LastName).NotNull().WithMessage("LastName cannot be null.");
            RuleFor(UserValidate => UserValidate.Email).NotNull().WithMessage("Email cannot be null.");
        }
    }
}
