using FluentValidation;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands;
{
    public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
    {
        public CompleteOrderCommandValidator()
        {
            RuleFor(p => p.OrderNumber)
                .NotNull().WithMessage("OrderNumber can not be null.");
                .NotEmpty().WithMessage("OrderNumber can not be empty.")

            RuleFor(p => p.OrderDate)
           .NotEmpty().WithMessage("OrderDate can not be empty.");

            RuleFor(p => p.UserId)
                .GreaterThan(0).WithMessage("UserId is necessary.");
        }
    }
}