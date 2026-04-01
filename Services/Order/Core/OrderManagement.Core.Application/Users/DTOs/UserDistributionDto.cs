namespace OrderManagement.Core.Application.Users.DTOs;

public class LocationUserCountDto
{
    public Guid Id { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public int Count { get; set; }
    public string Province { get; set; } = string.Empty;
}