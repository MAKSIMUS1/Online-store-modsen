using BLL.DTO.Request.Order;
using FluentValidation;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(dto => dto.UserId)
                .NotEmpty().WithMessage("UserId is required.");

        RuleFor(dto => dto.OrderDate)
            .NotEmpty().WithMessage("OrderDate is required.")
            .Must(BeAValidDate).WithMessage("OrderDate must be a valid date.");

    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}