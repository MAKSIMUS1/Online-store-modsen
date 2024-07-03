using BLL.DTO.Request.User;
using FluentValidation;


    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(dto => dto.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(6).WithMessage("UserName must be at least 6 characters long.");


            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(dto => dto.PasswordHash)
                .NotEmpty().WithMessage("Password is required.");
    }
    }
