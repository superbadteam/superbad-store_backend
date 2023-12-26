namespace OrderManagement.Core.Application.Locations.DTOs;

public class DistrictDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;
}