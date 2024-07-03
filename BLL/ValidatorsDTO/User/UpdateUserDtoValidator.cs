using BLL.DTO.Request.User;
using FluentValidation;

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(dto => dto.UserName)
                .NotEmpty().WithMessage("UserName is required.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        
            RuleFor(dto => dto.PasswordHash)
                .NotEmpty().WithMessage("Password is required.");
    }
    }
