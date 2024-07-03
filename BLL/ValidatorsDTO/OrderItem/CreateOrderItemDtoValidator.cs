using BLL.DTO.Request.OrderItem;
using FluentValidation;

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(dto => dto.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(dto => dto.OrderId)
                .NotEmpty().WithMessage("OrderId is required.");

        RuleFor(dto => dto.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}