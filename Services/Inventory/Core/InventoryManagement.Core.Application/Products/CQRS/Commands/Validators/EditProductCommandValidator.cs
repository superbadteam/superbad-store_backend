using FluentValidation;
using InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Validators;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
}