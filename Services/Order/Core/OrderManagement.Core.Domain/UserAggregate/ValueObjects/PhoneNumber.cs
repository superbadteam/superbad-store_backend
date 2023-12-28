using BuildingBlock.Core.Domain.Exceptions;
using BuildingBlock.Core.Domain.ValueObject;
using PhoneNumbers;

namespace OrderManagement.Core.Domain.UserAggregate.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    public PhoneNumber(int countryCode, ulong nationalNumber)
    {
        CountryCode = countryCode;
        NationalNumber = nationalNumber;

        ValidateValues();
    }

    public int CountryCode { get; }

    public ulong NationalNumber { get; }

    public override IEnumerable<object?> GetValues()
    {
        yield return CountryCode + NationalNumber.ToString();
    }

    protected override void ValidateValues()
    {
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();

        PhoneNumbers.PhoneNumber parsedPhoneNumber;

        try
        {
            parsedPhoneNumber = phoneNumberUtil.Parse($"+{CountryCode}{NationalNumber}", null);
        }
        catch (Exception ex)
        {
            throw new ValidationException(ex.Message);
        }

        if (CountryCode != parsedPhoneNumber.CountryCode || NationalNumber != parsedPhoneNumber.NationalNumber)
            throw new ValidationException("Invalid country code or national number.");
    }
}