using BLL.DTO.Request.Category;
using FluentValidation;

namespace BLL.Validation.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
        }
    }
}