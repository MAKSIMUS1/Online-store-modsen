using BLL.DTO.Request.Category;
using FluentValidation;

public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
{
    public DeleteCategoryDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}