using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using ShoppingManagement.Core.Application.Users.CQRS.Commands.Requests;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class SeedUsersCommandHandler : ICommandHandler<SeedUsersCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOperationRepository<UserIdMap> _userIdMapRepository;

    public SeedUsersCommandHandler(IUnitOfWork unitOfWork, IOperationRepository<UserIdMap> userIdMapRepository)
    {
        _unitOfWork = unitOfWork;
        _userIdMapRepository = userIdMapRepository;
    }

    public async Task Handle(SeedUsersCommand request, CancellationToken cancellationToken)
    {
        var userIdMap = new UserIdMap
        {
            GuidUserId = request.Dto.UserId.ToGuid(),
            StringUserId = request.Dto.UserId
        };

        await _userIdMapRepository.AddAsync(userIdMap);

        await _unitOfWork.SaveChangesAsync();
    }
}