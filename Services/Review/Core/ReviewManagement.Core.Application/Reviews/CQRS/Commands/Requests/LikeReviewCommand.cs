using BuildingBlock.Core.Application.CQRS;
using ReviewManagement.Core.Application.Reviews.DTOs;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;

public record LikeReviewCommand(Guid ReviewId) : ICommand<ReviewDto>;