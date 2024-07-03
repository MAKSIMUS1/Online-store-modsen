using BLL.DTO.Request.OrderItem;
using FluentValidation;

public class UpdateOrderItemDtoValidator : AbstractValidator<UpdateOrderItemDto>
{
    public UpdateOrderItemDtoValidator()
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