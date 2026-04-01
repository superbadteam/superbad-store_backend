using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using ShoppingManagement.Core.Application.Products.CQRS.Commands.Requests;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Application.Products.CQRS.Commands.Handlers;

public class SyncSoldCommandHandler : ICommandHandler<SyncSoldCommand>
{
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SyncSoldCommandHandler(IReadOnlyRepository<Product> productReadOnlyRepository,
        IOperationRepository<Product> productOperationRepository, IUnitOfWork unitOfWork)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _productOperationRepository = productOperationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SyncSoldCommand request, CancellationToken cancellationToken)
    {
        const int pageSize = 1000;
        var page = 1;
        List<Product> products;

        do
        {
            (products, _) = await _productReadOnlyRepository.GetFilterAndPagingAsync(null, "CreatedAt", page, pageSize);
            foreach (var product in products)
            {
                product.Sold = product.TotalReviews;
                _productOperationRepository.Update(product);
            }

            await _unitOfWork.SaveChangesAsync();
            page++;
        } while (products.Count == pageSize);
    }
}