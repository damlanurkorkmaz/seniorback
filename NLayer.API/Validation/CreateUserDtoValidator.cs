using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.API.Validation
{
    public class CreateUserDtoValidator: AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is rewuired");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
