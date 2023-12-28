using BuildingBlock.Core.Application.CQRS;
using ReviewManagement.Core.Application.Reviews.DTOs;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;

public record CreateReviewCommand(Guid OrderItemId, CreateReviewDto Dto) : ICommand<ReviewDto>;