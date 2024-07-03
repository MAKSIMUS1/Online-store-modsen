using BLL.DTO.Request.Order;
using FluentValidation;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(dto => dto.UserId)
                .NotEmpty().WithMessage("UserId is required.");
    }
}