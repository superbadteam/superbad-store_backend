using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Application.CQRS.Queries.OrderQueries.Requests;
using OrderManagement.Core.Application.DTOs.OrderDTOs;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Exceptions;
using OrderManagement.Core.Domain.OrderAggregate.Specifications;

namespace OrderManagement.Core.Application.CQRS.Queries.OrderQueries.Handlers;

public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDetailDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Order> _orderReadOnlyRepository;

    public GetCurrentUserOrderQueryHandler(IReadOnlyRepository<Order> orderReadOnlyRepository, ICurrentUser currentUser)
    {
        _orderReadOnlyRepository = orderReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<OrderDetailDto> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var orderUserIdSpecification = new OrderUserIdSpecification(_currentUser.Id);

        var orderIdSpecification = new EntityIdSpecification<Order>(request.Id);

        var specification = orderUserIdSpecification.And(orderIdSpecification);

        return Optional<OrderDetailDto>.Of(await _orderReadOnlyRepository.GetAnyAsync<OrderDetailDto>(specification))
            .ThrowIfNotExist(new OrderNotFoundException(request.Id)).Get();
    }
}