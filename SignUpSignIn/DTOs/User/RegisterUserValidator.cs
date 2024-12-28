using FluentValidation;

namespace SignUpSignIn.DTOs.User
{
    public class RegisterUserValidator : AbstractValidator<RegistrationUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Password should not be less than 8 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.PasswordConf)
                .Equal(x => x.Password)
                .WithMessage("Passwords must match.");
        }
    }
}
