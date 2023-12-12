using BuildingBlock.Core.Application;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderManagement.Core.Domain.LocationAggregate.Entities;

namespace OrderManagement.Core.Application.Seeders;

public class LocationSeeder : IDataSeeder
{
    private readonly ILogger<LocationSeeder> _logger;
    private readonly IOperationRepository<Location> _operationRepository;
    private readonly IReadOnlyRepository<Location> _readonlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LocationSeeder(ILogger<LocationSeeder> logger, IOperationRepository<Location> operationRepository,
        IReadOnlyRepository<Location> readonlyRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _operationRepository = operationRepository;
        _readonlyRepository = readonlyRepository;
        _unitOfWork = unitOfWork;
    }

    public int ExecutionOrder => 1;

    public async Task SeedDataAsync()
    {
        if (await _readonlyRepository.CheckIfExistAsync())
        {
            _logger.LogInformation("Location data already seeded!");
            return;
        }

        _logger.LogInformation("Start seeding location data!");


        var locations = await GetLocationsAsync();

        await _operationRepository.AddRangeAsync(locations);

        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Location data seeded successfully!");
    }

    private static async Task<IEnumerable<Location>> GetLocationsAsync()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "locations.json");

        var jsonString = await File.ReadAllTextAsync(filePath);

        return JsonConvert.DeserializeObject<List<Location>>(jsonString) ?? new List<Location>();
    }
}