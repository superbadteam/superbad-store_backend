using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.Domain.LocationAggregate.Exceptions;

public class InvalidDistrictException : ValidationException
{
    public InvalidDistrictException(Guid id) : base($"District with id: {id} is invalid")
    {
    }
}