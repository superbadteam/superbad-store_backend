using FluentValidation;
using InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Requests;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
}