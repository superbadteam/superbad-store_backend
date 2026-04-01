namespace OrderManagement.Core.Application.Locations.DTOs;

public class CityDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public List<DistrictDto> Districts { get; set; } = null!;
}