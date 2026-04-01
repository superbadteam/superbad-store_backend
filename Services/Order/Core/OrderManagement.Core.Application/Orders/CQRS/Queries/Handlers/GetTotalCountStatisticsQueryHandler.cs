using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using OrderManagement.Core.Application.Orders.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Domain.OrderAggregate.Repositories;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Application.Orders.CQRS.Queries.Handlers;

public class GetTotalCountStatisticsQueryHandler : IQueryHandler<GetTotalCountStatisticsQuery, TotalCountStatDto>
{
    private readonly IOrderReadOnlyRepository _orderReadOnlyRepository;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public GetTotalCountStatisticsQueryHandler(IOrderReadOnlyRepository orderReadOnlyRepository,
        IReadOnlyRepository<User> userReadOnlyRepository, IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _orderReadOnlyRepository = orderReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<TotalCountStatDto> Handle(GetTotalCountStatisticsQuery request,
        CancellationToken cancellationToken)
    {
        var totalUser = await _userReadOnlyRepository.CountAsync();
        var totalProduct = await _productReadOnlyRepository.CountAsync();
        var totalOrder = await _orderReadOnlyRepository.CountAsync();
        var totalSale = await _orderReadOnlyRepository.GetTotalSalesAsync();

        return new TotalCountStatDto
        {
            TotalUsers = totalUser,
            TotalProducts = totalProduct,
            TotalOrders = totalOrder,
            TotalSales = totalSale
        };
    }
}