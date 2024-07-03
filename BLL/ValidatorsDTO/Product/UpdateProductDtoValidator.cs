using BLL.DTO.Request.Product;
using FluentValidation;

    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(dto => dto.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(dto => dto.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
    }
    }
